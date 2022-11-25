const string CommandOnslaught = "1";
const string CommandDexterity = "2";
const string CommandBravery = "3";
const string CommandCounterattack = "4";
 
int bossHealth = 1000;
int magicianHealth = 100;
string userInput = string.Empty;
int damageOnslaught = 250;
int damageDexterity = 55;
int damageBravery = 100;
int damageCounterattack = 500;
int bossDamage = 25;
int powerChange = 2;
string previousSpell = string.Empty;

 while (magicianHealth > 0 && bossHealth > 0)
{
    Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
    previousSpell = userInput;

    if (previousSpell == CommandCounterattack)
    {
        bossHealth -= damageCounterattack;
    }
    
    Console.WriteLine($"Выберите ваше умение: \n{CommandOnslaught}: Натиск - отнимает {damageOnslaught} хп. \n{CommandDexterity}: Ловкость - отнимает {damageDexterity} хп, в свою очередь вы ничего не теряете. \n{CommandBravery}: Храбрость - отнимает {damageBravery} хп. \n{CommandCounterattack}: Контрудар - отнимает {damageCounterattack} хп.");
    userInput = Console.ReadLine();

    switch (userInput)
    {
        case CommandOnslaught:
            Console.WriteLine("Вы использовали натиск.");
            bossHealth -= damageOnslaught;
            magicianHealth -= bossDamage;
            break;

        case CommandDexterity:
            if (previousSpell == CommandDexterity)
            {
                Console.WriteLine("Вы слишком часто используете ловкость, атака не удалась, вы споткнулись.");
                magicianHealth -= bossDamage * powerChange;
            }
            else
            {
                Console.WriteLine("Вы использовали умение ловкости, на следующий ход умение заблокировано.");
                bossHealth -= damageDexterity;
            }
            break;

        case CommandBravery:
            Console.WriteLine("Вы использовали навык храбрости.");
            bossHealth -= damageBravery;
            magicianHealth -= bossDamage / powerChange;
            break;

        case CommandCounterattack:
            Console.WriteLine("Вы использовали контрудар.");
            magicianHealth -= bossDamage;
            break;
    }

    if (magicianHealth <= 0 && bossHealth <= 0)
    {
        Console.WriteLine("Ничья, вы и босс пали.");
        break;
    }
    else if (bossHealth <= 0)
    {
        Console.WriteLine("Босс пал, вы победили.");
        break;
    }
    else if (magicianHealth <= 0)
    {
        Console.WriteLine("У вас не осталось здоровья, вы проиграли.");
        break;
    }
    
    Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
    previousSpell = userInput;
}

