using TMPro;
using UnityEngine;

public class TimerTextUI : MonoBehaviour
{
    [SerializeField] private LevelTimer timer;
    [SerializeField] private TextMeshProUGUI text;

    private bool finalShown;

    private void OnEnable()
    {
        finalShown = false;
        EndLevel.OnLevelComplete += ShowFinalTime;
    }

    private void OnDisable()
    {
        EndLevel.OnLevelComplete -= ShowFinalTime;
    }

    private void Update()
    {
        if (finalShown) return;

        int seconds = Mathf.FloorToInt(timer.Seconds);
        text.text = $"{seconds}s";
    }

    private void ShowFinalTime()
    {
        finalShown = true;

        int seconds = Mathf.FloorToInt(timer.Seconds);
        text.text = $"Time: {seconds}s";
    }
}