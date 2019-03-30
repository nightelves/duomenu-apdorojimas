using System;

namespace duomenu_apdorojimas
{
    class Program
    {
        const string EXIT_STRING = "x";

        static void Main(string[] args)
        {
            string sInput;

            do
            {
                try
                {
                    AverageScores oAvg = new AverageScores();

                    oAvg.inputStudents();
                    oAvg.outputScores();

                    Console.WriteLine("Programa baigta. Jei norite iseiti - iveskite 'x', jei norite pakartoti - bet koki kita simboli");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Nenumatyta klaida: " + ex.Message);
                }
                finally
                {
                    sInput = Console.ReadLine();
                }
            } while (sInput != EXIT_STRING);
        }
    }
}
