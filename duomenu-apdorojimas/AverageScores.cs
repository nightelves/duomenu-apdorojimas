using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text.RegularExpressions;

namespace duomenu_apdorojimas
{
    class AverageScores
    {
        const string EXIT_STRING = "x";

        bool bFromFile = false;

        protected Queue<Student> oStudentList;

        Stopwatch stopwatch = new Stopwatch();

        public AverageScores()
        {
            oStudentList = new Queue<Student>();
        }

        public void inputStudents()
        {
            string inputString = "";

            Console.WriteLine("Jei norite nuskaityti studentus is failo, iveskit 'f'. Jei norite dirbti su konsole - bet koki kita simboliu.");

            inputString = Console.ReadLine();

            stopwatch.Start();

            bFromFile = (inputString == "f");

            if (bFromFile)
                inputFromFile();
            else
                inputFromConsole();
        }

        public void outputScores()
        {
            if (bFromFile)
                outputScoresFromFile();
            else
                outputScoresFromConsole();

            stopwatch.Stop();
            Console.WriteLine("Uztruko laiko: {0}", stopwatch.Elapsed);

            Process proc = Process.GetCurrentProcess();
            Console.WriteLine("Naudojama atmintis: {0}", proc.PrivateMemorySize64);
        }

        protected void outputScoresFromFile()
        {
            GradeTable oGoodGradesTrable = new GradeTable();
            GradeTable oBadGradesTrable = new GradeTable();

            Queue<Student> oBadStudentList = new Queue<Student>();

            oGoodGradesTrable.setOutputToFile("kietiakai_studentai10.txt");
            oBadGradesTrable.setOutputToFile("vargsiukai_studentai10.txt");

            oGoodGradesTrable.printHeader();
            oBadGradesTrable.printHeader();

            oStudentList.OrderBy(x => x.getFirstName());

            //oStudentList.Sort((x, y) => string.Compare(x.getFirstName(), y.getFirstName()));

            for (int i = 0; i < oStudentList.Count; i++)
            {
                Student oStudent = oStudentList.Peek();

                double dFinalGrade = oStudent.getFinalGrade(true);
                string[] sRow = new string[] { oStudent.getFirstName(), oStudent.getLastName(), oStudent.getFormattedFinalGrade(true), oStudent.getFormattedFinalGrade(false) };

                if (dFinalGrade < 5.0)
                {
                    oBadStudentList.Enqueue(oStudent);
                    oStudentList.RemoveAt(i);
                }
            }

            foreach (Student oStudent in oStudentList)
            {
                double dFinalGrade = oStudent.getFinalGrade(true);
                string[] sRow = new string[] { oStudent.getFirstName(), oStudent.getLastName(), oStudent.getFormattedFinalGrade(true), oStudent.getFormattedFinalGrade(false) };

                oGoodGradesTrable.printRow(sRow);
            }

            foreach (Student oStudent in oBadStudentList)
            {
                double dFinalGrade = oStudent.getFinalGrade(true);
                string[] sRow = new string[] { oStudent.getFirstName(), oStudent.getLastName(), oStudent.getFormattedFinalGrade(true), oStudent.getFormattedFinalGrade(false) };

                oBadGradesTrable.printRow(sRow);
            }

            oGoodGradesTrable.printLine();
            oGoodGradesTrable.endFile();

            oBadGradesTrable.printLine();
            oBadGradesTrable.endFile();
        }

        protected void outputScoresFromConsole()
        {
            const string sAverage = "v";
            const string sMedian = "m";
            string sInput;

            GradeTable oTable = new GradeTable();

            oTable.setOutputToConsole();

            Boolean isAverage;

            do
            {
                Console.WriteLine("Jei norite skaiciuoti namu darbu vidurki - iveskite 'v', jei norite skaiciuoti mediana - 'm'");
                sInput = Console.ReadLine();
            } while (sInput != sAverage && sInput != sMedian);

            isAverage = (sInput == sAverage);

            oTable.printLine();
            oTable.printRow(new string[] { "Vardas", "Pavarde", isAverage ? "Galutinis(Vid.)" : "Galutinis(Med.)" });
            oTable.printLine();

            foreach (Student oStudent in oStudentList)
            {
                oTable.printRow(new string[] { oStudent.getFirstName(), oStudent.getLastName(), oStudent.getFormattedFinalGrade(isAverage) });
            }

            oTable.printLine();
        }

        protected void inputFromFile()
        {
            const string path = "Studentai100000.txt";
            Boolean bFirstLine = true;
            string line;

            Console.WriteLine("Nuskaitome is failo.");

            System.IO.StreamReader file = null;
            try
            {
                file = new System.IO.StreamReader(path);
                while ((line = file.ReadLine()) != null)
                {
                    if (bFirstLine)
                    {
                        bFirstLine = false;
                        continue;
                    }

                    Student oStudent = inputStudentFromLine(line);

                    oStudentList.Enqueue(oStudent);
                }
            }
            catch
            {
                Console.WriteLine($"Nepavyko nuskaityti failo '{path}'");
            }
            finally
            {
                if (file != null)
                    file.Close();
            }
        }

        protected Student inputStudentFromLine(string sLine)
        {
            sLine = Regex.Replace(sLine, " {2,}", " ");

            string[] sEntries = sLine.Split();
            Student oStudent = new Student();

            oStudent.setFirstName(sEntries[0]);
            oStudent.setLastName(sEntries[1]);

            for (int i = 2; i < sEntries.Length - 2; i++)
            {
                try
                {
                    oStudent.addGrade(sEntries[i]);
                }
                catch
                {
                    Console.WriteLine("Netinkamas namu darbu pazymys: " + sEntries[i]);
                }
            }

            try
            {

                oStudent.setExamGrade(sEntries[sEntries.Length - 1]);
            }
            catch
            {
                Console.WriteLine("Netinkamas egzamino pazymys: " + sEntries[sEntries.Length - 1]);
            }

            return oStudent;
        }

        protected void inputFromConsole()
        {
            string inputString = "";

            do
            {
                Console.WriteLine("Pridedame informacija apie nauja studenta.");

                Student oStudent = inputStudentFromConsole();

                oStudentList.Enqueue(oStudent);

                Console.WriteLine("Studentas pridetas. Jei norite prideti kita studenta - iveskite 't', jei norite paskaiciuoti balus - bet koki kita simboli");
                inputString = Console.ReadLine();
            } while (inputString == "t");
        }

        protected Student inputStudentFromConsole()
        {
            string inputString = "";
            Student oStudent = new Student();

            Console.WriteLine("Iveskite studento varda:");
            oStudent.setFirstName(Console.ReadLine());

            Console.WriteLine("Iveskite studento pavarde:");
            oStudent.setLastName(Console.ReadLine());

            Console.WriteLine("Iveskite studento namu darbu pazymius. Iveskite 'r', kad pazymys butu parinktas atsitiktinai, iveskite 'x', kad baigtume ivedima:");
            inputString = Console.ReadLine();

            // HomeWork grades
            while (inputString != EXIT_STRING)
            {
                try
                {
                    if (inputString == "r")
                        oStudent.addRandomGrade();
                    else
                        oStudent.addGrade(inputString);
                }
                catch
                {
                    Console.WriteLine($"Nepavyko nuskaityti '{inputString}'");
                }

                inputString = Console.ReadLine();
            }

            Console.WriteLine("Iveskite studento egzamino pazymi. Iveskite 'r', kad pazymys butu parinktas atsitiktinai");
            inputString = Console.ReadLine();

            // Exam Grade
            try
            {
                if (inputString == "r")
                    oStudent.setRandomExamGrade();
                else
                    oStudent.setExamGrade(inputString);
            }
            catch
            {
                Console.WriteLine($"Nepavyko nuskaityti '{inputString}'");
            }

            return oStudent;
        }
    }
}
