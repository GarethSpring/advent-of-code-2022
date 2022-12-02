namespace AdventOfCode2022.Days;

public class Day02
{
    public int Play(List<(string, string)> input, bool altRules)
    {
        return input.Sum(game => altRules
            ? GetResultAltRules(game.Item1, game.Item2)
            : GetResult(game.Item1, game.Item2));
    }

    /// <summary>
    /// Rock = A, X. Paper = B, Y. Scissors = C, Z
    /// </summary>
    private int GetResult(string opponent, string player)
    {
        int RockScore = 1;
        int PaperScore = 2;
        int ScissorScore = 3;
        int WinScore = 6;
        int LossScore = 0;
        int DrawScore = 3;
        
        if (opponent == "A") // Rock
        {
            switch (player)
            {
                case "X":
                    return RockScore + DrawScore;
                case "Y":
                    return PaperScore + WinScore;
                case "Z":
                    return ScissorScore + LossScore;
            }
        }
        if (opponent == "B") // Paper
        {
            switch (player)
            {
                case "X":
                    return RockScore + LossScore;
                case "Y":
                    return PaperScore + DrawScore;
                case "Z":
                    return ScissorScore + WinScore;
            }
        }
        
        if (opponent == "C") // Scissors
        {
            switch (player)
            {
                case "X":
                    return RockScore + WinScore;
                case "Y":
                    return PaperScore + LossScore;
                case "Z":
                    return ScissorScore + DrawScore;
            }
        }

        throw new Exception("unrecognised input");
    }
    
    /// <summary>
    /// X Lose, Y Draw, Z Win
    /// </summary>
    /// <param name="opponent"></param>
    /// <param name="player"></param>
    /// <returns></returns>
    /// <exception cref="Exception"></exception>
    private int GetResultAltRules(string opponent, string player)
    {
        int RockScore = 1;
        int PaperScore = 2;
        int ScissorScore = 3;
        int WinScore = 6;
        int LossScore = 0;
        int DrawScore = 3;
        
        if (opponent == "A") // Rock
        {
            switch (player)
            {
                case "X": // Need to Lose
                    return ScissorScore + LossScore;
                case "Y": // Need to Draw
                    return RockScore + DrawScore;
                case "Z": // Need to Win
                    return PaperScore + WinScore;
            }
        }
        if (opponent == "B") // Paper
        {
            switch (player)
            {
                case "X": // Need to Lose
                    return RockScore + LossScore;
                case "Y": // Need to Draw
                    return PaperScore + DrawScore;
                case "Z": // Need to Win
                    return ScissorScore + WinScore;
            }
        }
        
        if (opponent == "C") // Scissors
        {
            switch (player)
            {
                case "X": // Need to Lose
                    return PaperScore + LossScore;
                case "Y": // Need to Draw
                    return ScissorScore + DrawScore;
                case "Z": // Need to Win
                    return RockScore + WinScore;
            }
        }

        throw new Exception("unrecognised input");
    }
}