using System;
using static System.Console;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            TicTacToe ticTacToe = null;
            PlayerSymbol? startByPlayer = null;

            while (ticTacToe == null || !ticTacToe.IsFinished)
            {
                Clear();

                WriteLine("Welcome to TicTacToe! Let's start the game!");
                WriteLine("Which is the first player? (1 for Circle, 2 for Cross)");
                
                if (startByPlayer == null)
                    startByPlayer = ChoosePlayer();

                if (startByPlayer == PlayerSymbol.None)
                    WriteLine($"No time to validate wrong answers, buddy! The player was chosen, it is {startByPlayer}");

                RenderBoard(ticTacToe);
                PlayTurn(ticTacToe);
            }
        }

        private static PlayerSymbol ChoosePlayer()
        {
            var input = ReadLine()?.Trim();

            switch (input)
            {
                case "1":
                    return PlayerSymbol.Circle;
                case "2":
                    return PlayerSymbol.Cross;
                default:
                    return PlayerSymbol.None;
            }
        }

        private static void RenderBoard(TicTacToe ticTacToe)
        {
            char RenderPlayerSymbol(PlayerSymbol symbol)
            {
                
            }
        }

        private static void PlayTurn(TicTacToe ticTacToe)
        {

        }
    }
}