using Newtonsoft.Json;
using System.Text;

void Task1(string filePath)
{
    string text = File.ReadAllText(filePath);
    List<char> vowels = ['а', 'е', 'є', 'и', 'і', 'Ї', 'о', 'у', 'ю', 'я'];
    List<char> consonants = ['в', 'л', 'м', 'н', 'р', 'й', 'б', 'г', 'ґ', 'д', 'з', 'ж', 'п', 'х', 'к', 'т', 'с', 'ш', 'ч', 'щ', 'ц', 'ф'];
    int vowNum = 0;
    int conNum = 0;
    foreach (char c in text)
    {
        char letter = char.ToLower(c);
        foreach (char i in vowels)
        {
            if (i == letter) vowNum++;
        }
        foreach (char i in consonants)
        {
            if (i == letter) conNum++;
        }
    }
    Console.WriteLine($"Кількість голосних - {vowNum}, а приголосних - {conNum}");
}
void Task2()
{
    Console.Write("Введіть вхідний словник:");
    string input = Console.ReadLine();
    List<Dictionary<string, string>> listOfDic = JsonConvert.DeserializeObject<List<Dictionary<string, string>>>(input);
    List<string> unic = listOfDic.SelectMany(i => i.Values).Distinct().ToList();
    Console.WriteLine($"Результат: {JsonConvert.SerializeObject(unic)}");
}
List<int> manualTask3()
{
    List<int> A = new List<int>();
    Console.WriteLine("Для зупинки введення напишіть \"-\"");
    Console.WriteLine("Введіть число: ");
    bool manual = true;
    while (manual)
    {
        string temp = Console.ReadLine();
        if (temp != "-")
        {
            A.Add(int.Parse(temp));
            Console.WriteLine($"{temp} додане. Зупиніть, або введіть наступне:");
        }
        else manual = false;
    }
    return A;
}
List<int> autoTask3()
{
    Console.Write("Введіть мінімальне значення: ");
    int min = int.Parse(Console.ReadLine());
    Console.Write("Введіть максимальне значення: ");
    int max = int.Parse(Console.ReadLine());
    Random rnd = new Random();
    Console.Write("Введіть кількість елементів: ");
    int n = int.Parse(Console.ReadLine());
    List<int> A = new List<int>();
    for (int i = 0; i < n; i++)
    {
        A.Add(rnd.Next(min, max + 1));
    }
    return A;
}
void Task3(int D, List<int> A)
{
    var result = from i in A
                 where (i % 10 == D) & (i > 0)
                 select i;
    Console.WriteLine(result.FirstOrDefault(0));
}

Console.OutputEncoding = UTF8Encoding.UTF8;
bool isProgramRun = true;
do
{
    try
    {
        bool taskSelected = false;
        while (!taskSelected)
        {
            Console.Write("Введіть номер завдання: ");
            int number = int.Parse(Console.ReadLine());
            switch (number)
            {
                case 1:
                    Console.Write("Введіть шлях до файлу: ");
                    string filePath = Console.ReadLine();
                    if (File.Exists(filePath))
                    {
                        Task1(filePath);
                    }
                    taskSelected = true;
                    break;
                case 2:
                    Task2();
                    taskSelected = true;
                    break;
                case 3:

                    bool isDInputed = false;
                    int D = 0;
                    while (!isDInputed)
                    {
                        Console.Write("Введіть цифру A: ");
                        D = int.Parse(Console.ReadLine());
                        if (D < 10 & D >= 0) isDInputed = true;
                        else Console.WriteLine("Ви ввели некоректу цифру");
                    }
                    while (!taskSelected)
                    {
                        Console.Write("Для введення послідовності вручну виберіть 1, якщо автоматично - 2: ");
                        int input = int.Parse(Console.ReadLine());
                        List<int> A = new List<int>();
                        switch (input)
                        {
                            case 1:
                                A = manualTask3();
                                Task3(D, A);
                                break;
                            case 2:
                                A = autoTask3();
                                Task3(D, A);
                                break;
                            default:
                                Console.WriteLine("Введіть коректні значення (1-2)");
                                break;
                        }
                        taskSelected = true;
                    }
                    break;
                default:
                    Console.WriteLine("Введіть коректні значення (1-3)");
                    break;
            }
        }
    }
    catch (FormatException) { Console.WriteLine("Введіть коректне значення"); }
    catch (JsonReaderException) { Console.WriteLine("Ви ввели некоректний словник"); }
    catch (JsonSerializationException) { Console.WriteLine("Ви ввели некоректний словник"); }
    catch (OverflowException) { Console.WriteLine("Занадто велике число"); }
    finally
    {
        bool Exit = true;
        while (Exit)
        {
            Console.WriteLine("Вийти з програми?");
            Console.WriteLine("Використовуйте 'так/нi' або '+/-'");
            string answer = Console.ReadLine();
            if (answer == "так" || answer == "+")
            {
                Exit = false;
                isProgramRun = false;
            }
            else if (answer == "нi" || answer == "-")
            {
                Exit = false;
            }
            else
            {
                Console.WriteLine("Введене некоректне значення");
            }
        }
    }
}
while (isProgramRun);

// D:\Text.txt
// [{"V":"S001"}, {"V": "S002"}, {"VI": "S001"}, {"VI": "S005"}, {"VII":"S005"}, {"V":"S009"},{"VIII":"S007"}]