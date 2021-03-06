﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.InteropServices;

namespace BattleCity.NET
{
    class CConstants
    {
        static CConstants()
        {
            error = 0;
			
			explosion = (Bitmap)Properties.Resources.ResourceManager.GetObject("explosion");
			shell = (Bitmap)Properties.Resources.ResourceManager.GetObject("shell");
			wrecked = (Bitmap)Properties.Resources.ResourceManager.GetObject("wrecked");
            
			if (explosion == null || shell == null || wrecked == null)
            {
                error = 1;
                return;
            }

            explosion = explosion.GetThumbnailImage(CConstants.tankSize, CConstants.tankSize, null, IntPtr.Zero);
            shell = shell.GetThumbnailImage(CConstants.shellSize, CConstants.shellSize, null, IntPtr.Zero);
            wrecked = wrecked.GetThumbnailImage(CConstants.tankSize, CConstants.tankSize, null, IntPtr.Zero);
        }

		// 30 FPS
		public const int refreshTime = 1000 / 30;

        public const int tankSize = 64;
        public const int turretSize = 80;
        static public int formWidth = 640;
        static public int formHeight = 480;
        public const int defaultTankSpeed = refreshTime / 10;
        static public int tankSpeed = defaultTankSpeed;
        public const double baseRotationRate = 0.01 * refreshTime;
        public const double turretRotationRate = 0.01 * refreshTime;
        static public int reloadTime = 5000 / refreshTime;
        static public int tankHealth = 100;
        public const int shellSpeed = refreshTime;
        public const int shellSize = 16;
        public const int explodeTime = 200 / refreshTime;
        public const int medChestsSize = 20;
        public readonly static Image explosion;
        public readonly static Image shell;
        public readonly static Image wrecked;
        public static int error;
        public const int slowTime = 5000;
    }
}