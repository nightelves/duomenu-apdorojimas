using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duomenu_apdorojimas
{
    class GradeTable
    {
        const int tableWidth = 77;

        public void printLine()
        {
            Console.WriteLine(new string('-', tableWidth));
        }

        public void printRow(string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += alignCentre(column, width) + "|";
            }

            Console.WriteLine(row);
        }

        protected string alignCentre(string text, int width)
        {
            text = text.Length > width ? text.Substring(0, width - 3) + "..." : text;

            if (string.IsNullOrEmpty(text))
            {
                return new string(' ', width);
            }
            else
            {
                return text.PadRight(width - (width - text.Length) / 2).PadLeft(width);
            }
        }
    }
}
