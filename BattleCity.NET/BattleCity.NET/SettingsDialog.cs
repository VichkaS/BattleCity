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
	public partial class SettingsDialog : Form
	{
		private CMatchParameters m_params;

		private void InitTrackBar(TrackBar tb, CMatchParameters.CLimitedValue val, Label label)
		{
			tb.Maximum = val.max;
			tb.Minimum = val.min;
			tb.Value = val;
			tb.TickFrequency = Math.Max((tb.Maximum - tb.Minimum) / 20, 1);

			label.Text = tb.Value.ToString();
		}

		public SettingsDialog(CMatchParameters match_parameters)
		{
			InitializeComponent();
			m_params = match_parameters;

			cbFieldSize.SelectedIndex = (int)m_params.screen_size;
			InitTrackBar(tbBonusFreq, m_params.medkit_spawn_rate, lBonusFreq);
			InitTrackBar(tbAntibFreq, m_params.slowness_spawn_rate, lAntibFreq);
			InitTrackBar(tbShootingFreq, m_params.reload_time, lShootingFreq);
			InitTrackBar(tbHealth, m_params.health_points, lHealth);
			InitTrackBar(tbSpeed, m_params.speed, lSpeed);
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void tbBonusFreq_Scroll(object sender, EventArgs e)
		{
			lBonusFreq.Text = tbBonusFreq.Value.ToString();
		}

		private void tbAntibFreq_Scroll(object sender, EventArgs e)
		{
			lAntibFreq.Text = tbAntibFreq.Value.ToString();
		}

		private void tbShootingFreq_Scroll(object sender, EventArgs e)
		{
			lShootingFreq.Text = tbShootingFreq.Value.ToString();
		}

		private void tbHealth_Scroll(object sender, EventArgs e)
		{
			lHealth.Text = tbHealth.Value.ToString();
		}

		private void tbSpeed_Scroll(object sender, EventArgs e)
		{
			lSpeed.Text = tbSpeed.Value.ToString();
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			m_params.screen_size = (CMatchParameters.EScreenSize)cbFieldSize.SelectedIndex;
			m_params.medkit_spawn_rate.Assign(tbBonusFreq.Value);
			m_params.slowness_spawn_rate.Assign(tbAntibFreq.Value);
			m_params.reload_time.Assign(tbShootingFreq.Value);
			m_params.health_points.Assign(tbHealth.Value);
			m_params.speed.Assign(tbSpeed.Value);
			this.Close();
		}
	}
}
