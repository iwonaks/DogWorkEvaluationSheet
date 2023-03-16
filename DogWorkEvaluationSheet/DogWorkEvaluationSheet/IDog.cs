using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWorkEvaluationSheet
{
    internal interface IDog
    {
        int Age { get;}
        string Name { get;}
        string Owner { get; }
        int Behavior { get; }
        int Cooperation { get; }
        int Stay_a { get; }
        int Stay_b { get; }
        int Work { get; }
        int Sum { get; }
        char GradeOfVictory { get; }
        int Location { get; }

        void AddName(string name);
        void AddOwner(string owner);
        void AddAge(int age);
        void AddSex(string sex);
        void AddStay_a(int stay_a);
        void AddWork(int work);
        void AddBehavior(int behavior);
        void AddCooperation(int cooperation);
        void AddStay_b(int stay_b);

        void GetSumAndGradeOfVictoryList();
        string GetGradeOfVictory(int result);
        List<Dog> MakeListAllDogs();
        IEnumerable<int> LocationFinder(List<Dog> dogs);
        List<Dog> AddLocationToListAllDogs(List<Dog> dogs);
    }
}
