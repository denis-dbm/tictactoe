using System;
using System.ComponentModel;

namespace TicTacToe
{
    public class TicTacToe
    {
        public const byte FirstPosition = 1;
        public const byte LastPosition = 9;
        private readonly PlayerSymbol[] _positions = new PlayerSymbol[9];

        public TicTacToe(PlayerSymbol startByPlayer = PlayerSymbol.Circle)
        {
            if (!Enum.IsDefined(startByPlayer) || startByPlayer == PlayerSymbol.None)
                throw new InvalidEnumArgumentException($"Player should be {PlayerSymbol.Circle} or {PlayerSymbol.Cross}.");

            PlayerTurn = startByPlayer;
        }

        public PlayerSymbol PlayerTurn { get; private set; }

        public bool IsFinished { get; private set; }

        public PlayerSymbol Winner { get; private set; }

        public static TicTacToe Rematch(TicTacToe lastRoundGame)
        {
            if (!lastRoundGame.IsFinished)
                throw new InvalidOperationException("Last round game was not finished. Play it!");

            return new TicTacToe(lastRoundGame.PlayerTurn);
        }

        public PlayerSymbol[] GetPositions() => (PlayerSymbol[])_positions.Clone();

        public void PlayTurn(byte position)
        {
            if (IsFinished)
                throw new InvalidOperationException("Game was finished. Please, start a new one.");

            if (position < FirstPosition || position > LastPosition)
                throw new ArgumentOutOfRangeException(nameof(position), position, $"Position should be a number between {FirstPosition} and {LastPosition}.");

            position -= 1;

            if (_positions[position] != PlayerSymbol.None)
                throw new InvalidOperationException($"Position {position + 1} is occupied by {_positions[position]}.");

            _positions[position] = PlayerTurn;

            CheckForWinner();

            if (!IsFinished)
                PlayerTurn = (PlayerTurn == PlayerSymbol.Circle) ? PlayerSymbol.Cross : PlayerSymbol.Circle;
        }

        private void CheckForWinner()
        {
            bool isFinished = true;
            bool hasWinner = 
                ((_positions[0] & _positions[1]  & _positions[2]) == PlayerTurn) ||
                ((_positions[3] & _positions[4]  & _positions[5]) == PlayerTurn) ||
                ((_positions[6] & _positions[7]  & _positions[8]) == PlayerTurn) ||
                
                ((_positions[0] & _positions[3]  & _positions[6]) == PlayerTurn) ||
                ((_positions[1] & _positions[4]  & _positions[7]) == PlayerTurn) ||
                ((_positions[2] & _positions[5]  & _positions[8]) == PlayerTurn) ||
                
                ((_positions[0] & _positions[4]  & _positions[8]) == PlayerTurn) ||
                ((_positions[2] & _positions[4]  & _positions[6]) == PlayerTurn);

            for (int i = 0; i < LastPosition; i++)
                if (_positions[i] == PlayerSymbol.None)
                {
                    isFinished = false;
                    break;   
                }
            
            if (hasWinner)
            {
                Winner = PlayerTurn;
                IsFinished = true;
            }
            else
            {
                IsFinished = isFinished;
            }
        }
    }
}