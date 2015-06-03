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
		private Bitmap m_tankPreview;
		private Random m_RNG;

		const int PreviewWidth = 32, PreviewHeight = 32;

		private CResourceManager()
		{
			m_RNG = new Random();

			m_tankPreview = ResizeBitmap(Properties.Resources.tank_full,
				PreviewWidth, PreviewHeight);

			int number_of_sounds = (int)(Enum.GetValues(typeof(SoundEffect)).Cast<SoundEffect>().Max()) + 1;
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

		public Image GetTankPreview(Color color)
		{
			Image preview = (Image)m_tankPreview.Clone();
			ColorizeImage(preview, color);
			return preview;
		}

		public static Bitmap GetColorPreview(Color color)
		{
			Bitmap colorPreview = Properties.Resources.tank_icon;
			ColorizeImage(colorPreview, color);
			return colorPreview;
		}

		public static Bitmap GetTankBase(Color color)
		{
			Bitmap result = ResizeBitmap(Properties.Resources.tank_base, CConstants.tankSize, CConstants.tankSize);
			ColorizeImage(result, color);
			return result;
		}

		public static Bitmap GetTankTurret(Color color)
		{
			Bitmap result = ResizeBitmap(Properties.Resources.tank_turret, CConstants.turretSize, CConstants.turretSize);
			ColorizeImage(result, color);
			return result;
		}

		public static Bitmap GetTank(Color color)
		{
			Bitmap result = ResizeBitmap(Properties.Resources.tank_full, 50, 50);
			ColorizeImage(result, color);
			return result;
		}

		public Random RNG
		{
			get
			{
				return m_RNG;
			}
		}

		public Color GenerateRandomColor()
		{
			return Color.FromArgb(RNG.Next(256), RNG.Next(256), RNG.Next(256));
		}

		public static Bitmap ResizeBitmap(Bitmap source, int width, int height)
		{
			return (Bitmap)source.GetThumbnailImage(width, height, null, IntPtr.Zero);
		}

		public static void ColorizeImage(Image image, Color color)
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
