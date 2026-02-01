using System;

public static class SceneReset
{
    public static void ResetBeforeExit(GameState gameState)
    {
        if (gameState != null)
            gameState.ResetForNewRun();

        ClearStaticEvents();
    }

    private static void ClearStaticEvents()
    {
        // EndLevel
        EndLevel.OnLevelComplete = null;

        // Input buses
        JoystickBTRotation.OnJoystickBTChange = null;
        JoystickLRRotation.OnJoystickLRChange = null;
        ButtonAInteraction.OnButtonClick = null;

        // Player touch buses
        Player.OnTouchGift = null;
        Player.OnTouchCat = null;
    }
}