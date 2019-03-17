using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

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

                Console.WriteLine("Studentas pridetas. Jei norite prideti kita studenta - iveskite 'T', jei norite paskaiciuoti balus - bet koki kita simboliu");
                sInput = Console.ReadLine();
            } while (sInput == "T");

            outputScores(oStudentList);
        }

        protected static void outputScores(List<Student> oStudentList)
        {
            string sInput;
            GradeTable oTable = new GradeTable();

            Boolean isAverage;

            Console.WriteLine("Jei norite skaiciuoti vidurki - iveskite 'V', jei norite skaiciuoti mediana - bet koki kita sibmoliu");
            sInput = Console.ReadLine();

            isAverage = (sInput == "V");

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

            Console.WriteLine("Iveskite studento namu darbu pazymius. Iveskite 'r', kad pazymys butu parinktas atsitiktinai, iveskite 'x', kad baigti ivedima:");
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
            averageScores();
        }
    }
}
