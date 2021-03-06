﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.NET
{
    class CExplosion
    {
        public CExplosion(int x, int y)
        {
            m_x = x;
            m_y = y;
            duration = CConstants.explodeTime;

			CResourceManager.Instance.PlaySound(CResourceManager.SoundEffect.Explosion);
        }
        public void Update()
        {
            duration--;
        }
        public bool IsEnded()
        {
            return duration <= 0;
        }
        public void Draw(Graphics graph)
        {
            graph.DrawImage(CConstants.explosion, Convert.ToInt32(m_x - CConstants.tankSize / 2), Convert.ToInt32(m_y - CConstants.tankSize / 2));
        }

        private int m_x;
        private int m_y;
        private int duration;
    }
}
