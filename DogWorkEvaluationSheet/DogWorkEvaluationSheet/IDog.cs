namespace DogWorkEvaluationSheet
{
     interface IDog
    {
        string Name { get; set; }
        
        int Behavior { get; set; }
        int Cooperation { get; set; }
        int Stay_A { get; set; }
        int Stay_B { get; set; }
        int Work { get; set; }
        
        void AddWork(int work);
        void AddBehavior(int behavior);
        void AddCooperation(int cooperation);
        void AddStay_A(int stay_a);
        void AddStay_B(int stay_b);
    }
}