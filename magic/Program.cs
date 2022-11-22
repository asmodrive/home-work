const string Onslaught = "1";
const string Dexterity = "2";
const string Bravery = "3";
const string Counterattack = "4";
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
    if (previousSpell == Counterattack)
    {
        bossHealth -= damageCounterattack;
    }
    
    Console.WriteLine($"Выберите ваше умение: \n{Onslaught}: Натиск - отнимает {damageOnslaught} хп. \n{Dexterity}: Ловкость - отнимает {damageDexterity} хп, в свою очередь вы ничего не теряете. \n{Bravery}: Храбрость - отнимает {damageBravery} хп. \n{Counterattack}: Контрудар - отнимает {damageCounterattack} хп.");
    userInput = Console.ReadLine();
    switch (userInput)
    {
        case Onslaught:
            Console.WriteLine("Вы использовали натиск.");
            bossHealth -= damageOnslaught;
            magicianHealth -= bossDamage;
            break;
        case Dexterity:
            if (previousSpell == Dexterity)
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
        case Bravery:
            Console.WriteLine("Вы использовали навык храбрости.");
            bossHealth -= damageBravery;
            magicianHealth -= bossDamage / powerChange;
            break;
        case Counterattack:
            Console.WriteLine("Вы использовали контрудар.");
            magicianHealth -= bossDamage;
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
    else
    {
        Console.WriteLine("Ничья, вы и босс пали.");
        break;
    }
     
    Console.WriteLine($"У босса осталось {bossHealth} хп, у вас осталось {magicianHealth} хп.");
    previousSpell = userInput;
}
