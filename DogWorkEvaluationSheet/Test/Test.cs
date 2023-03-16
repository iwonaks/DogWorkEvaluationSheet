namespace DogWorkEvaluationSheet
{
    public class Tests
    {
        [Test]
        public string GetGradeOfVictory(int result)
        {
            
            //Assert.IsTrue(GetGradeOfVictory(result)=="nie przyznano");
            //Assert.IsFalse(GetGradeOfVictory(result)=="I");
            //Assert.IsFalse(GetGradeOfVictory(result)=="II");
            //Assert.IsFalse(GetGradeOfVictory(result)=="III");

            Assert.IsFalse(GetGradeOfVictory(61)=="nie przyznano");
            Assert.IsFalse(GetGradeOfVictory(61)=="I");
            Assert.IsFalse(GetGradeOfVictory(61)=="II");
            Assert.IsTrue(GetGradeOfVictory(61)=="III");

            //Assert.IsFalse(GetGradeOfVictory(result3)=="nie przyznano");
            //Assert.IsFalse(GetGradeOfVictory(result3)=="I");
            //Assert.IsTrue(GetGradeOfVictory(result3)=="II");
            //Assert.IsFalse(GetGradeOfVictory(result3)=="III");

            //Assert.IsFalse(GetGradeOfVictory(result4)=="nie przyznano");
            //Assert.IsTrue(GetGradeOfVictory(result4)=="I");
            //Assert.IsFalse(GetGradeOfVictory(result4)=="II");
            //Assert.IsFalse(GetGradeOfVictory(result4)=="III");
            
        }
    }
}