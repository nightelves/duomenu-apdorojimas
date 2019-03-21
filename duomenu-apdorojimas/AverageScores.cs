using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duomenu_apdorojimas
{
    class AverageScores
    {
        const Boolean INPUT_FROM_FILE = false;
        const string EXIT_STRING = "x";

        protected List<Student> oStudentList;

        public AverageScores()
        {
            oStudentList = new List<Student>();
        }

        public void inputStudents()
        {
            if (INPUT_FROM_FILE)
                inputFromFile();
            else
                inputFromConsole();
        }

        public void outputScores()
        {
            if (INPUT_FROM_FILE)
                outputScoresFromFile();
            else
                outputScoresFromConsole();
        }

        protected void outputScoresFromFile()
        {
            GradeTable oTable = new GradeTable();

            oTable.printLine();
        }

        protected void outputScoresFromConsole()
        {
            const string sAverage = "v";
            const string sMedian = "m";
            string sInput;

            GradeTable oTable = new GradeTable();

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

        }

        protected Student inputStudentFromLine(string sLine)
        {
            string[] sEntries = sLine.Split();

            Student oStudent = new Student();

            return oStudent;
        }

        protected void inputFromConsole()
        {
            string inputString = "";

            do
            {
                Console.WriteLine("Pridedame informacija apie nauja studenta.");

                Student oStudent = inputStudentFromConsole();

                oStudentList.Add(oStudent);

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
