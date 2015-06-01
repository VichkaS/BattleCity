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
		private Color m_curColor;
		private int m_imageKey = 0;

        public FGameSetup()
        {
			InitializeComponent();

			m_params = new CMatchParameters();
			UpdateColorPreview(true);
			UpdateInterface();
			openFileDialog.InitialDirectory = Directory.GetCurrentDirectory();
        }

		private void UpdateInterface()
		{
			int itemsCount = lvTanks.Items.Count;

			if (itemsCount < 2)
			{
				bNext.Enabled = false;
				lMatchMode.Text = "Add at least two players to start the game";
				lMatchMode.ForeColor = Color.Red;
			}
			else
			{
				bNext.Enabled = true;
				lMatchMode.ForeColor = Color.Black;

				if (itemsCount >= 2 && itemsCount <= 4)
				{
					lMatchMode.Text = "The game will be started in normal mode";
				}
				else
				{
					lMatchMode.Text = "The game will be started in tournament mode";
				}
			}
		}

		private void AddParticipant(string dllName)
		{
			CTankInfo tankInfo = new CTankInfo(dllName, m_curColor);
			UpdateColorPreview(true);

			Image previewImage = CResourceManager.Instance.GetTankPreview(tankInfo.Color);
			
			if (lvTanks.LargeImageList == null)
			{
				lvTanks.LargeImageList = new ImageList();
				lvTanks.LargeImageList.ImageSize = new Size(32, 32);
				lvTanks.LargeImageList.ColorDepth = ColorDepth.Depth32Bit;
			}

			m_imageKey++;
			lvTanks.LargeImageList.Images.Add(m_imageKey.ToString(), previewImage);
			string ShortName = Path.GetFileName(tankInfo.DLLPath);
			ListViewItem item = new ListViewItem(ShortName, m_imageKey.ToString());
			item.Tag = tankInfo;
			lvTanks.Items.Add(item);

			UpdateInterface();
		}

        private void bAdd_Click(object sender, EventArgs e)
        {
			if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
			{
				foreach (string fileName in openFileDialog.FileNames)
				{
					AddParticipant(fileName);
				}
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

			UpdateInterface();
		}

        private void bNext_Click(object sender, EventArgs e)
        {
			FBattleScreen frm2 = new FBattleScreen(lvTanks.Items.Count);
            Directory.CreateDirectory("tmp");

			for (int i = 0; i < lvTanks.Items.Count; i++)
            {
				CTankInfo tankInfo = (CTankInfo)lvTanks.Items[i].Tag;
				File.Copy(tankInfo.DLLPath, "tmp/tempDLL" + Convert.ToString(i) + ".dll", true);
				frm2.NewTank("tmp/tempDLL" + Convert.ToString(i) + ".dll", "green");
            }

            this.Hide();
            frm2.ShowDialog(this);
            Directory.Delete("tmp", true);
        }

		private void bSettings_Click(object sender, EventArgs e)
		{
			FMatchSettings settingsDlg = new FMatchSettings(m_params);
			settingsDlg.ShowDialog(this);
		}

		private Bitmap GenerateColorPreview(Color color)
		{
			Bitmap colorPreview = Properties.Resources.tank_icon;
			CResourceManager.ColorizeImage(colorPreview, color);
			return colorPreview;
		}

		private void UpdateColorPreview(bool newColor)
		{
			if (newColor)
			{
				m_curColor = CResourceManager.Instance.GenerateRandomColor();
			}

			bChangeColor.Image = GenerateColorPreview(m_curColor);
		}
		
		private void bChangeColor_Click(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog(this) == DialogResult.OK)
			{
				if (lvTanks.SelectedItems.Count == 1)
				{
					int imgIndex = lvTanks.LargeImageList.Images.IndexOfKey(lvTanks.SelectedItems[0].ImageKey);
					lvTanks.LargeImageList.Images[imgIndex] = CResourceManager.Instance.GetTankPreview(colorDialog.Color);
					lvTanks.Refresh();
				}
				else
				{
					m_curColor = colorDialog.Color;
					UpdateColorPreview(false);
				}
			}
		}

		private void button1_Click(object sender, EventArgs e)
		{
			try
			{
				CTankDll td = new CTankDll("D:\\Documents\\Projects\\GitHub\\BattleCity\\Intelligences\\Circle\\Debug\\AIExample.dll");
				MessageBox.Show(td.AuthorName);
			}
			catch (DllException ex)
			{
				string message = String.Format("Error while loading \"{0}\":\n{1}", ex.DllFileName, ex.ErrorText);
				MessageBox.Show(message, "Incorrect DLL", MessageBoxButtons.OK, MessageBoxIcon.Error);
			}
		}
    }
}
