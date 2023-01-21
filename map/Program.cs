using System;

const string AddDossier = "1";
const string OutputDossier = "2";
const string DeleteDossier = "3";
const string SearchLastName = "4";
const string Exit = "5";

bool isPlaying = true;
string[] posts = { };
string[] fullNames = { };

Console.WriteLine($"{AddDossier} - добавить досье.");
Console.WriteLine($"{OutputDossier} - вывести все досье.");
Console.WriteLine($"{DeleteDossier} - удалить досье.");
Console.WriteLine($"{SearchLastName} - поиск по фамилии.");
Console.WriteLine($"{Exit} - выход.");

while (isPlaying)
{
    string userInput = Console.ReadLine();

    switch (userInput)
    {
        case AddDossier:
            CreateDossier(ref posts, ref fullNames);
            break;

        case OutputDossier:
            OutputAllDossier(posts, fullNames);
            break;

        case DeleteDossier:
            DisposeDossier(ref posts, ref fullNames);
            break;

        case SearchLastName:
            ShowByName(fullNames, posts);
            break;

        case Exit:
            isPlaying = false;
            break;
    }
}

static void CreateDossier(ref string[] posts, ref string[] fullNames)
{
    string postMessage = "Введите должность:";
    posts = IncreaseArray(posts, postMessage);
    string fullNamesMessage = "Введите Фамилию и Имя:";
    fullNames = IncreaseArray(fullNames, fullNamesMessage);
    Console.WriteLine("Досье успешно добавлено.");
}

static void OutputAllDossier(string[] posts, string[] fullNames)
{
    Console.WriteLine("Досье найдено:");

    for (int i = 0; i < posts.Length; i++)
    {
        ShowDossier(posts[i], fullNames[i]);
    }
}

static void DisposeDossier(ref string[] posts, ref string[] fullNames)
{
    Console.WriteLine("Введите номер досье для удаления:");
    int index = Convert.ToInt32(Console.ReadLine());
    ReduceArray(posts, index);
    ReduceArray(fullNames, index);
}

static void ShowByName(string[] fullNames, string[] posts)
{
    Console.WriteLine("Введите фамилию сотрудника:");
    string userInput = Console.ReadLine();

    for (int i = 0; i < fullNames.Length; i++)
    {
        string[] splittedWords = fullNames[i].Split(' ');

        if (splittedWords[0] == userInput)
        {
            ShowDossier(posts[i], fullNames[i]);
        }
    }

    Console.WriteLine("Досье найдено:");
}

static void ShowDossier(string post, string fullName)
{
    Console.WriteLine($"Должность: {post} | Фамилия Имя: {fullName}|");
}

static string[] IncreaseArray(string [] array, string message)
{
    Console.WriteLine(message); ;
    string text = Console.ReadLine();

    string[] temporaryArray = new string[array.Length + 1];

    for (int i = 0; i < array.Length; i++)
    {
        temporaryArray[i] = array[i];
    }

    temporaryArray[temporaryArray.Length - 1] = text;
    array = temporaryArray;
    return array;
}

static string[] ReduceArray(string[] array, int index)
{
    string[] temporaryArray = new string[array.Length - 1];

    for (int i = 0; i < temporaryArray.Length; i++)
    {
        if (i < index)
        {
            temporaryArray[i] = array[i];
        }
        else
        {
            temporaryArray[i] = array[i - 1];
        }
    }

    array = temporaryArray;
    Console.WriteLine("Досье удалено.");
    return array;
}