namespace GameZone.ConsolePresentation.Forms
{
    public class MenuForms
    {
        public static void DisplayMenu()
        {
            Console.WriteLine("Welcome. Please enter your command: ");
            Console.WriteLine("1. Display all games");
            Console.WriteLine("2. Display all users");
            Console.WriteLine("3. Display game by id");
            Console.WriteLine("4. Display user by id");
            Console.WriteLine("5. Manage game");
            Console.WriteLine("6. Remove game");
        }

        public static void DisplayGameMenu()
        {
            Console.WriteLine("1. Add game to favorite: ");
        }
    }
}
