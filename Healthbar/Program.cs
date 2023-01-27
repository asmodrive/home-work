using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSLight_6
{
    class Program
    {
        static void Main(string[] args)
        {
            const string RocketAttackCommand1 = "Ракецио";
            const string PropagandaCommand1 = "Пропагандум";
            const string MobilisationCommand1 = "Мобилизацио";
            const string AntiAircraftDefenseCommand1 = "ПВОрум";
            const string RocketAttackCommand2 = "1";
            const string PropagandaCommand2 = "2";
            const string MobilisationCommand2 = "3";
            const string AntiAircraftDefenseCommand2 = "4";

            int health1 = 1000;
            int health2 = 5000;
            int damage1 = 100;
            int damage2 = 200;
            int morale1 = 0;
            int morale2 = 0;
            int armor1 = 10;
            int armor2 = 50;
            int percents = 100;
            int health1AdditionalLongSpaseNeed = 99;
            int healthMinimum = 0;
            int damageMinimum = 10;
            int moraleMinimum = 0;
            int armorMinimum = 0;
            int armorMaximum = 100;
            int antiAircraftDefenseStatusOnMovesCount1 = 0;
            int antiAircraftDefenseStatusOnMovesCount2 = 0;
            int antiAircraftDefenseStatusOnAmountMoves = 5;
            int antiAircraftDefenseStatusOff = 0;
            int damageDamageDicline = 15;
            int damageArmorDicline = 10;
            int moraleDamageBonus = 2;
            int moraleArmorBonus = 10;
            int mobilisationHealthBonus = 300;
            int mobilisationDamageBonus = 100;
            int mobilisationMoraleDicline = 5;
            int moraleBoost = 2;
            int moraleDicline = 1;
            int daysCount = 1;
            int enemyCommandChoice1;
            int enemyCommandChoice;
            int enemyCommandChoiceMinimum = 1;
            int enemyCommandChoice1Maximum = 2;
            int enemyCommandChoiceMaximum = 4;
            int windowWidth = 100;
            int windowHeight = 29;
            int windowHalth = 2;
            int cursorPositionStart = 0;
            int cursorPositionTitleMessageX;
            int cursorPositionTitleMessageY;
            int amountRepeatsMessage = 5000;
            int horizontalLeftMessageSpread = 4;
            int horizontalRightMessageSpread;
            int verticalUpMessageSpread = 1;
            int verticalDownMessageSpread;
            int randomDifference = 1;
            bool isPossibleMobilization1 = false;
            bool isPossibleMobilization2 = false;
            string userInput;
            string gameTitleMessage = "Это война";
            string greetingMessage = "\n   Вы воюете за волшебную страну, на которую напала колдунская Империя.\n Приведите наш народ к победе, используя " +
                "заклинания:\n";
            string rocketAttackMessage = $"   {RocketAttackCommand1} - нанести массированный ракетный удар по военным объектам противника.\n В том числе по ракетным " +
                $"установкам и средствам ПВО.\n";
            string rocketAttackMessagePart1 = " Сейчас доступно ";
            string rocketAttackMessagePart2 = " ракет.\n";
            string propagandaMessage = $"   {PropagandaCommand1} - выступить перед нацией с вдохновляющей речью.\n Поднимает моральный дух нашей армии на {moraleBoost} " +
                $"и снижает его на {moraleDicline} у врага.\n Каждая единица морали увеличивает количество ракет на {moraleDamageBonus}% от текущего значения и\n " +
                $"усиливает средства ПВО на {moraleArmorBonus}%.\n";
            string mobilisationMessage = $"   {MobilisationCommand1} - мобилизовать население. Доступно только сразу после использования {PropagandaCommand1}.\n " +
                $"Увеличивает на {mobilisationHealthBonus} число воинских частей (в/ч) и на {mobilisationDamageBonus} - ракет, но снижает моральный дух на " +
                $"{mobilisationMoraleDicline}.\n";
            string antiAircraftDefenseMessage = $"   {AntiAircraftDefenseCommand1} - активировать средства противовоздушной обороны (ПВО).\n В следующие " +
                $"{antiAircraftDefenseStatusOnAmountMoves} ходов будет отражено ";
            string antiAircraftDefenseMessagePart1 = "% каждой ракетной атаки противника.\n";
            string firstMoveMessage = $"\n   Итак, в 4 утра Империя выпустила по нашей стране {damage2} ракет.\n К сожалению, мы не были " +
                $"готовы отразить удар, и все ракеты поразили наши военные базы,\n однако вопиющая подлость атаки сплотила нашу нацию и подняла её моральный дух на " +
                $"{moraleBoost}.";
            string userWinMessage = "Мы победили!";
            string userLoseMessage = "Мы проиграли...";
            string additionalMessage;
            string longSpaceText = "\t";
            string emptyText = "";
            string cleaningText = "";
            char cleaningSymbol = ' ';

            Random random = new Random();
            enemyCommandChoice1Maximum += randomDifference;
            enemyCommandChoiceMaximum += randomDifference;
            horizontalRightMessageSpread = horizontalLeftMessageSpread + randomDifference;
            verticalDownMessageSpread = verticalUpMessageSpread + randomDifference;
            health1 -= damage2;
            morale1 += moraleBoost;
            damage1 += damage1 * morale1 * moraleDamageBonus / percents;
            damage2 += damage2 * morale2 * moraleDamageBonus / percents;
            armor1 += morale1 * moraleArmorBonus;
            armor2 += morale2 * moraleArmorBonus;
            Console.WindowWidth = windowWidth;
            Console.WindowHeight = windowHeight;
            Console.ReadKey();

            for (int i = 0; i < gameTitleMessage.Length; i++)
            {
                cleaningText += cleaningSymbol;
            }

            for (int i = 0; i < amountRepeatsMessage; i++)
            {
                cursorPositionTitleMessageX = random.Next((windowWidth - gameTitleMessage.Length) / windowHalth - horizontalLeftMessageSpread, (windowWidth -
                    gameTitleMessage.Length) / windowHalth + horizontalRightMessageSpread);
                cursorPositionTitleMessageY = random.Next(windowHeight / windowHalth - verticalUpMessageSpread, windowHeight / windowHalth + verticalDownMessageSpread);
                Console.SetCursorPosition(cursorPositionTitleMessageX, cursorPositionTitleMessageY);
                Console.Write(gameTitleMessage);
                Console.SetCursorPosition(cursorPositionTitleMessageX, cursorPositionTitleMessageY);
                Console.Write(cleaningText);
                Console.SetCursorPosition((windowWidth - gameTitleMessage.Length) / windowHalth, windowHeight / windowHalth);
                Console.Write(gameTitleMessage);
            }

            Console.SetCursorPosition((windowWidth - gameTitleMessage.Length) / windowHalth, windowHeight / windowHalth);
            Console.WriteLine(gameTitleMessage);
            Console.SetCursorPosition(cursorPositionStart, cursorPositionStart);
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(greetingMessage);
            Console.ReadKey();
            Console.WriteLine($"{rocketAttackMessage}\n{propagandaMessage}\n{mobilisationMessage}\n{antiAircraftDefenseMessage}{armor1}{antiAircraftDefenseMessagePart1}");
            Console.ReadKey();
            Console.Clear();
            Console.WriteLine(firstMoveMessage);
            Console.ReadKey();

            while (health1 > healthMinimum && health2 > healthMinimum)
            {
                Console.Clear();

                if (health1 >= health1AdditionalLongSpaseNeed)
                {
                    additionalMessage = emptyText;
                }
                else
                {
                    additionalMessage = longSpaceText;
                }

                Console.WriteLine($"\n\tТекущая сводка минобороны на {daysCount} день войны:\n\n\tНаша страна\t\t\t\tИмперия\n\n\tВ/ч: {health1}\t\t\t\t" +
                    $"{additionalMessage}В/ч: {health2}\n\tУрон: {damage1}\t\t\t\tУрон: {damage2}\n\tМоральный дух: {morale1}\t\t\tМоральный дух: {morale2}\n\tПВО: " +
                    $"{armor1}%, активна ходов: {antiAircraftDefenseStatusOnMovesCount1}\t\tПВО: {armor2}%, активна ходов: {antiAircraftDefenseStatusOnMovesCount2}" +
                    $"\n\n");
                Console.WriteLine($"\n{rocketAttackMessage}{rocketAttackMessagePart1}{damage1}{rocketAttackMessagePart2}\n{propagandaMessage}\n{mobilisationMessage}\n" +
                    $"{antiAircraftDefenseMessage}{armor1}{antiAircraftDefenseMessagePart1}");
                Console.Write("   Наш ход. Введите заклинание, которое хотите использовать: ");
                userInput = Convert.ToString(Console.ReadLine());
                Console.Clear();
                Console.WriteLine();

                switch (userInput)
                {
                    case RocketAttackCommand1:
                    case RocketAttackCommand2:
                        Console.WriteLine("   Мы нанесли ракетный удар по Империи.");

                        if (antiAircraftDefenseStatusOnMovesCount2 > antiAircraftDefenseStatusOff)
                        {
                            health2 -= damage1 - damage1 * armor2 / percents;
                            damage2 -= (damage1 - damage1 * armor2 / percents) / damageDamageDicline;
                            armor2 -= (damage1 - damage1 * armor2 / percents) / damageArmorDicline;

                            if (armor2 <= armorMinimum)
                            {
                                Console.WriteLine(" Все ракеты достигли цели!");
                            }
                            else if (armor2 >= armorMaximum)
                            {
                                Console.WriteLine(" К сожалению ни одна ракета не достигла цели: все были сбиты вражеской ПВО...");
                            }
                            else
                            {
                                Console.WriteLine(" Часть ракет была сбита вражеской ПВО, но оставшиеся поразили намеченные цели.");
                            }
                        }
                        else
                        {
                            health2 -= damage1;
                            damage2 -= damage1 / damageDamageDicline;
                            armor2 -= damage1 / damageArmorDicline;
                            Console.WriteLine(" Все ракеты достигли цели!");
                        }

                        isPossibleMobilization1 = false;
                        break;

                    case PropagandaCommand1:
                    case PropagandaCommand2:
                        morale1 += moraleBoost;
                        morale2 -= moraleDicline;
                        damage1 += damage1 * moraleDamageBonus * moraleBoost / percents;
                        armor1 += moraleArmorBonus * moraleBoost;
                        isPossibleMobilization1 = true;
                        Console.WriteLine("   Вы выступили в СМИ с вдохновляющей речью.");

                        if (morale2 <= moraleMinimum)
                        {
                            Console.WriteLine(" Так держать, враг морально раздавлен!");
                        }

                        break;

                    case MobilisationCommand1:
                    case MobilisationCommand2:
                        if (isPossibleMobilization1)
                        {
                            if (morale1 > mobilisationMoraleDicline)
                            {

                                health1 += mobilisationHealthBonus;
                                damage1 += damage1 * mobilisationDamageBonus / percents;
                                Console.WriteLine("   Вы успешно провели мобилизацию.");
                            }
                            else if (morale1 == mobilisationMoraleDicline)
                            {
                                health1 += mobilisationHealthBonus;
                                damage1 += damage1 * mobilisationDamageBonus / percents;
                                Console.WriteLine("   Вы провели мобилизацию. Это тяжело далось нам, нация подавлена.");
                            }
                            else if (morale1 > moraleMinimum)
                            {
                                Console.WriteLine("   Вы напрасно попытались провести мобилизацию: из-за низкого морального духа нации это не удалось\n сделать, никто" +
                                    " даже не пришёл, и вы зря потратили очки морали...");
                            }
                            else
                            {
                                Console.WriteLine("   С ума сошли? Народ в гневе от вашего приказа о мобилизации!\n Вам чудом удалось остаться главой страны.");
                            }
                        }
                        else
                        {
                            Console.Clear();
                            Console.WriteLine($"\n   Мобилизация возможна только непосредственно в следующий после использования {PropagandaCommand1} ход!");
                            Console.ReadKey();
                            continue;
                        }

                        morale1 -= mobilisationMoraleDicline;
                        isPossibleMobilization1 = false;
                        break;

                    case AntiAircraftDefenseCommand1:
                    case AntiAircraftDefenseCommand2:
                        antiAircraftDefenseStatusOnMovesCount1 = antiAircraftDefenseStatusOnAmountMoves;
                        Console.WriteLine("   Средства ПВО активированы!");
                        isPossibleMobilization1 = false;
                        break;

                    default:
                        Console.Clear();
                        Console.WriteLine("\n   Приказ не ясен!");
                        Console.ReadKey();
                        continue;
                }

                if (health2 <= healthMinimum)
                {
                    break;
                }

                enemyCommandChoice1 = random.Next(enemyCommandChoiceMinimum, enemyCommandChoice1Maximum);

                if (enemyCommandChoice1 == 1)
                {
                    enemyCommandChoice = enemyCommandChoice1;
                }
                else
                {
                    enemyCommandChoice = random.Next(enemyCommandChoiceMinimum, enemyCommandChoiceMaximum);
                }

                Console.WriteLine();

                switch (Convert.ToString(enemyCommandChoice))
                {
                    case RocketAttackCommand2:
                        Console.WriteLine("   Империя нанесла по нам ракетный удар!");

                        if (antiAircraftDefenseStatusOnMovesCount1 > antiAircraftDefenseStatusOff)
                        {
                            health1 -= damage2 - damage2 * armor1 / percents;
                            damage1 -= (damage2 - damage2 * armor1 / percents) / damageDamageDicline;
                            armor1 -= (damage2 - damage2 * armor1 / percents) / damageArmorDicline;

                            if (armor1 <= armorMinimum)
                            {
                                Console.WriteLine(" Все её ракеты поразили наши базы...");
                            }
                            else if (armor1 >= armorMaximum)
                            {
                                Console.WriteLine(" К счастью, ни одна ракета не достигла цели: все были сбиты нашими средствами ПВО!");
                            }
                            else
                            {
                                Console.WriteLine(" Часть ракет сбили наши ПВО, но оставшиеся ракеты поразили наши военные базы.");
                            }
                        }
                        else
                        {
                            health1 -= damage2;
                            damage1 -= damage2 / damageDamageDicline;
                            armor1 -= damage2 / damageArmorDicline;
                            Console.WriteLine(" Все её ракеты поразили наши базы...");
                        }

                        isPossibleMobilization2 = false;
                        break;

                    case PropagandaCommand2:
                        morale2 += moraleBoost;
                        morale1 -= moraleDicline;
                        damage2 += damage2 * moraleDamageBonus * moraleBoost / percents;
                        armor2 += moraleArmorBonus * moraleBoost;
                        isPossibleMobilization2 = true;
                        Console.WriteLine("   Император выступил в СМИ со своей пропагандой.");

                        if (morale1 <= moraleMinimum)
                        {
                            Console.WriteLine(" Его речь морально раздавила нашу нацию...");
                        }

                        break;

                    case MobilisationCommand2:
                        if (isPossibleMobilization2)
                        {
                            if (morale2 > mobilisationMoraleDicline)
                            {
                                health2 += mobilisationHealthBonus;
                                damage2 += damage2 * mobilisationDamageBonus / percents;
                                Console.WriteLine("   Империя провела мобилизацию.");
                            }
                            else if (morale2 == mobilisationMoraleDicline)
                            {
                                health2 += mobilisationHealthBonus;
                                damage2 += damage2 * mobilisationDamageBonus / percents;
                                Console.WriteLine("   Империя с трудом провела мобилизацию, её нация подавлена.");
                            }
                            else if (morale2 > moraleMinimum)
                            {
                                morale2 += moraleBoost;
                                morale1 -= moraleDicline;
                                damage2 += damage2 * moraleDamageBonus * moraleBoost / percents;
                                armor2 += moraleArmorBonus * moraleBoost;
                                isPossibleMobilization2 = true;
                                Console.WriteLine("   Император выступил в СМИ со своей пропагандой.");

                                if (morale1 <= moraleMinimum)
                                {
                                    Console.WriteLine(" Его речь морально раздавила нашу нацию...");
                                }
                            }
                            else
                            {
                                Console.WriteLine("   Император сошел с ума! Его народ в гневе от приказа о мобилизации!\n Ему чудом удалось остаться главой страны.");
                            }
                        }
                        else
                        {
                            Console.WriteLine("   Империя нанесла по нам ракетный удар!");

                            if (antiAircraftDefenseStatusOnMovesCount1 > antiAircraftDefenseStatusOff)
                            {
                                health1 -= damage2 - damage2 * armor1 / percents;
                                damage1 -= (damage2 - damage2 * armor1 / percents) / damageDamageDicline;
                                armor1 -= (damage2 - damage2 * armor1 / percents) / damageArmorDicline;

                                if (armor1 == armorMinimum)
                                {
                                    Console.WriteLine(" Все её ракеты поразили наши базы...");
                                }
                                else if (armor1 == armorMaximum)
                                {
                                    Console.WriteLine(" К счастью, ни одна ракета не достигла цели: все были сбиты нашими средствами ПВО!");
                                }
                                else
                                {
                                    Console.WriteLine(" Часть ракет была сбита вражеской ПВО, но оставшиеся поразили наши базы.");
                                }
                            }
                            else
                            {
                                health1 -= damage2;
                                damage1 -= damage2 / damageDamageDicline;
                                armor1 -= damage2 / damageArmorDicline;
                                Console.WriteLine(" Все её ракеты поразили наши базы...");
                            }

                            isPossibleMobilization2 = false;
                            break;
                        }

                        morale2 -= mobilisationMoraleDicline;
                        isPossibleMobilization2 = false;
                        break;

                    case AntiAircraftDefenseCommand2:
                        antiAircraftDefenseStatusOnMovesCount2 = antiAircraftDefenseStatusOnAmountMoves;
                        antiAircraftDefenseStatusOnMovesCount2++;
                        Console.WriteLine("   Империя активировала свои средства ПВО!");
                        isPossibleMobilization2 = false;
                        break;
                }

                daysCount++;
                antiAircraftDefenseStatusOnMovesCount1--;
                antiAircraftDefenseStatusOnMovesCount2--;

                if (damage1 < damageMinimum)
                {
                    damage1 = damageMinimum;
                }

                if (damage2 < damageMinimum)
                {
                    damage2 = damageMinimum;
                }

                if (armor1 > armorMaximum)
                {
                    armor1 = armorMaximum;
                }
                else if (armor1 < armorMinimum)
                {
                    armor1 = armorMinimum;
                }

                if (armor2 > armorMaximum)
                {
                    armor2 = armorMaximum;
                }
                else if (armor2 < armorMinimum)
                {
                    armor2 = armorMinimum;
                }

                if (morale1 < moraleMinimum)
                {
                    morale1 = moraleMinimum;
                }

                if (morale2 < moraleMinimum)
                {
                    morale2 = moraleMinimum;
                }

                if (antiAircraftDefenseStatusOnMovesCount1 < 0)
                {
                    antiAircraftDefenseStatusOnMovesCount1 = antiAircraftDefenseStatusOff;
                }

                if (antiAircraftDefenseStatusOnMovesCount2 < 0)
                {
                    antiAircraftDefenseStatusOnMovesCount2 = antiAircraftDefenseStatusOff;
                }

                Console.ReadKey();
            }

            Console.Clear();

            if (health1 > health2)
            {
                Console.BackgroundColor = ConsoleColor.White;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;

                for (int i = 0; i < userWinMessage.Length; i++)
                {
                    cleaningText += cleaningSymbol;
                }

                for (int i = 0; i < amountRepeatsMessage; i++)
                {
                    cursorPositionTitleMessageX = random.Next((windowWidth - userWinMessage.Length) / windowHalth - horizontalLeftMessageSpread, (windowWidth -
                        userWinMessage.Length) / windowHalth + horizontalRightMessageSpread);
                    cursorPositionTitleMessageY = random.Next(windowHeight / windowHalth - verticalUpMessageSpread, windowHeight / windowHalth + verticalDownMessageSpread);
                    Console.SetCursorPosition(cursorPositionTitleMessageX, cursorPositionTitleMessageY);
                    Console.Write(userWinMessage);
                    Console.SetCursorPosition(cursorPositionTitleMessageX, cursorPositionTitleMessageY);
                    Console.Write(cleaningText);
                    Console.SetCursorPosition((windowWidth - userWinMessage.Length) / windowHalth, windowHeight / windowHalth);
                    Console.Write(userWinMessage);
                }
            }
            else
            {
                Console.BackgroundColor = ConsoleColor.DarkRed;
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.Black;

                for (int i = 0; i < userLoseMessage.Length; i++)
                {
                    cleaningText += cleaningSymbol;
                }

                for (int i = 0; i < amountRepeatsMessage; i++)
                {
                    cursorPositionTitleMessageX = random.Next((windowWidth - userLoseMessage.Length) / windowHalth - horizontalLeftMessageSpread, (windowWidth -
                        userLoseMessage.Length) / windowHalth + horizontalRightMessageSpread);
                    cursorPositionTitleMessageY = random.Next(windowHeight / windowHalth - verticalUpMessageSpread, windowHeight / windowHalth + verticalDownMessageSpread);
                    Console.SetCursorPosition(cursorPositionTitleMessageX, cursorPositionTitleMessageY);
                    Console.Write(userLoseMessage);
                    Console.SetCursorPosition(cursorPositionTitleMessageX, cursorPositionTitleMessageY);
                    Console.Write(cleaningText);
                    Console.SetCursorPosition((windowWidth - userLoseMessage.Length) / windowHalth, windowHeight / windowHalth);
                    Console.Write(userLoseMessage);
                }
            }

            Console.ReadKey();
            Console.Clear();
        }
    }
}