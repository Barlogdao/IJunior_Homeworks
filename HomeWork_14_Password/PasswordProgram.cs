namespace HomeWork_14_Password
{
    internal class PasswordProgram
    {
        static void Main(string[] args)
        {
            string password = "QWERTY";
            int tryCount = 3;
            string secretMessage = "Поросеночек!";
            string inputPassword;

            for (int i = 0; i < tryCount; i++)
            {
                Console.Write("Введите пароль: ");
                inputPassword = Console.ReadLine().ToUpper();

                if (inputPassword != password)
                {
                    Console.WriteLine("Введен неверный пароль.");
                    continue;
                }
                else
                {
                    Console.WriteLine(secretMessage);
                    break;
                }
            }
        }
    }
}