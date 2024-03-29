namespace DogWorkEvaluationSheet.Tests
{
    public class Tests
    {
        [Test]
        public void GetGradeOfVictoryTest1()
        {
            var stat = new Statistics
            {
                Sum =59
            };

            int result = stat.Sum;

            var grade = Statistics.GetGradeOfVictory(result);

            Assert.IsTrue(grade=="nie przyznano");
            Assert.IsFalse(grade=="I");
            Assert.IsFalse(grade=="II");
            Assert.IsFalse(grade=="III");
        }
        [Test]
        public void GetGradeOfVictoryTest2()
        {
            var stat = new Statistics();

            stat.Sum =60;

            int result = stat.Sum;

            var grade = Statistics.GetGradeOfVictory(result);

            Assert.IsFalse(grade=="nie przyznano");
            Assert.IsFalse(grade=="I");
            Assert.IsFalse(grade=="II");
            Assert.IsTrue(grade=="III");
        }
        [Test]
        public void GetGradeOfVictoryTest3()
        {
            var stat = new Statistics
            {
                Sum =70
            };

            int result = stat.Sum;

            var grade = Statistics.GetGradeOfVictory(result);

            Assert.IsFalse(grade=="nie przyznano");
            Assert.IsFalse(grade=="I");
            Assert.IsTrue(grade=="II");
            Assert.IsFalse(grade=="III");
        }
        [Test]
        public void GetGradeOfVictoryTest4()
        {
            var stat = new Statistics();

            stat.Sum =90;

            int result = stat.Sum;

            var grade = Statistics.GetGradeOfVictory(result);

            Assert.IsFalse(grade=="nie przyznano");
            Assert.IsTrue(grade=="I");
            Assert.IsFalse(grade=="II");
            Assert.IsFalse(grade=="III");
        }
        [Test]
        public void AddStatistics()
        {
            var stat = new Statistics();

            int Sum = 24;
            string GradeOfVictory = "nie przyznano";
            int grade1 = 7;
            int grade2 = 8;
            int grade3 = 9;

            stat.Add(grade1);
            stat.Add(grade2);
            stat.Add(grade3);
            
            Assert.That(stat.Sum, Is.EqualTo(Sum));
            Assert.That(stat.GradeOfVictory, Is.EqualTo(GradeOfVictory));
                
        }
    }
}