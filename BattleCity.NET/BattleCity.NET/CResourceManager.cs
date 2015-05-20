using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Media;
using System.Drawing;
using System.Drawing.Imaging;

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

		public enum SoundEffect
		{
			Explosion = 0,
			GameStart,
			GameOver,
			PlayerDeath,
			Shot
		}

		private System.IO.Stream[] m_sounds;

		private CResourceManager()
		{
			/* const */ int number_of_sounds = (int)(Enum.GetValues(typeof(SoundEffect)).Cast<SoundEffect>().Max()) + 1;
			m_sounds = new System.IO.Stream[number_of_sounds];

			m_sounds[(int)SoundEffect.Explosion] = Properties.Resources.explode;
			m_sounds[(int)SoundEffect.GameStart] = Properties.Resources.level_start;
			m_sounds[(int)SoundEffect.GameOver] = Properties.Resources.game_over;
			m_sounds[(int)SoundEffect.PlayerDeath] = Properties.Resources.player_death;
			m_sounds[(int)SoundEffect.Shot] = Properties.Resources.shot;
		}

		public void PlaySound(SoundEffect sound_effect)
		{
			System.IO.Stream soundStream = m_sounds[(int)sound_effect];

			soundStream.Seek(0, System.IO.SeekOrigin.Begin);
			SoundPlayer player = new SoundPlayer(soundStream);
			player.Play();
		}

		private bool ThumbnailCallback()
		{
			return false;
		}

		public Image ResizeImage(Image source, int width, int height)
		{
			Image.GetThumbnailImageAbort myCallback = new Image.GetThumbnailImageAbort(ThumbnailCallback);
			return source.GetThumbnailImage(width, height, myCallback, IntPtr.Zero);
		}

		public void ColorizeImage(Image image, Color color)
		{
			ImageAttributes imageAttributes = new ImageAttributes();
			int width = image.Width;
			int height = image.Height;

			float r = Math.Max(color.R / 255.0f, 0.1f);
			float g = Math.Max(color.G / 255.0f, 0.1f);
			float b = Math.Max(color.B / 255.0f, 0.1f);
			float[][] colorMatrixElements = {
				new float[] {r, 0, 0, 0, 0},
				new float[] {0, g, 0, 0, 0},
				new float[] {0, 0, b, 0, 0},
				new float[] {0, 0, 0, 1, 0},
				new float[] {0, 0, 0, 0, 1}};
			
			ColorMatrix colorMatrix = new ColorMatrix(colorMatrixElements);
			
			imageAttributes.SetColorMatrix(
				colorMatrix,
				ColorMatrixFlag.Default,
				ColorAdjustType.Bitmap);
			
			using (Graphics e = Graphics.FromImage(image))
			{
				e.DrawImage(
					image,
					new Rectangle(0, 0, width, height),	// destination rectangle 
					0, 0,								// upper-left corner of source rectangle 
					width,								// width of source rectangle
					height,								// height of source rectangle
					GraphicsUnit.Pixel,
					imageAttributes);
			}
		}
	}
}
