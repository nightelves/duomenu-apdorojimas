using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace duomenu_apdorojimas
{

    class Student
    {
        protected string firstName;

        protected string lastName;

        protected List<int> grades;

        protected double examGrade;

        public Student()
        {
            grades = new List<int>();

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

        public void addGrade(int grade)
        {
            grades.Add(grade);
        }

        public void addGrade(string sGrade)
        {
            int grade = parseGrade(sGrade);

            this.addGrade(grade);
        }

        protected int getRandomGrade()
        {
            Random r = new Random();
            int rInt = r.Next(0, 10);

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

        public void setExamGrade(int grade)
        {
            this.examGrade = grade;
        }

        public void setExamGrade(string sGrade)
        {
            int grade = parseGrade(sGrade);

            this.setExamGrade(grade);
        }

        protected int parseGrade(string sGrade)
        {
            int grade;

            try
            {
                grade = Int32.Parse(sGrade);

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
            var array = grades.ToArray();

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
            if (grades.Count == 0)
                return 0;

            return grades.Average();
        }

        protected double getFinalGrade(Boolean isAverage)
        {
            return 0.3 * (isAverage ? getAverage() : getMedian()) + 0.7 * getExamGrade();
        }

        public string getFormattedFinalGrade(Boolean isAverage)
        {
            return getFinalGrade(isAverage).ToString("0.00");
        }
    }
}
