using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButtonScript : MonoBehaviour
{
    [SerializeField] private InputObjectState buttonA;
    private void PlayGame()
    {
        SceneManager.UnloadSceneAsync("MainMenu");
        SceneManager.LoadScene("MAP_0-Template", LoadSceneMode.Additive);
    }

    private void Update()
    {
        if (buttonA.state != InputObjectState.StateTypes.Neutral)
        {
            PlayGame();
        }
    }
}