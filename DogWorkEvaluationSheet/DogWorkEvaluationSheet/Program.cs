using DogWorkEvaluationSheet;
using System.IO;

Console.WriteLine("Witaj w programie genrującym kartę z wynikami przeprowadzonego konkursu w kategorii PSY TROPIĄCE");

while (true)
{
    Dog dog = new();

    dog.FileSave +=Sheet_FileSave;

    Console.WriteLine("---------------------------------------------------------------------------------");
    Console.WriteLine("Wybierz:\n1 -By wprowadzić informacje dotyczące psa oraz punkty jakie uzyskał w poszczególnych konkurencjach. Karta z wynikami zapisze się automatycznie.\nQ - Zamyka program.");
    string input = Console.ReadLine().ToUpper();
    switch (input)
    {
        case "1":
            {

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
                    else
                    {
                        Console.WriteLine("Podaj wiek więszy od zera");
                    }
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
                    else
                    {
                        Console.WriteLine("Podaj liczbę całkowitą w zakresie od 0 do 4");
                    }
                }
                dog.AddStay_B(stay_b);

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
                dog.PrintSheet();
                
                
                break;
            }

        case "Q":

            Environment.Exit(0);
            break;
    }
}
static void Sheet_FileSave(object sender, EventArgs args)
{
    Console.WriteLine($"Zapisano kartę konkursową z wynikami w pliku.");
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
        var resultInt = int.TryParse(input, out int result);

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