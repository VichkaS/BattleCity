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
        private List<CTankInfo> m_participants;
        public CTournament(CMatchParameters parameters, List<CTankInfo> participants)
        {
            m_parameters = parameters;
            m_participants = participants;
        }
        private List<int> SplitIntoGroups(int count)
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
                if (numOfGroups <= remainder)
                {
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
        public void StartTournament()
        {
            int curIndex = 0;
            List<int> groupCount = SplitIntoGroups(m_participants.Count());
            foreach (var numberInGroup in groupCount)
            {
                List<int> tankIndex = new List<int>();
                for (int i = 0; i < numberInGroup; i++)
                {
                    tankIndex.Add(curIndex++);
                }
                StartMatch(tankIndex);
            }
        }
        public int StartMatch(List<int> participants)
        {
            return 0;
        }
    }
}
