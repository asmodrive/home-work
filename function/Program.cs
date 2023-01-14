using System.Collections;
using System.Globalization;

const string Add = "Добавить досье";
const string Conclusion = "Вывести досье";
const string Delete = "Удалить досье";
const string Search = "Поиск досье";
const string Exit = "Выход";

Console.WriteLine($"Введите, что вы хотите сделать: \n{Add} - добавить досье; \n{Conclusion} - вывод информации; \n{Delete} - удаление досье; \n{Search} - поиск досье; \n{Exit} - выход из программы.");
string userInput = string.Empty;
bool isRunning = true;
string[] names = { };
string[] posts = { };

while (isRunning)
{
    userInput = Console.ReadLine();

    switch (userInput)
    {
            case Add:
            {
                AddName(names, posts);
            }
            break;

            case Conclusion:
            {
                Finding(names, posts);
            }   
            break;

            case Delete:
            {
                DeleteName(names, posts);
            }
            break;

            case Search:
            {
                FindByName(names, posts);
            }
            break;

            case Exit:
            {
                isRunning = false;
                Console.WriteLine("Вы вышли из программы.");
            }
            break;
    }
}

static string[] Finding(string[] names, string[] posts)
{
    for (int i = 0; i < names.Length; i++)
    {
       
    }
    return names;
}

static void FindByName(string[] names, string[] posts)
{
    Console.WriteLine("Введите фамилию:");
    string name = Console.ReadLine();
    ArrayList al = new ArrayList();
    al.AddRange(names);

    foreach (string sub in names)
    {
        Console.WriteLine($"Substring: {sub}");
    }
}

static void AddName(string[] names, string[] posts)
{
    Console.WriteLine("Добрый день, введите ФИО сотрудника которого вы хотите добавить:");
    string name = Console.ReadLine();
    Console.WriteLine("Введите должность сотрудника которого вы хотите добавить:");
    string post = Console.ReadLine();

    IncriseArray(ref names, name);
    IncriseArray(ref posts, post);
}

static void DeleteName(string[] name, string[] post)
{
    for (int i = 0; i < name.Length; i++)
    {
        
    }

    for (int i = 0; i < post.Length; i++)
    {

    }

    Console.WriteLine("Информация удалена.");
}

static void IncriseArray(ref string[] array, string text)
{
    string[] temporaryArray = new string[array.Length+1];

    for (int i = 0; i < array.Length; i++)
    {
        temporaryArray[i] = array[i];
    }

    temporaryArray[temporaryArray.Length-1] = text; 
    array = temporaryArray;
}