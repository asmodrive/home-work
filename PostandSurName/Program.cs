using System;

const string AddDossier = "Добавить досье.";
const string OutputDossier = "Вывести все досье.";
const string DeleteDossier = "Удалить досье.";
const string SearchLastName = "Поиск по фамилии.";
const string Exit = "Выйти из программы.";

bool isPlaying = true;
int index = 0;
string userInput = string.Empty;
string[] posts = { };
string[] fullNames = { };

Console.WriteLine($"Доброго времени суток, введите, что вы хотите сделать:\n {AddDossier} \n {OutputDossier} \n {DeleteDossier} \n {SearchLastName}\n {Exit}");

while (isPlaying)
{

    switch (userInput = Console.ReadLine())
    {
        case AddDossier:
            CreateDossier(ref posts, ref fullNames);
            break;
        case OutputDossier:
            OutputAllDossier(posts, fullNames);
            break;
        case DeleteDossier:
            DisposeDossier(ref posts, ref fullNames, index);
            break;
        case SearchLastName:
            FindLastName(fullNames, posts);
            break;
        case Exit:
            isPlaying = false;
            break;
    }
}

static void CreateDossier(ref string[] posts, ref string[] fullNames)
{
    string postMessage = "Введите должность:";
    IncreaseArray(ref posts, postMessage);
    string fullNamesMessage = "Введите Фамилию и Имя:";
    IncreaseArray(ref fullNames, fullNamesMessage);
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

static void DisposeDossier(ref string[] posts, ref string[] fullNames, int index)
{
    Console.WriteLine("Введите номер досье для удаления:");
    index = Convert.ToInt32(Console.ReadLine());
    ReduceArray(ref posts);
    ReduceArray(ref fullNames);
}

static void FindLastName(string[] fullNames, string[] posts)
{
    Console.WriteLine("Введите фамилию сотрудника:");
    string userInput = Console.ReadLine();

    for (int i = 0; i < fullNames.Length; i++)
    {
       string post = posts[i];
       string fullName = fullNames[i];
        var surname = fullName.Split(' ');

        if (surname[0] == userInput)
        {
            ShowDossier(post, fullName);
        }
    }
    Console.WriteLine("Досье найдено:");
}

static void ShowDossier(string post, string fullName)
{
    Console.WriteLine($"Должность: {post} | Фамилия Имя: {fullName}|");
}

static void IncreaseArray(ref string[] array, string message)
{
    string[] temporaryArray = new string[array.Length + 1];

    for (int i = 0; i < array.Length; i++)
    {
        temporaryArray[i] = array[i];
    }

    Console.WriteLine(message);
    temporaryArray[temporaryArray.Length - 1] = Console.ReadLine();
    array = temporaryArray;
}

static void ReduceArray(ref string[] array)
{
    Console.WriteLine("Введите номер досье для удаления:");
    int index = Convert.ToInt32(Console.ReadLine());

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
}