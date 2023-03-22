namespace DogWorkEvaluationSheet
{
    internal interface IDog
    {
        int Age { get; }
        string Name { get; }
        string Owner { get; }
        int Behavior { get; }
        int Cooperation { get; }
        int Stay_A { get; }
        int Stay_B { get; }
        int Work { get; }

        void AddSex(string sex);
        
        void AddWork(int work);
        void AddBehavior(int behavior);
        void AddCooperation(int cooperation);
        void AddStay_A(int stay_a);
        void AddStay_B(int stay_b);
    }
}