const string AddDossier = "Добавить досье.";
const string OutputDossier = "Вывести все досье.";
const string DeleteDossier = "Удалить досье.";
const string SearchLastName = "Поиск по фамилии.";
const string Exit = "Выйти из программы.";

bool isPlaying = true;
string userInput = string.Empty;
int index = 0;
string[] posts = { };
string[] fullNames = { };

Console.WriteLine($"Доброго времени суток, введите, что вы хотите сделать:\n 1) Добавить досье.\n 2) Вывести все досье.\n 3) Удалить досье. \n 4) Поиск по фамилии.\n 5) Выйти из программы.");

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

static void CreateDossier (ref string[] posts, ref string[] fullNames)
{
    string[] temporaryPost = new string[posts.Length + 1];

    for (int i = 0; i < posts.Length; i++)
    {
            temporaryPost[i] = posts[i];
    }

    Console.WriteLine("Введите должность:");
    temporaryPost[temporaryPost.Length - 1] = Console.ReadLine();
    posts = temporaryPost;

    string[] temporaryFullName = new string[fullNames.Length + 1];

    for (int i = 0; i < fullNames.Length; i++)
    {
            temporaryFullName[i] = fullNames[i];
    }

    Console.WriteLine("Введите фамилию и имя:");
    temporaryFullName[temporaryFullName.Length - 1] = Console.ReadLine();
    fullNames = temporaryFullName;
    Console.WriteLine("Досье успешно добавлено.");
}

static void OutputAllDossier (string[] posts, string[] fullNames)
{
    for (int i = 0; i < posts.Length; i++)
    {
        ShowDossier(posts[i], fullNames[i]);
    }
}

static void DisposeDossier (ref string[] array, int index)
{
    string[] temporaryArray = new string[array.Length - 1];

    for (int i = 0; i < index; i++)
    {
        temporaryArray[i] = array[i];
    }

    temporaryArray[temporaryArray.Length - 1] = Console.ReadLine();
    array = temporaryArray;
}

static void FindLastName (string[] fullNames, string[] posts)
{
    Console.WriteLine("Введите фамилию сотрудника:");
    string userInput = Console.ReadLine();

    for (int i = 0; i < fullNames.Length; i++)
    {
        string post = posts[i];
        string fullName = fullNames[i];
        var names = fullName.Split (' ');

        if (names[0] == userInput)
        {
            ShowDossier(post, fullName);
        }
    }
}

static void ShowDossier (string post, string fullName)
{
    Console.WriteLine($"Должность: {post} | Фамилия Имя: {fullName}|");
}
