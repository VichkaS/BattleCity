using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;

namespace BattleCity.NET
{
	class CResourceManager
	{
		private static CResourceManager instance;

		public static CResourceManager Instance
		{
			get
			{
				if (instance == null)
				{
					instance = new CResourceManager();
				}
				return instance;
			}
		}

		public enum ESoundEffect
		{
			Explosion = 0,
			GameStart,
			GameOver,
			PlayerDeath,
			Shot
		}

		private List<System.IO.Stream> m_sounds;

		private CResourceManager()
		{
			// number_of_sounds должен бы быть const int, но C# и этого сделать не дает
			/* const */ int number_of_sounds = (int)(Enum.GetValues(typeof(ESoundEffect)).Cast<ESoundEffect>().Max());
			m_sounds = new List<System.IO.Stream>(number_of_sounds);

			m_sounds[(int)ESoundEffect.Explosion] = Properties.Resources.explode;
			m_sounds[(int)ESoundEffect.GameStart] = Properties.Resources.level_start;
			m_sounds[(int)ESoundEffect.GameOver] = Properties.Resources.game_over;
			m_sounds[(int)ESoundEffect.PlayerDeath] = Properties.Resources.player_death;
			m_sounds[(int)ESoundEffect.Shot] = Properties.Resources.shot;
		}

		public void PlaySound(ESoundEffect sound_effect)
		{
			SoundPlayer player = new SoundPlayer();

			player.Stream = m_sounds[(int)sound_effect];

			try
			{
				player.Play();
			}
			catch // нужно отлавливать только исключения SoundPlayer
			{
				return;
			}
		}
	}
}
