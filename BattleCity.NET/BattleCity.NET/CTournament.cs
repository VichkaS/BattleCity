using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BattleCity.NET
{
    class CTournament
    {
        private CMatchParameters m_parameters;
        //private List<CTankInfo> m_participants;
		private List<string> m_participants;

		public CTournament(CMatchParameters parameters, List<string> participants)
        {
            m_parameters = parameters;
            m_participants = participants;
        }

        private List<int> FormGroups(int count)
        {
            List<int> groupCount = new List<int> ();

            if (count <= 4)
            {
                groupCount.Add(count);
            }
            else if (count % 4 == 0)
            {
                for (int i = 0; i < (count / 4); i++)
                {
                    groupCount.Add(4);
                }
            }
            else
            {
                int remainder = count % 3;
                int numOfGroups = count / 3;

                if (numOfGroups >= remainder)
                {
					while (true)
					{
						if ((numOfGroups - 1) >= (remainder + 3))
						{
							numOfGroups--;
							remainder += 3;
						}
						else
						{
							break;
						}
					}

                    for (int i = 0; i < numOfGroups; i++)
                    {
                        if (remainder > 0)
                        {
                            groupCount.Add(4);
                            remainder--;
                        }
                        else
                        {
                            groupCount.Add(3);
                        }
                    }
                }
                else
                {
                    for (int i = 0; i < numOfGroups; i++)
                    {  
                        groupCount.Add(3); 
                    }

					groupCount.Add(remainder);
                }
            }

            return groupCount; 
        }

		private List<List<int>> SplitIntoGroups(List<int> participants)
		{
			List<List<int>> result = new List<List<int>>();

			int curIndex = 0;
			List<int> groupCount = FormGroups(participants.Count());

			foreach (var numberInGroup in groupCount)
            {
                List<int> tankIndex = new List<int>();

                for (int i = 0; i < numberInGroup; i++)
                {
					tankIndex.Add(participants[curIndex++]);
                }

				result.Add(tankIndex);
            }

			return result;
		}

		private List<int> SimpleTournament(List<int> participants)
		{
			var groups = SplitIntoGroups(participants);
			List<int> winners = new List<int>();

			while (true)
			{
				foreach (var group in groups)
				{
					var result = StartMatch(group);

					winners.Add(result[0]);

					if (result.Count == 4)
					{
						winners.Add(result[1]);
					}
				}

				if (winners.Count <= 2)
					break;

				groups = SplitIntoGroups(winners);
				winners.Clear();
			}

			return winners;
		}

		private List<int> OlympicTournament(List<int> participants)
        {
			List<int> winners;

			if (m_participants.Count <= 4)
			{
				winners = StartMatch(participants);
			}
			else
			{
				winners = SimpleTournament(participants);

				foreach (var winnerIndex in winners)
				{
					participants.Remove(winnerIndex);
				}

				winners.AddRange(SimpleTournament(participants));
				winners = StartMatch(winners);
			}

			if (winners.Count == 4)
			{
				winners.RemoveAt(3);
			}

			return winners;
        }

		public void HoldTournament()
		{
			List<int> allIndexes = new List<int>(m_participants.Count);
			
			for (int i = 0; i < m_participants.Count; i++)
			{
				allIndexes.Add(i);
			}

			var winners = OlympicTournament(allIndexes);

			FResults resultsForm = new FResults(m_participants, winners);
			resultsForm.Show();
		}
		
		// Проводит матч
		// participants - список участников (от 2 до 4); индексы в массиве m_participants
		// Возвращает список участников в порядке выбывания
		// [0] - победитель, игрок, оставшийся последним
		// [3] - последнее место, был убит первым
		private List<int> StartMatch(List<int> participants)
        {
			return participants;
        }
    }
}
