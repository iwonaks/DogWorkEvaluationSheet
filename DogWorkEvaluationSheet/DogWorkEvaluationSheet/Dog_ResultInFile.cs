using Microsoft.VisualBasic.FileIO;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DogWorkEvaluationSheet
{
    public class Dog_ResultInFile : DogBase
    {
        public delegate void FeedbakToMakeSheet(Object sender, EventArgs args);

        public event FeedbakToMakeSheet? FileWithSheetSave;
        public event FeedbakToMakeSheet? FileWithGradesSave;

        public Dog_ResultInFile()
        {

        }
        public override void AddSex(string sex)
        {
            if (sex=="F" || sex=="M")
            {
                Sex = sex;
            }
            else
            {
                throw new Exception("Błędne informacje, F - suka, M - samiec.");
            }
        }
        public override void AddBehavior(int grade)
        {
            Behavior = grade*6;
            using (var writer = File.AppendText($"{Name}_grades.txt"))
            {
                writer.WriteLine(Behavior);
            }

            EventFileWithGrades();
        }
        public override void AddCooperation(int grade)
        {
            Cooperation = grade*4;
            using (var writer = File.AppendText($"{Name}_grades.txt"))
            {
                writer.WriteLine(Cooperation);
            }

            EventFileWithGrades();
        }

        public override void AddStay_A(int grade)
        {
            this.Stay_A = grade*5;
            using (var writer = File.AppendText($"{Name}_grades.txt"))
            {
                writer.WriteLine(Stay_A);
            }

            EventFileWithGrades();
        }

        public override void AddStay_B(int grade)
        {
            this.Stay_B = grade*3;
            using (var writer = File.AppendText($"{Name}_grades.txt"))
            {
                writer.WriteLine(Stay_B);
            }

            EventFileWithGrades();
        }

        public override void AddWork(int grade)
        {
            this.Work = grade*10;

            File.WriteAllText($"{Name}_grades.txt", string.Empty);

            using (var writer = File.AppendText($"{Name}_grades.txt"))
            {
                writer.WriteLine(Work);
            }

            EventFileWithGrades();
        }

        private List<int> ReadGradesFromFile()
        {
            var grades = new List<int>();

            if (File.Exists($"{Name}_grades.txt"))
            {
                using (var reader = File.OpenText($"{Name}_grades.txt"))
                {
                    var line = reader.ReadLine();

                    while (line!=null)
                    {
                        var lineInt = int.Parse(line);
                        grades.Add(lineInt);
                        line = reader.ReadLine();
                    }
                }
            }
            return grades;
        }

        public Statistics GetStatistics(List<int> grades)
        {
            var statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.Add(grade);
            }
            return statistics;
        }

        public override Statistics GetStatistics()
        {
            var gradesInFile = ReadGradesFromFile();
            var statistics = new Statistics();
            foreach (var grade in gradesInFile)
            {
                statistics.Add(grade);
            }
            return statistics;
        }

        public override void PrintSheet()
        {
            var statisticsDog = GetStatistics();

            var fileSheetDog = $"{Name}_sheet.txt";

            string time = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            using var writer = File.AppendText(fileSheetDog);
            writer.WriteLine($"Imię psa: {Name}");
            writer.WriteLine($"Wiek psa: {Age}");
            writer.WriteLine($"Płeć psa: {Sex}");
            writer.WriteLine($"Właściciel psa: {Owner}");
            writer.WriteLine();

            writer.WriteLine("WYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:");
            writer.WriteLine($"Współpraca: {Cooperation}");
            writer.WriteLine($"Zachowanie przy zwierzynie: {Behavior}");
            writer.WriteLine($"Praca na otoku: {Work}");
            writer.WriteLine($"Odłożenie luzem: {Stay_A}");
            writer.WriteLine($"Odłożenie na uwięzi: {Stay_B}");
            writer.WriteLine();

            writer.WriteLine("PODSUMOWANIE:");
            writer.WriteLine($"Suma uzyskanych punktów w konkursie: {statisticsDog.Sum}");
            writer.WriteLine($"Dyplom stopnia: {statisticsDog.GradeOfVictory} ");
            writer.WriteLine("Lokata: .............(uzupełnia sędzia)");
            writer.WriteLine();

            writer.WriteLine("Aktualny czas:" + time);
            writer.WriteLine($"----------------------------------------");

            if (FileWithSheetSave!=null)
            {
                FileWithSheetSave(this, new EventArgs());
            }
        }
        private void EventFileWithGrades()
        {
            if (FileWithGradesSave!= null)
            {
                FileWithGradesSave(this, new EventArgs());
            }
        }
    }
}