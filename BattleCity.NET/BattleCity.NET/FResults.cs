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
		// Показывает результаты игры
		// participants - список участников
		// winners - индексы игроков, занявших соответственно 1, 2 и 3 места
		public FResults(List<string> participants, List<int> winners)
		{
			InitializeComponent();

			lFirst.Text = participants[winners[0]];
			lSecond.Text = participants[winners[1]];
			lThird.Text = participants[winners[2]];

			foreach (var participant in participants)
			{
				lvResults.Items.Add(participant);
			}
		}

		private void bExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
