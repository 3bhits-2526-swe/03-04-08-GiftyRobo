using UnityEngine;

public class LevelEndscreen : MonoBehaviour
{
    [SerializeField] private GameObject endscreen;
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        endscreen.SetActive(false); // garantiert "aus" am Anfang
    }

    private void OnEnable()
    {
        endscreen.SetActive(false);

        EndLevel.OnLevelComplete += RevealEndscreen;

        if (gameState != null && gameState.LevelComplete)
            RevealEndscreen();
    }

    private void OnDisable()
    {
        EndLevel.OnLevelComplete -= RevealEndscreen;
        if (endscreen != null)
        {
            endscreen.SetActive(false);
        }
    }
    
    private void RevealEndscreen()
    {
        endscreen.SetActive(true);
    }
}
