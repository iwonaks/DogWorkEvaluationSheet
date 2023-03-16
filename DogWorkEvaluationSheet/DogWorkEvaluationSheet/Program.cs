using DogWorkEvaluationSheet;

Dog dog = new Dog();
var sheet = new Sheet();

sheet.FileSave +=Sheet_FileSave;

void Sheet_FileSave(object sender, EventArgs args)
{
    Console.WriteLine("Wygenerowano i zapisano karty konkursowe z wynikami dla każdego psa osobno.\nZapisano karty konkursowe psów w jednym pliku.");
}

Console.WriteLine("Witaj w programie genrującym karty zawodników z wynikami przeprowadzonego konkursu");
Console.WriteLine("---------------------------------------------------------------------------------");

while (true)
{
    dog.sumStack.Clear();
    Console.WriteLine("Podaj informacje dotyczące psów z karty sędzieggo:\nWybierz 1 by dodać informacje o wszystkich psach uczestniczących w konkursach, \nS -  by wygenerować wyniki konursu, zapisać je w plikach i zakońćzyć.");
    string input = Console.ReadLine().ToUpper();
    switch (input)
    {
        case "S":

            var listAllDogs = dog.MakeListAllDogs();
            var sheetvalue = dog.AddLocationToListAllDogs(listAllDogs);
            sheet.PrintSheet(sheetvalue);

            break;

        case "1":
            {
                string name;
                Console.WriteLine("Podaj imię psa:");
                while (true)
                {
                    name= CheckIsNullOrEmpty();

                    name = name.ToUpper();
                    try
                    {
                        dog.AddName(name);
                        break;

                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }


                Console.WriteLine("Podaj imię i nazwisko właściciela");
                string owner = CheckIsNullOrEmpty();

                owner = owner.ToUpper();
                dog.AddOwner(owner);

                Console.WriteLine("Podaj wiek psa:");
                int age;

                while (true)
                {
                    age = CheckIsNullOrEmptyAndIntParse();

                    if (age > 0)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podaj wiek więszy od zera");
                    }
                }
                dog.AddAge(age);

                Console.WriteLine("Podaj płeć psa, wpisz 'F' - suka, 'M' - samiec ");
                string sex;

                while (true)
                {
                    sex = CheckIsNullOrEmpty();
                    sex = sex.ToUpper();
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

                Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji PRACA NA OTOKU:");
                int work;

                while (true)
                {
                    work = CheckIsNullOrEmptyAndIntParse();

                    if (work >= 0 && work <=4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
                    }
                }
                dog.AddWork(work);

                Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji ZACHOWANIE PRZY ZWIERZYNIE:");
                int behavior;

                while (true)
                {
                    behavior = CheckIsNullOrEmptyAndIntParse();

                    if (behavior >= 0 && behavior <=4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
                    }
                }
                dog.AddBehavior(behavior);

                Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji ODŁOŻENIE PSA LUZEM:");
                int stay_a;

                while (true)
                {
                    stay_a = CheckIsNullOrEmptyAndIntParse();

                    if (stay_a >= 0 && stay_a <=4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
                    }
                }
                dog.AddStay_a(stay_a);

                Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji ODŁOŻENIE PSA NA UWIĘZI");
                int stay_b;

                while (true)
                {
                    stay_b = CheckIsNullOrEmptyAndIntParse();

                    if (stay_b >= 0 && stay_b <=4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
                    }
                }
                dog.AddStay_a(stay_b);

                Console.WriteLine("Podaj ilość zdobytych punktów w konkurencji WSPÓŁPRACA Z PRZEWODNIKIEM:");
                int cooperation;

                while (true)
                {
                    cooperation = CheckIsNullOrEmptyAndIntParse();

                    if (cooperation >= 0 && cooperation <=4)
                    {
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
                    }
                }
                dog.AddCooperation(cooperation);

                dog.GetSumAndGradeOfVictoryList();
                break;
            }
    }
}

static string CheckIsNullOrEmpty()
{
    string input = Console.ReadLine();
    while (String.IsNullOrEmpty(input))
    {
        Console.WriteLine("Podaj odpowiednią wartość");
        input = Console.ReadLine();
    }

    return input;
}

static int CheckIsNullOrEmptyAndIntParse()
{
    while (true)
    {
        string input = Console.ReadLine();
        var resultInt = Int32.TryParse(input, out int result);
        if (!resultInt)
        {
            Console.WriteLine("Podaj liczbę");
        }

        else
        {
            return result;
        }
    }
}