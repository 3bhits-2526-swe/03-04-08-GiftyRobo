using System;
using UnityEngine;

public static class EndLevel
{
    public static Action OnLevelComplete;

    public static void CompleteLevel()
    {
        OnLevelComplete?.Invoke();
    }
}