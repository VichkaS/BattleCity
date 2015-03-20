using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace BattleCity.NET
{
    class CShellTrack
    {
        private const double M_HEIGHT = CConstants.shellSize / 3;
        private double m_x1;
        private double m_x2;
        private double m_y1;
        private double m_y2;
        private int m_timeBegin;
        public CShellTrack(double x, double y)
        {
            m_x1 = x;
            m_y1 = y;
            m_x2 = x;
            m_y2 = y;
            m_timeBegin = (int)(DateTime.Now.Second);
        }


        public void SetWidth(double x, double y)
        {
            m_x2 = x;
            m_y2 = y;
           // m_width = Math.Sqrt(Math.Pow(x-m_leftTopX, 2)+Math.Pow(y-m_leftTopY,2));
        }

        public bool IsVisible()
        {
            int diff = (int)(DateTime.Now.Second) - m_timeBegin;
            if (diff < 2)
                return true;
            else
                return false;
        }

        public void Draw(Graphics graph)
        {
            Pen pen1 = new Pen(Color.Gray, (float)M_HEIGHT);

            pen1.DashStyle = System.Drawing.Drawing2D.DashStyle.Dot;

            graph.SmoothingMode = SmoothingMode.AntiAlias;
            graph.DrawLine(pen1, (float)m_x1, (float)m_y1, (float)m_x2, (float)m_y2);
        }

    }
}
