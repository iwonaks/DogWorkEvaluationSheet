using System.Runtime.CompilerServices;

namespace DogWorkEvaluationSheet
{
    public class Dog_ResultSymulation : DogBase
    {
        public List<int> grades = new List<int>();
       
        public new string? Name { get; set; }
        public new int Behavior { get; set; }
        public new int Cooperation { get; set; }
        public new int Stay_A { get; set; }
        public new int Stay_B { get; set; }
        public new int Work { get; set; }

        public Dog_ResultSymulation()
        {

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

            Console.WriteLine($"Imię psa: {Name}");
            Console.WriteLine();
            Console.WriteLine("WYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:");
            Console.WriteLine($"Współpraca: {Cooperation}");
            Console.WriteLine($"Zachowanie przy zwierzynie: {Behavior}");
            Console.WriteLine($"Praca na otoku: {Work}");
            Console.WriteLine($"Odłożenie luzem: {Stay_A}");
            Console.WriteLine($"Odłożenie na uwięzi: {Stay_B}");
            Console.WriteLine();
            Console.WriteLine("PODSUMOWANIE:");
            Console.WriteLine($"Suma uzyskanych punktów w konkursie:{statisticsDog.Sum}");
            Console.WriteLine($"Dyplom stopnia: {statisticsDog.GradeOfVictory} ");
            Console.WriteLine("Lokata: .............(uzupełnia sędzia)");
        }

        public override void AddSex(string sex)
        {
            throw new NotImplementedException();
        }
    }
}