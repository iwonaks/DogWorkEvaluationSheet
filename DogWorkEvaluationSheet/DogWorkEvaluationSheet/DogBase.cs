using System.Security.Cryptography;

namespace DogWorkEvaluationSheet
{
    public abstract class DogBase : IDog
    {
        public int Age { get; set; } = default;
        public string Sex { get; set; } =string.Empty;
        public string Name { get; set; } = string.Empty;
        public string Owner { get; set; } = string.Empty;
        public int Behavior { get; set; } = default;
        public int Cooperation { get; set; } = default;
        public int Stay_A { get; set; } = default;
        public int Stay_B { get; set; } = default;
        public int Work { get; set; } = default;
       
        public abstract void AddWork(int work);
        public abstract void AddBehavior(int behavior);
        public abstract void AddCooperation(int cooperation);
        public abstract void AddStay_A(int stay_a);
        public abstract void AddStay_B(int stay_b);
        public abstract void PrintSheet();
        public abstract Statistics GetStatistics();
    }
}
