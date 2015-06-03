using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BattleCity.NET
{
	public partial class FResults : Form
	{
		bool b_again = false;

		// Показывает результаты игры
		// participants - список участников
		// winners - индексы игроков, занявших соответственно 1, 2 и 3 места
		public FResults(List<CTankInfo> participants, List<int> winners)
		{
			InitializeComponent();

			lFirst.Text = participants[winners[0]].AuthorName;
			if (participants.Count > 4)
			{
				if (winners.Count >= 2)
				{
					lSecond.Text = participants[winners[1]].AuthorName;
					lSecond.Visible = true;
					pbSecond.Visible = true;
				}

				if (winners.Count >= 3)
				{
					lThird.Text = participants[winners[2]].AuthorName;
					lThird.Visible = true;
					pbThird.Visible = true;
				}
			}

			foreach (var participant in participants)
			{
				ListViewItem lvItem = new ListViewItem(participant.AuthorName);

				lvItem.SubItems.Add(participant.Statistics.shotsFired.ToString());

				if (participant.Statistics.shotsFired == 0)
				{
					lvItem.SubItems.Add("0%");
				}
				else
				{
					lvItem.SubItems.Add(Convert.ToInt32(participant.Statistics.successfulShots / participant.Statistics.shotsFired * 100f).ToString() + "%");
				}

				lvItem.SubItems.Add(participant.Statistics.destroyedTanks.ToString());
				lvItem.SubItems.Add(participant.Statistics.collectedMedicineChest.ToString());
				lvItem.SubItems.Add(participant.Statistics.collectedAntibonus.ToString());
				lvItem.SubItems.Add(participant.Statistics.lostHealth.ToString());
				lvItem.SubItems.Add(participant.Statistics.distanceTraveled.ToString());

				lvResults.Items.Add(lvItem);
			}
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			b_again = false;
			this.Close();
		}

		private void bRestart_Click(object sender, EventArgs e)
		{
			b_again = true;
			this.Close();
		}

		public bool ContinueGame()
		{
			return b_again;
		}
	}
}
