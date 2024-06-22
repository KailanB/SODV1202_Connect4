namespace SODV1202_Connect4.Common
{
    internal static class Messages
    {
        public static void ShowErrorMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red; //Change the color of messages to red
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White; //Change to the default color
        }
        public static void ShowWarningMessage(string message)
        {
            Console.ForegroundColor = ConsoleColor.Yellow; //Change the color of messages to yellow
            Console.WriteLine(message);
            Console.ForegroundColor = ConsoleColor.White; //Change to the default color
        }
    }
}
