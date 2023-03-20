namespace DogWorkEvaluationSheet
{
    public class Statistics
    {

        public int Sum { get; set; }
        public string GradeOfVictory { get; set; }

        public Statistics()
        {
            int Sum = 0;
            string GradeOfVictory = "";

        }
       
        public void Add(int grade)
        {
            Sum+=grade;
            GradeOfVictory=GetGradeOfVictory(Sum);
        }

        public string GetGradeOfVictory(int Sum)
        {
            switch (Sum)
            {
                case var a when a >= 90:
                    return "I";

                case var a when a  >= 70:
                    return "II";

                case var a when a  >= 60:
                    return "III";

                default:
                    return "nie przyznano";
            }
        }


    }
}

