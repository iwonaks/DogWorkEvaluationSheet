namespace DogWorkEvaluationSheet.Tests
{
    public class Tests
    {
        [Test]
        public void GetGradeOfVictoryTest()
        {
            var dog = new Dog();

            dog.Sum =61;

            int result = dog.Sum;

            var grade = dog.GetGradeOfVictory(result);

            Assert.IsFalse(grade=="nie przyznano");
            Assert.IsFalse(grade=="I");
            Assert.IsFalse(grade=="II");
            Assert.IsTrue(grade=="III");
        }

        [Test]
        public void GetGradeOfVictoryTest2()
        {
            var dog = new Dog();

            dog.Sum = 59;
            int result = dog.Sum;

            var grade = dog.GetGradeOfVictory(result);

            Assert.IsTrue(grade=="nie przyznano");
            Assert.IsFalse(grade=="I");
            Assert.IsFalse(grade=="II");
            Assert.IsFalse(grade=="III");
        }

        [Test]
        public void GetGradeOfVictoryTest3()
        {
            var dog = new Dog();

            dog.Sum = 81;
            int result = dog.Sum;

            var grade = dog.GetGradeOfVictory(result);

            Assert.IsFalse(grade=="nie przyznano");
            Assert.IsFalse(grade=="I");
            Assert.IsTrue(grade=="II");
            Assert.IsFalse(grade=="III");
        }

        [Test]
        public void GetGradeOfVictoryTest4()
        {
            var dog = new Dog();

            dog.Sum = 91;
            int result = dog.Sum;

            var grade = dog.GetGradeOfVictory(result);

            Assert.IsFalse(grade=="nie przyznano");
            Assert.IsTrue(grade=="I");
            Assert.IsFalse(grade=="II");
            Assert.IsFalse(grade=="III");
        }
    }
}