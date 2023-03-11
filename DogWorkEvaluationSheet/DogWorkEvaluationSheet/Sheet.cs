using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DogWorkEvaluationSheet
{
    public class Sheet 
    {
        public Sheet()
        {
         
        }

        public delegate void FeedbakToMakeSheet(Object sender, EventArgs args);
        public event FeedbakToMakeSheet FileSaveForDogs;
        public event FeedbakToMakeSheet FileSaveForJudge;

        public void PrintSheet(List<Dog> dogs)
        {
            foreach (var dog in dogs)
            {
                var fileSheetDog = $"{dog.Name}.txt";
                var fileSheetAllDogs = "fileSheetAllDogs.txt";
                string time = DateTime.Now.ToString("dd-MM-yyyy HH:mm:ss");

                using (var writer = File.AppendText(fileSheetDog))
                {
                    writer.WriteLine($"Imię psa: {dog.Name}");
                    writer.WriteLine($"Wiek psa: {dog.Age}");
                    writer.WriteLine($"Płeć psa: {dog.Sex}");
                    writer.WriteLine($"Właściciel psa: {dog.Owner}");

                    writer.WriteLine("WYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:");
                    writer.WriteLine($"Współpraca: {dog.Cooperation}");
                    writer.WriteLine($"Zachowanie przy zwierzynie: {dog.Behavior}");
                    writer.WriteLine($"Praca na otoku: {dog.Work}");
                    writer.WriteLine($"Odłożenie luzem: {dog.Stay_a}");
                    writer.WriteLine($"Odłożenie na uwięzi: {dog.Stay_b}");

                    writer.WriteLine("PODSUMOWANIE:");
                    writer.WriteLine($"Suma uzyskanych punktów w konkursie: {dog.Sum}");
                    writer.WriteLine($"Lokata: {dog.Location}");
                    writer.WriteLine($"Dyplom stopnia: {dog.GradeOfVictory}");

                    writer.WriteLine("Aktualny czas:" + time);
                    writer.WriteLine($"----------------------------------------");
                }

                if(FileSaveForDogs!= null)
                {
                    FileSaveForDogs(this, new EventArgs());
                }

                using (var writer = File.AppendText(fileSheetAllDogs))
                {
                    writer.WriteLine($"Imię psa: {dog.Name}");
                    writer.WriteLine($"Wiek psa: {dog.Age}");
                    writer.WriteLine($"Płeć psa: {dog.Sex}");
                    writer.WriteLine($"Właściciel psa: {dog.Owner}");

                    writer.WriteLine("WYNIKI W POSZCZEGÓLNYCH KONKURENCJACH:");
                    writer.WriteLine($"Współpraca: {dog.Cooperation}");
                    writer.WriteLine($"Zachowanie przy zwierzynie: {dog.Behavior}");
                    writer.WriteLine($"Praca na otoku: {dog.Work}");
                    writer.WriteLine($"Odłożenie luzem: {dog.Stay_a}");
                    writer.WriteLine($"Odłożenie na uwięzi: {dog.Stay_b}");

                    writer.WriteLine("PODSUMOWANIE:");
                    writer.WriteLine($"Suma uzyskanych punktów w konkursie: {dog.Sum}");
                    writer.WriteLine($"Lokata: {dog.Location}");
                    writer.WriteLine($"Dyplom stopnia: {dog.GradeOfVictory}");

                    writer.WriteLine("Aktualny czas:" + time);
                    writer.WriteLine($"----------------------------------------");
                }

                if (FileSaveForJudge!= null)
                {
                    FileSaveForJudge(this, new EventArgs());
                }
            }
        }
    }
}
