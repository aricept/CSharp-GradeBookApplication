using System;
using System.Linq;
using GradeBook.Enums;

namespace GradeBook.GradeBooks
{
    public class RankedGradeBook : BaseGradeBook
    {
        public RankedGradeBook(string name) : base(name)
        {
            this.Type = Enums.GradeBookType.Ranked;
        }

        public override char GetLetterGrade(double averageGrade)
        {
            if(Students.Count < 5)
                throw new InvalidOperationException("Requires at least 5 students to do ranked grading.");
            
            var threshold = (int)Math.Ceiling(Students.Count * 0.2);
            var grades = Students.OrderByDescending(e => e.AverageGrade).Select(e => e.AverageGrade).ToList();

            if(grades[threshold-1] <= averageGrade)
                return 'A';
            else if(grades[(threshold*2)-1] <= averageGrade)
                return 'B';
            else if(grades[(threshold*3)-1] <= averageGrade)
                return 'C';
            else if(grades[(threshold*4)-1] <= averageGrade)
                return 'D';
            else
                return 'F';
        }

        // public override bool Equals(object obj)
        // {
        //     return base.Equals(obj);
        // }

        // public override int GetHashCode()
        // {
        //     return base.GetHashCode();
        // }

        // public override string ToString()
        // {
        //     return base.ToString();
        // }

        // public override double GetGPA(char letterGrade, StudentType studentType)
        // {
        //     return base.GetGPA(letterGrade, studentType);
        // }

        public override void CalculateStatistics()
        {
            if(Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStatistics();
        }

        public override void CalculateStudentStatistics(string name)
        {
            if(Students.Count < 5)
            {
                Console.Write("Ranked grading requires at least 5 students with grades in order to properly calculate a student's overall grade.");
                return;
            }
            base.CalculateStudentStatistics(name);
        }

        public override 
    }
}