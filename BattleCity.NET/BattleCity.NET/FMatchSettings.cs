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
	public partial class FMatchSettings : Form
	{
		private CMatchParameters m_params;

		private void UpdateBonusFreq()
		{
			if (tbBonusFreq.Value == 0)
			{
				lBonusFreq.Text = "do not spawn";
			}
			else
			{
				lBonusFreq.Text = tbBonusFreq.Value.ToString() + " per minute";
			}
		}

		private void UpdateAntibFreq()
		{
			if (tbAntibFreq.Value == 0)
			{
				lAntibFreq.Text = "do not spawn";
			}
			else
			{
				lAntibFreq.Text = tbAntibFreq.Value.ToString() + " per minute";
			}
		}

		private void UpdateReloadTime()
		{
			lReloadTime.Text = tbReloadTime.Value.ToString() + " second";
			if (tbReloadTime.Value != 1)
			{
				lReloadTime.Text += "s";
			}
		}

		private void UpdateHealth()
		{
			lHealth.Text = tbHealth.Value.ToString() + " hp";
		}

		private void UpdateSpeed()
		{
			lSpeed.Text = tbSpeed.Value.ToString() + "%";
		}

		private delegate void LabelUpdateProc();
		private void InitTrackBar(TrackBar tb, CMatchParameters.CLimitedValue val, LabelUpdateProc updateProc)
		{
			tb.Maximum = val.max;
			tb.Minimum = val.min;
			tb.Value = val;

			int tickFrequency = Convert.ToInt32((tb.Maximum - tb.Minimum) / 20.0);
			tb.TickFrequency = Math.Max(tickFrequency, 1);

			// updateProc – процедура обновления текста надписи в соответствии со значением трекбара
			// Установим её как обработчик события Scroll
			tb.Scroll += delegate(System.Object o, System.EventArgs e)
			{ updateProc(); };
			// И вызовем на этапе инициализации, чтобы задать надписи значение по умолчанию
			updateProc();
		}

		public FMatchSettings(CMatchParameters match_parameters)
		{
			InitializeComponent();
			m_params = match_parameters;

			InitTrackBar(tbBonusFreq, m_params.medkit_spawn_rate, UpdateBonusFreq);
			InitTrackBar(tbAntibFreq, m_params.slowness_spawn_rate, UpdateAntibFreq);
			InitTrackBar(tbReloadTime, m_params.reload_time, UpdateReloadTime);
			InitTrackBar(tbHealth, m_params.health_points, UpdateHealth);
			InitTrackBar(tbSpeed, m_params.speed, UpdateSpeed);
			cbFieldSize.SelectedIndex = (int)m_params.screen_size;
		}

		private void bOk_Click(object sender, EventArgs e)
		{
			m_params.medkit_spawn_rate.Assign(tbBonusFreq.Value);
			m_params.slowness_spawn_rate.Assign(tbAntibFreq.Value);
			m_params.reload_time.Assign(tbReloadTime.Value);
			m_params.health_points.Assign(tbHealth.Value);
			m_params.speed.Assign(tbSpeed.Value);
			m_params.screen_size = (CMatchParameters.EScreenSize)cbFieldSize.SelectedIndex;

			this.Close();
		}

		private void bCancel_Click(object sender, EventArgs e)
		{
			this.Close();
		}
	}
}
