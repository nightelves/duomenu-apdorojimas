using System;
using System.IO;

namespace duomenu_apdorojimas
{
    class GradeTable
    {
        protected enum OUTPUT_TARGET { FILE, CONSOLE };

        const int tableWidth = 77;
        protected OUTPUT_TARGET eOutputTarget;
        protected StreamWriter oFileWriter;

        public GradeTable()
        {
            eOutputTarget = OUTPUT_TARGET.CONSOLE;
        }

        public void setOutputToFile(string sFile)
        {
            oFileWriter = new StreamWriter(sFile);

            setOutputTarget(OUTPUT_TARGET.FILE);
        }

        public void setOutputToConsole()
        {
            setOutputTarget(OUTPUT_TARGET.CONSOLE);
        }

        public void endFile()
        {
            if (oFileWriter != null)
            {
                oFileWriter.Close();
                oFileWriter = null;
            }
        }

        private void setOutputTarget(OUTPUT_TARGET eTarget)
        {
            this.eOutputTarget = eTarget;
        }

        public void printLine()
        {
            printRow(new string('-', tableWidth));
        }

        public void printRow(string[] columns)
        {
            int width = (tableWidth - columns.Length) / columns.Length;
            string row = "|";

            foreach (string column in columns)
            {
                row += alignCentre(column, width) + "|";
            }
            
            printRow(row);
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

        protected void printRow(string sLine)
        {
            switch (eOutputTarget)
            {
                case OUTPUT_TARGET.FILE:
                    oFileWriter.WriteLine(sLine);
                    break;
                case OUTPUT_TARGET.CONSOLE:
                    Console.WriteLine(sLine);
                    break;
            }
        }
    }
}
