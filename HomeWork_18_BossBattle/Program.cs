namespace HomeWork_18_BossBattle
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const string SpellBoneSpear = "1";
            const string SpellDrainLife = "2";
            const string SpellAcidShield = "3";
            const string SpellAcidRain = "4";

            int playerHealth = 100;
            int bossHealth = 100;
            int bossDamage = 50;

            int boneSpearDamage = 30;
            int drainLifeAmount = 20;
            int acidRainDamage = 50;
            bool damageResistance = false;
            bool acidResistance = false;
            string optionsMessage = "Используйте ваши заклинания:" +
                $"\n [{SpellBoneSpear}] - Костяное копье. Наносит врагу {boneSpearDamage} урона." +
                $"\n [{SpellDrainLife}] - Вытягивание жизни. Наносит врагу {drainLifeAmount} урона и лечит вас на {drainLifeAmount}." +
                $"\n [{SpellAcidShield}] - Кислотный щит. Защищает от одного источника физического и кислотного урона" +
                $"\n [{SpellAcidRain}] - кислотный дождь. Наносит вам и врагу {acidRainDamage} кислотного урона";

            Console.WriteLine("Ваше некромантское логово выследил Рыцарь света!" +
                "\nТолько ваши магические способности могут указать его место!" +
                "\nУничтожьте его и превратите в своего раба!");

            while (playerHealth > 0 && bossHealth > 0)
            {
                Console.WriteLine($"\nВаше здоровье: {playerHealth}. Здоровье Рыцаря света: {bossHealth}.\n");
                Console.WriteLine(optionsMessage);
                Console.Write("Выберите заклинание: ");

                string input = Console.ReadLine();

                switch (input)
                {
                    case SpellBoneSpear:
                        bossHealth -= boneSpearDamage;
                        break;

                    case SpellDrainLife:
                        bossHealth -= drainLifeAmount;
                        playerHealth += drainLifeAmount;
                        break;

                    case SpellAcidShield:
                        damageResistance = true;
                        acidResistance = true;
                        break;

                    case SpellAcidRain:
                        bossHealth -= acidRainDamage;

                        if (acidResistance == true)
                        {
                            acidResistance = false;
                            Console.WriteLine("Ваша защита от кислотного урона закончилась!");
                        }
                        else
                        {
                            playerHealth -= acidRainDamage;
                        }

                        break;

                    default:
                        Console.WriteLine("Такого заклинания нет! Вы зря потратили время.");
                        break;
                }

                if (bossHealth <= 0)
                {
                    break;
                }
                if (damageResistance == true)
                {
                    damageResistance = false;
                    Console.WriteLine("Враг снял вашу защиту от физического урона!");
                }
                else
                {
                    playerHealth -= bossDamage;
                    Console.WriteLine($"Враг нанес вам {bossDamage} урона!");
                }
            }

            if(playerHealth <= 0)
                Console.WriteLine("Вы проиграли! Ваш труп будет кормить червей.");
            else
                Console.WriteLine("Вы победили! Труп Рыцаря света стал вашей ручной собачкой");
        }
    }
}