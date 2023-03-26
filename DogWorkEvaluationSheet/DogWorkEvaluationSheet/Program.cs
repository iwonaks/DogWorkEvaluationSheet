using DogWorkEvaluationSheet;
using System.IO;
using System.Runtime.CompilerServices;

Console.WriteLine("\tWitaj w programie genrującym kartę z wynikami przeprowadzonego konkursu w kategorii PSY TROPIĄCE");

while (true)
{
    Console.WriteLine("\t------------------\n" +
    "\tCo chcesz zrobić?:\n" +
    "\t1 - Stworzyć Kartę Konkursową z wynikami psa i zapisać ją w pliku.\n" +
    "\t2 - Zobaczyć statystyki psa na ekranie, bez zapisu do pliku.\n" +
    "\t3 - Odczytać statystyki psa o podanym imieniu.\n" +
    "\tQ - Zamyka program.");

    string input = CheckIsNullOrEmpty().ToUpper();

    switch (input)
    {
        case "1":
            {
                DogInFile dog = new DogInFile();

                dog.FileWithSheetSave +=Sheet_FileSave;
                dog.FileWithGradesSave +=Grades_FileSave;

                Console.WriteLine("Podaj imię psa:");

                string name = CheckIsNullOrEmpty().ToUpper();
                dog.Name=name;

                Console.WriteLine("Podaj imię i nazwisko właściciela");

                string owner = CheckIsNullOrEmpty().ToUpper();
                dog.Owner = owner;

                Console.WriteLine("Podaj wiek psa:");
                int age;

                while (true)
                {
                    age = CheckIsNullOrEmptyAndIntParse();

                    if (age > 0)
                    {
                        break;
                    }
                    Console.WriteLine("Podaj wiek więszy od zera");
                }
                dog.Age = age;

                Console.WriteLine("Podaj płeć psa, wpisz 'F' - suka, 'M' - samiec ");

                while (true)
                {
                    string sex = CheckIsNullOrEmpty().ToUpper();

                    try
                    {
                        dog.AddSex(sex);
                        break;
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                        Console.WriteLine("Podaj włąsciwe określenie płci");
                    }
                }

                AddAllGrades(dog);
                break;
            }
        case "2":
            {
                DogInMemory dog = new DogInMemory();

                Console.WriteLine("Podaj imię psa:");

                string name = CheckIsNullOrEmpty().ToUpper();
                dog.Name=name;

                AddAllGrades(dog);
                break;
            }

        case "3":
            {
                Console.WriteLine("Podaj imię psa, którego dane chcesz odczytać:");

                string name = CheckIsNullOrEmpty().ToUpper();
                DogInFile dog = new DogInFile(name);

                if ($"{name}_grades" !=null)
                {
                    dog.PrintSheetFromFile();
                }
                else
                {
                    Console.WriteLine("Nie ma w bazie psa o podanym imieniu");
                }
                break;
            }

        case "Q":
            {
                Environment.Exit(0);
                break;
            }
    }
}

static void Sheet_FileSave(object sender, EventArgs args)
{
    Console.WriteLine("\tZapisano kartę konkursową z wynikami w pliku.");
}

static void Grades_FileSave(object sender, EventArgs args)
{
    Console.WriteLine("Dodano do statystyk.");
}

static string CheckIsNullOrEmpty()
{
    string? input = Console.ReadLine();

    while (String.IsNullOrEmpty(input))
    {
        Console.WriteLine("Podaj odpowiednią wartość");
    }
    return input;
}

static int CheckIsNullOrEmptyAndIntParse()
{
    while (true)
    {
        string? input = Console.ReadLine();
        var resultInt = int.TryParse(input, out int result);

        if (!resultInt)
        {
            Console.WriteLine("Podaj liczbę");
        }
        return result;
    }
}

static void AddAllGrades(IDog dog)
{
    Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji WSPÓŁPRACA Z PRZEWODNIKIEM:");
    int cooperation;

    while (true)
    {
        cooperation = CheckIsNullOrEmptyAndIntParse();

        if (cooperation >= 0 && cooperation <=4)
        {
            break;
        }
        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
    }

    dog.AddCooperation(cooperation);

    Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji ZACHOWANIE PRZY ZWIERZYNIE:");
    int behavior;

    while (true)
    {
        behavior = CheckIsNullOrEmptyAndIntParse();

        if (behavior >= 0 && behavior <=4)
        {
            break;
        }
        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
    }

    dog.AddBehavior(behavior);

    Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji PRACA NA OTOKU:");

    int work;

    while (true)
    {
        work = CheckIsNullOrEmptyAndIntParse();

        if (work >= 0 && work <=4)
        {
            break;
        }
        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
    }

    dog.AddWork(work);

    Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji ODŁOŻENIE PSA LUZEM:");
    int stay_a;

    while (true)
    {
        stay_a = CheckIsNullOrEmptyAndIntParse();

        if (stay_a >= 0 && stay_a <=4)
        {
            break;
        }
        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
    }

    dog.AddStay_A(stay_a);

    Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji ODŁOŻENIE PSA NA UWIĘZI");
    int stay_b;

    while (true)
    {
        stay_b = CheckIsNullOrEmptyAndIntParse();

        if (stay_b >= 0 && stay_b <=4)
        {
            break;
        }
        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
    }

    dog.AddStay_B(stay_b);

    dog.PrintSheet();
}