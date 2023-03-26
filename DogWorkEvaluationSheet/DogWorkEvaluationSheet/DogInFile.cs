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
    public class DogInFile : DogBase
    {
        public delegate void FeedbakToMakeSheet(Object sender, EventArgs args);

        public event FeedbakToMakeSheet? FileWithSheetSave;
        public event FeedbakToMakeSheet? FileWithGradesSave;

        public DogInFile(string name)
        {
            this.Name = name;
        }
        public DogInFile()
        {
            
        }

        public void AddSex(string sex)
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

            File.WriteAllText($"{Name}_grades.txt", string.Empty);

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

            string lines =

            $"\tImię psa: {Name}\n" +
            $"\tWiek psa: {Age}\n" +
            $"\tPłeć psa: {Sex}\n" +
            $"\tWłaściciel psa: {Owner}\n" +
            "\n" +
            "\tWYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:\n" +
            $"\tWspółpraca: {Cooperation}\n" +
            $"\tZachowanie przy zwierzynie: {Behavior}\n" +
            $"\tPraca na otoku: {Work}\n" +
            $"\tOdłożenie luzem: {Stay_A}\n" +
            $"\tOdłożenie na uwięzi: {Stay_B}\n" +
            "\n" +
            "\tPODSUMOWANIE:\n" +
            $"\tSuma uzyskanych punktów w konkursie: {statisticsDog.Sum}\n" +
            $"\tDyplom stopnia: {statisticsDog.GradeOfVictory}\n" +
            "\tLokata: .............(uzupełnia sędzia)\n" +
            "\n" +
            $"\tAktualny czas: {time}\n" +
            "\tt------------------\n";

            Console.WriteLine(lines);
            writer.WriteLine(lines);
            
            if (FileWithSheetSave!=null)
            {
                FileWithSheetSave(this, new EventArgs());
            }
        }

        public void PrintSheetFromFile()
        {
            var statisticsDog = GetStatistics();

            var grades = ReadGradesFromFile();

            Console.WriteLine($"\tImię psa: {Name}\n" +
            $"\n" +
            "\tWYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:\n" +
            $"\tWspółpraca: {grades[0]}\n" +
            $"\tZachowanie przy zwierzynie: {grades[1]}\n" +
            $"\tPraca na otoku: {grades[2]}\n" +
            $"\tOdłożenie luzem: {grades[3]}\n" +
            $"\tOdłożenie na uwięzi: {grades[4]}\n" +
            $"\n" +
            "\tPODSUMOWANIE:\n" +
            $"\tSuma uzyskanych punktów w konkursie: {statisticsDog.Sum}\n" +
            $"\tDyplom stopnia: {statisticsDog.GradeOfVictory}\n" +
            "\tLokata: .............(uzupełnia sędzia)");
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