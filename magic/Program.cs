int bossHealth = 1000;
int magicianHealth = 100;
string userInput = "";
int damage1 = 250;
int damage2 = 55;
int damage3 = 100;
int damage4 = 500;
int bossDamage = 25;


 while (magicianHealth > 0 && bossHealth > 0)
{
    Console.WriteLine("Выберите ваше умение: \n1) Натиск - отнимает 250 хп. \n2) Ловкость - отнимает 55 хп, в свою очередь вы ничего не теряете. \n3) Храбрость - отнимает 200 хп. \n4) Контрудар - отнимает 500 хп.");
    userInput = Console.ReadLine();
    switch (userInput)
    {
        case "1":
            Console.WriteLine("Вы использовали натиск.");
            bossHealth -= damage1;
            magicianHealth -= bossDamage;
            Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
            break;
        case "2":
            Console.WriteLine("Вы использовали умение ловкости.");
            bossHealth -= damage2;
            Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
            break;
        case "3":
            Console.WriteLine("Вы использовали навык храбрости.");
            bossHealth -= damage3;
            magicianHealth -= bossDamage;
            Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
            break;
        case "4":
            Console.WriteLine("Вы использовали контрудар.");
            bossHealth -= damage4;
            magicianHealth -= bossDamage;
            Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
            break;
    }
    if (bossHealth <= 0)
    {
        Console.WriteLine("Босс пал, вы победили.");
        break;
    }
    else if (magicianHealth <= 0)
    {
        Console.WriteLine("У вас не осталось здоровья, вы проиграли.");
        break;
    }
}
