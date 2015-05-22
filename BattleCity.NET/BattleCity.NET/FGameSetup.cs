using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace BattleCity.NET
{
    public partial class FGameSetup : Form
    {
		private CMatchParameters m_params;
		private Image m_tankPreview;
		private Color m_curColor;
		private int m_imageKey = 0;
		private List<CTankInfo> tanks;
		private static Random m_RNG = new Random();

        public FGameSetup()
        {
			Error = false;
			InitializeComponent();

			m_params = new CMatchParameters();
			m_tankPreview = CResourceManager.Instance.ResizeImage(Properties.Resources.tank_full, 32, 32);
			UpdateColorPreview(true);

			/*
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            foreach (FileInfo files in dir.GetFiles("*.dll"))
            {
                cbDLLs.Items.Add(Path.GetFileName(files.FullName));
            }

            if (cbDLLs.Items.Count > 0)
            {
                cbDLLs.Text = cbDLLs.Items[0].ToString();
            }

            dir = null;
			 */
			tanks = new List<CTankInfo>();
        }

        class CTankInfo
        {
            private string dllPath;
            private string imagePath;
            public CTankInfo(string dll, string image) { dllPath = dll; imagePath = image; }
            public void SetImage(string image) { imagePath = image; }
            public string GetDLL() { return dllPath; }
            public string GetImage() { return imagePath; }
        }

        void LoadImage(PictureBox img, string str)
        {
			Bitmap bm = (Bitmap)Properties.Resources.ResourceManager.GetObject("tank_" + str.ToLower());

			if (bm == null)
			{
				MessageBox.Show(this, "Cannot find images", "ERROR!", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Error = true;
                return;
			}

			img.Image = bm;
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            /*if (tanks.Count > 3)
            {
                MessageBox.Show("Too many players (maximum 4)");
                return;
            }
            if(cbDLLs.Items.Contains(cbDLLs.Text))
            {
                tanks.Add(new CTankInfo(cbDLLs.Text, cbImage.Text));
            }
            if(cbImage.SelectedIndex < cbImage.Items.Count - 1)
            {
                cbImage.SelectedIndex++;
            }
            UpdateList();*/
			m_imageKey++;

			Image colorized = (Image)m_tankPreview.Clone();
			CResourceManager.Instance.ColorizeImage(colorized, m_curColor);

			if (lvTanks.LargeImageList == null)
			{
				lvTanks.LargeImageList = new ImageList();
				lvTanks.LargeImageList.ImageSize = new Size(32, 32);
				lvTanks.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
			}

			lvTanks.LargeImageList.Images.Add(m_imageKey.ToString(), colorized);
			//ListViewItem i = new ListViewItem(cbDLLs.Text, m_imageKey.ToString());
			//i.Tag = new CTankInfo(cbDLLs.Text, "Green");
			//lvTanks.Items.Add(i);

			UpdateColorPreview(true);
        }

        private void bNext_Click(object sender, EventArgs e)
        {
			tanks.Clear();
			foreach (ListViewItem tank in lvTanks.Items)
			{
				tanks.Add((CTankInfo)tank.Tag);
			}

            if (tanks.Count < 2)
            {
                MessageBox.Show("Not enough players (minimum 2)");
                return;
            }
			if (tanks.Count > 4)
			{
				MessageBox.Show("Not implemented yet");
				return;
			}

            FBattleScreen frm2 = new FBattleScreen(tanks.Count);
            Directory.CreateDirectory("tmp");
            for (int i = 0; i < tanks.Count; i++)
            {
                File.Copy(tanks[i].GetDLL(), "tmp/tempDLL" + Convert.ToString(i) + ".dll", true);
                frm2.NewTank("tmp/tempDLL" + Convert.ToString(i) + ".dll", tanks[i].GetImage());
            }
            this.Hide();
            frm2.ShowDialog(this);
            Directory.Delete("tmp", true);
        }

        private bool Error;

        private void Form1_Shown(object sender, EventArgs e)
        {
            if (Error)
            {
                Application.Exit();
                return;
            }
        }

		private void bSettings_Click(object sender, EventArgs e)
		{
			FMatchSettings settingsDlg = new FMatchSettings(m_params);
			settingsDlg.ShowDialog(this);
		}

		private void button1_Click(object sender, EventArgs e)
		{
			FResults resForm = new FResults();
			resForm.ShowDialog(this);
		}

		private Bitmap GenerateColorPreview(Color color)
		{
			const int previewWidth = 24, previewHeight = 24;

			Bitmap bm = new Bitmap(previewWidth, previewHeight);

			using (Graphics gr = Graphics.FromImage(bm))
			{
				Rectangle rect = new Rectangle(0, 0, previewWidth - 3, previewHeight - 3);
				gr.FillEllipse(new SolidBrush(color), rect);
				gr.DrawEllipse(new Pen(Color.Black, 3), rect);
			}

			return bm;
		}
		
		private Color GenerateRandomColor()
		{
			return Color.FromArgb(m_RNG.Next(256), m_RNG.Next(256), m_RNG.Next(256));
		}

		private void UpdateColorPreview(bool newColor)
		{
			if (newColor)
			{
				m_curColor = GenerateRandomColor();
			}

			bChangeColor.Image = GenerateColorPreview(m_curColor);
		}
		
		private void bChangeColor_Click(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				m_curColor = colorDialog.Color;
				UpdateColorPreview(false);
			}
		}

		private void bRemove_Click(object sender, EventArgs e)
		{
			foreach (ListViewItem tank in lvTanks.SelectedItems)
			{
				string imageKey = tank.ImageKey;
				tank.Remove();
				lvTanks.LargeImageList.Images.RemoveByKey(imageKey);
			}
		}
    }
}
