namespace DogWorkEvaluationSheet
{
    public abstract class DogBase : IDog
    {
        public int Age { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Behavior { get; set; }
        public int Cooperation { get; set; }
        public int Stay_A { get; set; }
        public int Stay_B { get; set; }
        public int Work { get; private set; }

        public DogBase()
        {

        }
        
        public abstract void AddSex(string sex);
        public abstract void AddWork(int work);
        public abstract void AddBehavior(int behavior);
        public abstract void AddCooperation(int cooperation);
        public abstract void AddStay_A(int stay_a);
        public abstract void AddStay_B(int stay_b);

        public abstract void PrintSheet();
        public abstract Statistics GetStatistics();
    }
}
