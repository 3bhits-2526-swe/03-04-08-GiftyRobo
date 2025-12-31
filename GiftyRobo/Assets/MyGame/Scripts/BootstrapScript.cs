using UnityEngine;
using UnityEngine.SceneManagement;

public class BootstrapScript : MonoBehaviour
{
    private void Awake()
    {
        SceneManager.LoadScene("Main", LoadSceneMode.Additive);
        Debug.Log("Finished bootstrapping Main");
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Additive);
        Debug.Log("Finished bootstrapping MainMenu");
    }
}
