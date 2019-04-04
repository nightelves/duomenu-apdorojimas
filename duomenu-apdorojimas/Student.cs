#define USE_LIST

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace duomenu_apdorojimas
{

    class Student
    {
        protected string firstName;

        protected string lastName;

        protected double examGrade;
#if USE_LIST
        protected List<double> grades;
#else
        protected double[] gradesArray;
#endif

        public Student()
        {
#if USE_LIST
            grades = new List<double>();
#else
            gradesArray = null;
#endif

            examGrade = 0;
        }

        public string getFirstName()
        {
            return this.firstName;
        }

        public void setFirstName (string fName)
        {
            this.firstName = fName;
        }

        public string getLastName()
        {
            return this.lastName;
        }

        public void setLastName(string lName)
        {
            this.lastName = lName;
        }

        public void addGrade(double grade)
        {
#if USE_LIST
            grades.Add(grade);
#else
            if (gradesArray == null)
                gradesArray = new double[0];

            Array.Resize(ref gradesArray, gradesArray.Length + 1);

            gradesArray[gradesArray.Length - 1] = grade;

#endif
        }

        public void addGrade(string sGrade)
        {
            double grade = parseGrade(sGrade);

            this.addGrade(grade);
        }

        protected double getRandomGrade()
        {
            Random r = new Random();
            double rInt = r.Next(0, 10);

            return rInt;
        }
        public void addRandomGrade()
        {
            addGrade(getRandomGrade());
        }

        public double getExamGrade()
        {
            return this.examGrade;
        }

        public void setRandomExamGrade()
        {
            setExamGrade(getRandomGrade());
        }

        public void setExamGrade(double grade)
        {
            this.examGrade = grade;
        }

        public void setExamGrade(string sGrade)
        {
            double grade = parseGrade(sGrade);

            this.setExamGrade(grade);
        }

        protected double parseGrade(string sGrade)
        {
            double grade;

            try
            {
                grade = Double.Parse(sGrade);

                if (grade < 0 || grade > 10)
                    throw new ArgumentException();
            }
            catch
            {
                throw;
            }

            return grade;
        }

        protected double getMedian()
        {
#if USE_LIST
            var array = grades.ToArray();
#else
            if (gradesArray == null)
                return 0;

            var array = gradesArray;
#endif
            Array.Sort(array);

            var n = array.Length;

            if (n == 0)
                return 0;

            double median;

            var isOdd = n % 2 != 0;
            if (isOdd)
            {
                median = array[(n + 1) / 2 - 1];
            }
            else
            {
                median = (array[n / 2 - 1] + array[n / 2]) / 2.0d;
            }

            return median;
        }

        protected double getAverage()
        {
#if USE_LIST
            if (grades.Count == 0)
                return 0;

            return grades.Average();
#else
            double sum = 0;
            double avg = 0;

            if (gradesArray == null)
                return 0;

            for (int i = 0; i < gradesArray.Length; i++)
            {
                sum += gradesArray[i];
            }

            avg = sum / gradesArray.Length;
            
            return avg;
#endif
        }

        public double getFinalGrade(Boolean isAverage)
        {
            return 0.3 * (isAverage ? getAverage() : getMedian()) + 0.7 * getExamGrade();
        }

        public string getFormattedFinalGrade(Boolean isAverage)
        {
            return getFinalGrade(isAverage).ToString("0.00");
        }

        public override string ToString()
        {
            String sLine = "";

            sLine += getFirstName() + " ";
            sLine += getLastName() + " ";

            for (int i = 0; i<5; i++)
            {
                sLine += grades[i] + " ";
            }

            sLine += getExamGrade();

            return sLine;
        }

    }
}
