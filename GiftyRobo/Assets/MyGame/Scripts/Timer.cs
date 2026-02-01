using UnityEngine;

public class LevelTimer : MonoBehaviour
{
    public float Seconds { get; private set; }
    private bool isRunning;

    private void Awake()
    {
        Seconds = 0f;
        isRunning = true;
    }

    private void OnEnable()
    {
        EndLevel.OnLevelComplete += StopTimer;
    }

    private void OnDisable()
    {
        EndLevel.OnLevelComplete -= StopTimer;
    }

    private void Update()
    {
        if (!isRunning) return;
        Seconds += Time.deltaTime;
    }

    private void StopTimer()
    {
        isRunning = false;
    }
}