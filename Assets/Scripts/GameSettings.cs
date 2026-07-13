using UnityEngine;

public enum Difficulty
{
    Easy,
    Medium,
    Hard
}

public static class GameSettings
{
    public static Difficulty difficulty = Difficulty.Medium;
}