using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWorkEvaluationSheet
{
    public abstract class DogBase : IDog
    {       
        public int Age { get; private set; }
        public string Sex { get; private set; }
        public string Name { get; private set; }
        public string Owner { get; private set; }
        public int Behavior { get; private set; }
        public int Cooperation { get; private set; }
        public int Stay_a { get; private set; }
        public int Stay_b { get; private set; }
        public int Work { get; private set; }
        public int Sum { get;}
        public char GradeOfVictory { get; }
        public int Location { get; }

        public DogBase()
        {

        }
        public abstract void AddName(string name);
        public abstract void AddOwner(string owner);
        public abstract void AddAge(int age);
        public abstract void AddSex(string sex);
        public abstract void AddStay_a(int stay_a);
        public abstract void AddWork(int work);
        public abstract void AddBehavior(int behavior);
        public abstract void AddCooperation(int cooperation);
        public abstract void AddStay_b(int stay_b);

        public abstract void GetSumAndGradeOfVictoryList();
        public abstract string GetGradeOfVictory(int result);
        public abstract List<Dog> MakeListAllDogs();
        public abstract IEnumerable<int> LocationFinder(List<Dog> dogs);
        public abstract List<Dog> AddLocationToListAllDogs(List<Dog> dogs);
    }
}
