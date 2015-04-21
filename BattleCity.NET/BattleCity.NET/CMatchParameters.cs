using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Diagnostics;

namespace BattleCity.NET
{
	public class CMatchParameters
	{
		// Я бы сделал этот класс независимым от типа:
		// public class CLimitedValue<T>
		// но тогда перестают работать операторы сравнения над типом T
		public class CLimitedValue
		{
			public CLimitedValue(int min, int max, int value)
			{
				Debug.Assert(min < max);
				Debug.Assert(value >= min && value <= max);

				m_min = min;
				m_max = max;
				m_value = value;
			}

			public static implicit operator int(CLimitedValue arg)
			{
				return arg.m_value;
			}

			public int max
			{
				get { return m_max; }
			}

			public int min
			{
				get { return m_min; }
			}

			// В C# нельзя перегружать оператор =
			public void Assign(int value)
			{
				if (value < m_min)
					m_value = m_min;
				else if (value > m_max)
					m_value = m_max;
				else
					m_value = value;
			}

			private int m_min, m_max, m_value;
		}

		public enum EScreenSize
		{
			Small = 0,
			Standard,
			Large
		}

		public CMatchParameters()
		{
			medkit_spawn_rate = new CLimitedValue(0, 60, 5);
			slowness_spawn_rate = new CLimitedValue(0, 60, 3);
			reload_time = new CLimitedValue(10, 600, 80);
			health_points = new CLimitedValue(1, 200, 100);
			speed = new CLimitedValue(1, 20, 2);
			screen_size = EScreenSize.Standard;
		}

		// Частота появления аптечек (штук в минуту)
		public CLimitedValue medkit_spawn_rate;
		// Частота появления антибонусов (штук в минуту)
		public CLimitedValue slowness_spawn_rate;
		// Время перезарядки (в секундах * 10)
		public CLimitedValue reload_time;
		// Здоровье танка
		public CLimitedValue health_points;
		// Скорость танка
		public CLimitedValue speed;
		// Размер игрового поля
		public EScreenSize screen_size;
	}
}
