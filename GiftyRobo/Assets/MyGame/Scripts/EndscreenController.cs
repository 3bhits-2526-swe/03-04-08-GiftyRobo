using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EndLevelMenuController : MonoBehaviour
{
    [Header("Buttons (top = index 0)")]
    [SerializeField] private Button[] buttons;

    [Header("Selection Visual")]
    [SerializeField] private float selectedXOffset = 30f;

    private int selectedIndex;
    private Vector2[] originalPositions;
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        // Cache original positions once
        originalPositions = new Vector2[buttons.Length];
        for (int i = 0; i < buttons.Length; i++)
        {
            originalPositions[i] =
                buttons[i].GetComponent<RectTransform>().anchoredPosition;
        }
    }

    private void OnEnable()
    {
        selectedIndex = Mathf.Clamp(selectedIndex, 0, buttons.Length - 1);
        UpdateSelectionVisual();

        JoystickBTRotation.OnJoystickBTChange += OnJoystickBTChange;
        ButtonAInteraction.OnButtonClick += OnButtonClick;
    }

    private void OnDisable()
    {
        JoystickBTRotation.OnJoystickBTChange -= OnJoystickBTChange;
        ButtonAInteraction.OnButtonClick -= OnButtonClick;
    }

    private void OnJoystickBTChange(int stateValue)
    {
        var state = (InputObjectState.StateTypes)stateValue;

        if (state == InputObjectState.StateTypes.Positive)
            MoveSelection(-1); // up
        else if (state == InputObjectState.StateTypes.Negative)
            MoveSelection(+1); // down
    }

    private void OnButtonClick()
    {
        if (selectedIndex == 0)
            ReturnToMenu();
        else if (selectedIndex == 1)
            TryAgain();
    }

    private void MoveSelection(int delta)
    {
        selectedIndex = (selectedIndex + delta + buttons.Length) % buttons.Length;
        UpdateSelectionVisual();
    }

    private void UpdateSelectionVisual()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            RectTransform rt = buttons[i].GetComponent<RectTransform>();

            if (i == selectedIndex)
            {
                rt.anchoredPosition =
                    originalPositions[i] + Vector2.right * selectedXOffset;

                buttons[i].Select();
            }
            else
            {
                rt.anchoredPosition = originalPositions[i];
            }
        }
    }

    private void ReturnToMenu()
    {
        SceneReset.ResetBeforeExit(gameState);

        Scene myScene = SceneManager.GetActiveScene();
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        SceneManager.UnloadSceneAsync(myScene);
    }

    private void TryAgain()
    {
        SceneReset.ResetBeforeExit(gameState); // this must set LevelComplete = false
        Scene active = SceneManager.GetActiveScene();
        SceneManager.LoadScene(active.buildIndex);
    }
}