using System;

namespace Controllers
{
    public class ChoiceResulter : IChoiceResulter
    {
        public string GetResult(ActionType playerChoices, ActionType aiChoices)
        {
            return CompareChoices(playerChoices, aiChoices) switch
            {
                WinnerType.None => "The game ended in a draw... ".ToUpper(),
                WinnerType.Player => "You win!!!".ToUpper(),
                WinnerType.Opponent => "You lose".ToUpper(),
                _ => throw new ArgumentOutOfRangeException()
            };
        }

        private WinnerType CompareChoices(ActionType playerType, ActionType opponentType)
        {
            var result = WinnerType.None;

            result = playerType switch
            {
                ActionType.Attack => opponentType switch
                {
                    ActionType.Attack => WinnerType.None,
                    ActionType.Move => WinnerType.Player,
                    ActionType.Cover => WinnerType.Opponent,
                    _ => result
                },
                ActionType.Move => opponentType switch
                {
                    ActionType.Attack => WinnerType.Opponent,
                    ActionType.Move => WinnerType.None,
                    ActionType.Cover => WinnerType.Player,
                    _ => result
                },
                ActionType.Cover => opponentType switch
                {
                    ActionType.Attack => WinnerType.Player,
                    ActionType.Move => WinnerType.Opponent,
                    ActionType.Cover => WinnerType.None,
                    _ => result
                },
                _ => result
            };

            return result;
        }
    }

    public enum WinnerType
    {
        None,
        Player,
        Opponent
    }
}