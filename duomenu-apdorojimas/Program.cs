using System;
using System.Collections.Generic;

namespace duomenu_apdorojimas
{
    class Program
    {
        const string exitString = "x";
        
        public static void averageScores()
        {
            String sInput;

            List<Student> oStudentList = new List<Student>();
            
            Student oStudent;

            do
            {
                Console.WriteLine("Pridedame informacija apie nauja studenta.");

                oStudent = inputStudent();

                oStudentList.Add(oStudent);

                Console.WriteLine("Studentas pridetas. Jei norite prideti kita studenta - iveskite 't', jei norite paskaiciuoti balus - bet koki kita simboli");
                sInput = Console.ReadLine();
            } while (sInput == "t");

            outputScores(oStudentList);
        }

        protected static void outputScores(List<Student> oStudentList)
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

        protected static Student inputStudent()
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
            while (inputString != exitString)
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
                        
            Console.WriteLine("Iveskite studento egzamino pazymi. Iveskite 'r', kad pazymys butu parinktas atsitiktinai, iveskite 'x', kad praleisti:");
            inputString = Console.ReadLine();

            // Exam Grades
            while(inputString != exitString)
            {
                try
                {
                    if (inputString == "r")
                        oStudent.setRandomExamGrade();
                    else
                        oStudent.setExamGrade(inputString);

                    break;
                }
                catch
                {
                    Console.WriteLine($"Nepavyko nuskaityti '{inputString}'");
                }

                inputString = Console.ReadLine();
            }


            return oStudent;
        }

        static void Main(string[] args)
        {
            string sInput;

            do
            {
                averageScores();

                Console.WriteLine("Programa baigta. Jei norite iseiti - iveskite 'x', jei norite pakartoti - bet koki kita simboli");

                sInput = Console.ReadLine();
            } while (sInput != exitString);
        }
    }
}
