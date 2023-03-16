using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace DogWorkEvaluationSheet
{
    public class Dog : DogBase
    {
        private List<int> ages = new List<int>();
        private List<string> sexs = new List<string>();
        private List<string> names = new List<string>();
        private List<string> owners = new List<string>();
        private List<int> behaviors = new List<int>();
        private List<int> cooperations = new List<int>();
        private List<int> stays_a = new List<int>();
        private List<int> stays_b = new List<int>();
        private List<int> works = new List<int>();

        private List<string> gradesOfVictory = new List<string>();
        private List<int> sumdegrees = new List<int>();

        public Stack<int> sumStack = new Stack<int>();

        public int Age { get; set; }
        public string Sex { get; set; }
        public string Name { get; set; }
        public string Owner { get; set; }
        public int Behavior { get; set; }
        public int Cooperation { get; set; }
        public int Stay_a { get; set; }
        public int Stay_b { get; set; }
        public int Work { get; set; }
        public int Sum { get; set; }
        public string GradeOfVictory { get; set; }

        public int Location { get; set; }

       


        public Dog()
        {

        }
        
        public override void AddName(string name)
        {
            foreach (string item in names)
            {
                if (item == name)
                {
                    throw new Exception("Nie może być dwóch psów o tym samym imieniu, popraw.");
                }
                else
                {
                    continue;
                }
            }
            names.Add(name);
        }
        public override void AddAge(int age)
        {
            ages.Add(age);
        }

        public override void AddOwner(string owner)
        {
            owners.Add(owner);
        }
        public override void AddSex(string sex)
        {
            if (sex=="F" || sex=="M")
            {
                sexs.Add(sex);
            }
            else
            {
                throw new Exception("Błędne informacje, F - suka, M - samiec.");
            }
        }

        public override void AddBehavior(int behavior)
        {
            int behaviorvalue = behavior*6;
            behaviors.Add(behaviorvalue);

            sumStack.Push(behaviorvalue);
        }
        public override void AddCooperation(int cooperation)
        {
            int cooperationvalue = cooperation*4;
            cooperations.Add(cooperationvalue);
            sumStack.Push(cooperationvalue);
        }

        public override void AddStay_a(int stay_a)
        {
            int stay_avalue = stay_a*5;
            stays_a.Add(stay_avalue);
            sumStack.Push(stay_avalue);
        }
        public override void AddStay_b(int stay_b)
        {
            int stay_bvalue = stay_b*3;
            stays_b.Add(stay_bvalue);
            sumStack.Push(stay_bvalue);
        }
        public override void AddWork(int work)
        {
            int workvalue = work*10;
            works.Add(workvalue);
            sumStack.Push(workvalue);
        }
        public override void GetSumAndGradeOfVictoryList()
        {
            int result = sumStack.Sum();
            sumdegrees.Add(result);

            string result2 = GetGradeOfVictory(result);
            gradesOfVictory.Add(result2);
        }

        public override string GetGradeOfVictory(int result)
        {
            switch (result)
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

        public override List<Dog> MakeListAllDogs()
        {
            List<Dog> dogs = new List<Dog>();

            for (int i = 0; i < names.Count; i++)
            {
                dogs.Add(new Dog { Name = names[i], Owner = owners[i], Age = ages[i], Sex = sexs[i], Work = works[i], Cooperation = cooperations[i], Behavior = behaviors[i], Stay_a = stays_a[i], Stay_b = stays_b[i], Sum = sumdegrees[i], GradeOfVictory = gradesOfVictory[i] });
            }
            return dogs;   
        }

        public override List<Dog> AddLocationToListAllDogs(List<Dog> dogs)
        {
            dogs.Sort(DogComparer);

            IEnumerable<int> location = LocationFinder(dogs);

            List<int> locationsList = location.ToList();

            for (int i = 0; i < dogs.Count; i++)
            {
                dogs[i].Location = locationsList[i];
            }

            foreach (var dog in dogs)
            {
                Console.WriteLine("Wykaz psów wg zajętego miejsca:");
                Console.WriteLine("Lokata: {0}, Imię psa: {1}, Wiek: {2}, Płeć: {3}, Suma punktów: {4}, Dyplom stopnia: {5}", dog.Location, dog.Name, dog.Age, dog.Sex, dog.Sum, dog.GradeOfVictory);
                Console.WriteLine("---------------------------------------------------------------------------------");
            }
            return dogs;
        }

        private static int DogComparer(Dog a, Dog b)
        {
            int result = b.Sum.CompareTo(a.Sum);
            if (result == 0)
            {
                result = a.Age.CompareTo(b.Age);
                if (result == 0)
                {
                    result = a.Sex.CompareTo(b.Sex);
                }
            }
            return result;
        }

        public override IEnumerable<int> LocationFinder(List<Dog> dogs)
        {
            int location = 1;
            int numberLocation = 1;

            int previousSum = int.MaxValue;
            int previousAge = int.MaxValue;
            string previousSex = "";

            foreach (var dog in dogs)
            {
                if (dog.Sum == previousSum && dog.Age == previousAge && dog.Sex == previousSex)
                {
                    location--;
                    
                }
                else
                {
                    if (location!=numberLocation)
                    {
                        location= numberLocation;
                    }
                }
                yield return location;
                previousSum = dog.Sum;
                previousAge = dog.Age;
                previousSex = dog.Sex;
                location++;
                numberLocation++;
               
            }
        }
    }
}


