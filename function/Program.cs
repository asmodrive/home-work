using System.Globalization;

const string Add = "Добавить досье";
const string Conclusion = "Вывести досье";
const string Delete = "Удалить досье";
const string Search = "Поиск досье";
const string Exit = "Выход";

Console.WriteLine($"Введите, что вы хотите сделать: \n{Add} - добавить досье; \n{Conclusion} - вывод информации; \n{Delete} - удаление досье; \n{Search} - поиск досье; \n{Exit} - выход из программы.");
string userInput = string.Empty;
bool isRunning = true;
string[] name = { };
string[] post = { };

while (isRunning)
{
    userInput = Console.ReadLine();

    switch (userInput)
    {
            case Add:
            {
                AddName(name, post);
            }
            break;

            case Conclusion:
            {
                Finding(name, post);
            }   
            break;

            case Delete:
            {
                DeleteName(name, post);
            }
            break;

            case Search:
            {
                FindByName(name, post);
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

static string[] Finding(string[] name, string[] post)
{
    for (int i = 0; i < name.Length; i++)
    {
       
    }
    return name;
}

static string FindByName(string[] name, string[] post)
{
    for (int i = 0; i < name.Length; i++)
    {
        for (int j = 0; j < post.Length; j++)
        {

        }
    }
    return null;
}

static void AddName(string[] name, string[] post)
{
    string[] nameArray = new string[name.Length+1];
    string[] postArray = new string[post.Length+1];

    for (int i = 0; i < nameArray.Length; i++)
    {
        nameArray[i] = post[i];
        postArray[i] = post[i];
    }

    post = postArray;
    name = nameArray;
    Console.WriteLine("Добрый день, введите ФИО сотрудника которого вы хотите добавить:");
    name[name.Length-1] = Console.ReadLine();
    Console.WriteLine("Введите должность сотрудника которого вы хотите добавить:");
    post[post.Length-1] = Console.ReadLine();
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