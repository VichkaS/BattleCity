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

        public FGameSetup()
        {
			m_params = new CMatchParameters();

            Error = false;
            InitializeComponent();
            DirectoryInfo dir = new DirectoryInfo(Directory.GetCurrentDirectory());

            foreach (FileInfo files in dir.GetFiles("*.dll"))
            {
                cbDLLs.Items.Add(Path.GetFileName(files.FullName));
            }

            if (cbDLLs.Items.Count > 0)
            {
                cbDLLs.Text = cbDLLs.Items[0].ToString();
            }

            cbImage.Items.Add("Blue");
            cbImage.Items.Add("Green");
            cbImage.Items.Add("Red");
            cbImage.Items.Add("Yellow");

            if (cbImage.Items.Count > 0)
            {
                cbImage.Text = cbImage.Items[0].ToString();
            }

            dir = null;
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

        private List<CTankInfo> tanks;

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

        void UpdateList()
        {
            gbTank1.Visible = false;
            gbTank2.Visible = false;
            gbTank3.Visible = false;
            gbTank4.Visible = false;
            if (tanks.Count > 0)
            {
                lTank1DLL.Text = tanks[0].GetDLL();
                LoadImage(pbTank1Image, tanks[0].GetImage());
                gbTank1.Visible = true;
            }
            if (tanks.Count > 1)
            {
                lTank2DLL.Text = tanks[1].GetDLL();
				LoadImage(pbTank2Image, tanks[1].GetImage());
                gbTank2.Visible = true;
            }
            if (tanks.Count > 2)
            {
                lTank3DLL.Text = tanks[2].GetDLL();
				LoadImage(pbTank3Image, tanks[2].GetImage());
                gbTank3.Visible = true;
            }
            if (tanks.Count > 3)
            {
                lTank4DLL.Text = tanks[3].GetDLL();
				LoadImage(pbTank4Image, tanks[3].GetImage());
                gbTank4.Visible = true;
            }
        }

        private void bAdd_Click(object sender, EventArgs e)
        {
            if (tanks.Count > 3)
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
            UpdateList();
        }

        private void bTank1Remove_Click(object sender, EventArgs e)
        {
            tanks.RemoveAt(0);
            UpdateList();
        }

        private void bTank2Remove_Click(object sender, EventArgs e)
        {
            tanks.RemoveAt(1);
            UpdateList();
        }

        private void bTank3Remove_Click(object sender, EventArgs e)
        {
            tanks.RemoveAt(2);
            UpdateList();
        }

        private void bTank4Remove_Click(object sender, EventArgs e)
        {
            tanks.RemoveAt(3);
            UpdateList();
        }

        private void bNext_Click(object sender, EventArgs e)
        {
            if (tanks.Count < 2)
            {
                MessageBox.Show("Not enough players (minimum 2)");
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
            Directory.Delete("tmp",true);
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
    }
}