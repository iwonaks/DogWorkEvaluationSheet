namespace DogWorkEvaluationSheet
{
    public class Dog : DogBase
    {
        public List<int> grades = new List<int>();

        public delegate void FeedbakToMakeSheet(Object sender, EventArgs args);

        public event FeedbakToMakeSheet FileSave;

        public int Age { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Behavior { get; set; }
        public int Cooperation { get; set; }
        public int Stay_A { get; set; }
        public int Stay_B { get; set; }
        public int Work { get; set; }

        public Dog()
        {

        }
        public override void AddSex(string sex)
        {

            if (sex=="F" || sex=="M")
            {
                this.Sex = sex;
            }
            else
            {
                throw new Exception("Błędne informacje, F - suka, M - samiec.");
            }
        }
        public override void AddBehavior(int grade)
        {
            this.Behavior = grade*6;
            grades.Add(Behavior);
        }

        public override void AddCooperation(int grade)
        {
            this.Cooperation = grade*4;
            grades.Add(Cooperation);
        }

        public override void AddStay_A(int grade)
        {
            this.Stay_A = grade*5;
            grades.Add(Stay_A);
        }

        public override void AddStay_B(int grade)
        {
            this.Stay_B = grade*3;
            grades.Add(Stay_B);
        }

        public override void AddWork(int grade)
        {
            this.Work = grade*10;
            grades.Add(Work);
        }

        public override Statistics GetStatistics()
        {
            var statistics = new Statistics();
            foreach (var grade in grades)
            {
                statistics.Add(grade);
            }
            return statistics;
        }

        public override void PrintSheet()
        {
            var statisticsDog = GetStatistics();

            var fileSheetDog = $"{Name}.txt";

            string time = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

            using var writer = File.AppendText(fileSheetDog);
            writer.WriteLine($"Imię psa: {Name}");
            writer.WriteLine($"Wiek psa: {Age}");
            writer.WriteLine($"Płeć psa: {Sex}");
            writer.WriteLine($"Właściciel psa: {Owner}");

            writer.WriteLine("WYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:");
            writer.WriteLine($"Współpraca: {Cooperation}");
            writer.WriteLine($"Zachowanie przy zwierzynie: {Behavior}");
            writer.WriteLine($"Praca na otoku: {Work}");
            writer.WriteLine($"Odłożenie luzem: {Stay_B}");
            writer.WriteLine($"Odłożenie na uwięzi: {Stay_B}");

            writer.WriteLine("PODSUMOWANIE:");
            writer.WriteLine($"Suma uzyskanych punktów w konkursie:{statisticsDog.Sum}");
            writer.WriteLine("Lokata: .............(uzupełnia sędzia)");
            writer.WriteLine($"Dyplom stopnia: {statisticsDog.GradeOfVictory} ");

            writer.WriteLine("Aktualny czas:" + time);
            writer.WriteLine($"----------------------------------------");
            
            if (FileSave!=null)
            {
                FileSave(this, new EventArgs());
            }

        }
    }
}


