namespace DogWorkEvaluationSheet
{
    public class Statistics
    { 
        
        public int Sum { get; set; }
        public string GradeOfVictory { get; set; }
        
        public Statistics()
        {
            Sum = 0;
            GradeOfVictory = "";
        }

        public void Add(int grade)
        {
            Sum+=grade;
            GradeOfVictory=GetGradeOfVictory(Sum);
        }
        
        public static string GetGradeOfVictory(int Sum)
        {
            return Sum switch
            {
                var a when a >= 90 => "I",
                var a when a  >= 70 => "II",
                var a when a  >= 60 => "III",
                _ => "nie przyznano",
            };
        }
    }
}