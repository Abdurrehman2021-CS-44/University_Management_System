using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace UAMS.BL
{
    class STUDENT
    {
        public string sName;
        public int aAge;
        public float sFscMarks;
        public float sEcatMarks;
        public float sAggr;
        public bool isAdmitted;
        public List<string> preferences;
        public List<SUBJECT> registeredSubj;
        public STUDENT()
        {

        }
        public STUDENT(string sName, int sAge, float sFscMarks, float sEcatMarks, List<string> preferences)
        {
            this.sName = sName;
            this.aAge = sAge;
            this.sFscMarks = sFscMarks;
            this.sEcatMarks = sEcatMarks;
            this.preferences = preferences;
        }
        public float calculateMerit()
        {
            return (sFscMarks / 1100.00F) * 60.00F + (sEcatMarks / 400.00F) * 40.00F;
        }
        public void isGetAdmission(List<PROGRAM> program)
        {
            for (int i = 0; i < program.Count; i++)
            {
                for (int j = 0; j < preferences.Count; j++)
                {
                    if (program[i].dTitle == preferences[j])
                    {
                        if (preferences[j] == "CS")
                        {
                            if (sAggr <= 78.00F)
                            {
                                if(isAdmitted == false)
                                {
                                    if (program[i].seats > 0)
                                    {
                                        program[i].seats--;
                                        preferences[0] = preferences[j];
                                        isAdmitted = true;
                                    }
                                }
                            }
                        }
                        else if (preferences[j] == "CE")
                        {
                            if (sAggr <= 76.00F)
                            {
                                if(isAdmitted == false)
                                {
                                    if (program[i].seats > 0)
                                    {
                                        program[i].seats--;
                                        preferences[0] = preferences[j];
                                        isAdmitted = true;
                                    }
                                }
                            }
                        }
                        else if (preferences[j] == "SE")
                        {
                            if (sAggr <= 79.00F)
                            {
                                if(isAdmitted == false)
                                {
                                    if (program[i].seats > 0)
                                    {
                                        program[i].seats--;
                                        preferences[0] = preferences[j];
                                        isAdmitted = true;
                                    }
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
