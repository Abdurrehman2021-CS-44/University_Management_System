using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAMS.BL;

namespace UAMS
{
    class Program
    {
        static void Main(string[] args)
        {
            List<STUDENT> student = new List<STUDENT>();
            List<PROGRAM> programs = new List<PROGRAM>();
            string option;
            while (true)
            {
                Console.Clear();
                option = mainMenu();
                if (option == "1")
                {
                    student.Add(addStudent(programs));
                }
                else if (option == "2")
                {
                    programs.Add(addDegreeProgram());
                }
                else if (option == "3")
                {
                    for(int i = 0; i < student.Count; i++)
                    {
                        student[i].isGetAdmission(programs);
                        if (student[i].isAdmitted == true)
                        {
                            Console.WriteLine(student[i].sName + " get admission in " + student[i].preferences[0]);
                        }
                        else
                        {
                            Console.WriteLine(student[i].sName + " did not get admission in " + student[i].preferences[0]);
                        }
                    }
                }
                else if (option == "4")
                {
                    viewStudent(student);
                }
                else if (option == "5")
                {
                    viewStudentByProgram(student,programs);
                }
                else if (option == "6")
                {
                    registerSubj(student,programs);
                }
                else if (option == "7")
                {

                }
                else if (option == "8")
                {
                    Console.Clear();
                    break;
                }
                else
                {
                    Console.WriteLine("Invalid Input");
                    Console.Write("Press any key to continue...");
                    Console.ReadKey();
                    continue;
                }
                Console.Write("Press any key to continue...");
                Console.ReadKey();
            }

        }
        static string mainMenu()
        {
            Console.WriteLine("1 -> Add Students");
            Console.WriteLine("2 -> Add Degree Program");
            Console.WriteLine("3 -> Generate Merit List");
            Console.WriteLine("4 -> View Registered Students");
            Console.WriteLine("5 -> View Student with Specific Program");
            Console.WriteLine("6 -> Register subject for a specific student");
            Console.WriteLine("7 -> Calculate fee for all Regitered Subject");
            Console.WriteLine("8 -> Exit");
            string option;
            Console.Write("Your option...");
            option = Console.ReadLine();
            return option;
        }
        static STUDENT addStudent(List<PROGRAM> degreeProgram)
        {
            string name;
            int age, howMany;
            float fscMarks, ecatMarks;
            List<string> dProgram = new List<string>();
            Console.Write("Enter Student Name : ");
            name = Console.ReadLine();
            Console.Write("Enter Student Age : ");
            age = int.Parse(Console.ReadLine());
            Console.Write("Enter Student FSC Marks : ");
            fscMarks = float.Parse(Console.ReadLine());
            Console.Write("Enter Student ECAT Marks : ");
            ecatMarks = float.Parse(Console.ReadLine());
            Console.WriteLine("Available Degree Programs");
            for (int i = 0; i < degreeProgram.Count; i++)
            {
                Console.WriteLine((i+1) + ". " + degreeProgram[i].dTitle);
            }
            if (degreeProgram.Count > 0)
            {
                Console.Write("How many preference you want to enter : ");
                howMany = int.Parse(Console.ReadLine());
                for (int j = 0; j < howMany; j++)
                {
                    string program;
                    program = Console.ReadLine();
                    dProgram.Add(program);
                }
            }
            STUDENT newStudent = new STUDENT(name, age, fscMarks, ecatMarks, dProgram);
            return newStudent;
        }
        static PROGRAM addDegreeProgram()
        {
            string dTitle, duration;
            int seats, howMany;
            List<SUBJECT> sDetails = new List<SUBJECT>();
            Console.Write("Enter Degree Title : ");
            dTitle = Console.ReadLine();
            Console.Write("Enter Degree Duration : ");
            duration = Console.ReadLine();
            Console.Write("Enter Degree Seats : ");
            seats = int.Parse(Console.ReadLine());
            Console.Write("How many subjects you want to enter ? : ");
            howMany = int.Parse(Console.ReadLine());
            for(int i = 0; i < howMany; i++)
            {
                SUBJECT Details = new SUBJECT();
                Console.Write("Enter Subject Code : ");
                Details.sCode = Console.ReadLine();
                Console.Write("Enter Subject Type : ");
                Details.sType = Console.ReadLine();
                Console.Write("Enter Subject Credit Hours : ");
                Details.sCreditHours = int.Parse(Console.ReadLine());
                Console.Write("Enter Subject Fee : ");
                Details.sFee = float.Parse(Console.ReadLine());
                sDetails.Add(Details);
            }
            PROGRAM newProgram = new PROGRAM(dTitle, duration, seats, sDetails);
            return newProgram;
        }
        static void viewStudent(List<STUDENT> students)
        {
            Console.WriteLine("Name\tAge\tFSC\tECAT");
            for(int i = 0; i < students.Count; i++)
            {
                if (students[i].isAdmitted == true)
                {
                    Console.WriteLine(students[i].sName + "\t" + students[i].aAge + "\t" + students[i].sFscMarks + "\t" + students[i].sEcatMarks);
                }
            }
        }
        static void viewStudentByProgram(List<STUDENT> students, List<PROGRAM> programs)
        {
            string program;
            Console.Write("Enter Program : ");
            program = Console.ReadLine();
            Console.WriteLine("Name\tAge\tFSC\tECAT");
            for (int i = 0; i < students.Count; i++)
            {
                if(students[i].isAdmitted == true)
                {
                    if (program == students[i].preferences[0])
                    {
                        Console.WriteLine(students[i].sName + "\t" + students[i].aAge + "\t" + students[i].sFscMarks + "\t" + students[i].sEcatMarks);
                    }
                }
            }
        }
        static void registerSubj(List<STUDENT> students, List<PROGRAM> programs)
        {
            string name;
            Console.Write("Enter Student Name : ");
            name = Console.ReadLine();
            int i;
            for (i = 0; i < students.Count; i++)
            {
                if (students[i].isAdmitted == true) 
                { 
                    if (name == students[i].sName)
                    {
                        for(int j = 0; j < students[i].preferences.Count; j++)
                        {
                            if(students[i].preferences[0] == programs[j].dTitle)
                            {
                                Console.WriteLine("CODE\tTYPE\tCredit Hours");
                                for(int k = 0; k < programs[j].subjDetails.Count; k++)
                                {
                                    Console.WriteLine(programs[j].subjDetails[k].sCode + "\t" + programs[j].subjDetails[k].sType + "\t" + programs[j].subjDetails[k].sCreditHours);
                                }
                                string code;
                                Console.WriteLine("To Register!");
                                Console.Write("Enter Subject Code : ");
                                code = Console.ReadLine();
                                for (int l = 0; l < programs[j].subjDetails.Count; l++)
                                {
                                    if (code == programs[j].subjDetails[l].sCode)
                                    {
                                        SUBJECT s = new SUBJECT();
                                        s = programs[j].subjDetails[l];
                                        students[i].registeredSubj.Add(s);
                                    }
                                    Console.WriteLine(students[i].registeredSubj[0].sCode + "\t" + students[i].registeredSubj[0].sType);
                                }
                            }
                        }
                    }
                }
            }
        }
    }
}
