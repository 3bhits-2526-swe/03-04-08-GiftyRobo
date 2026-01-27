using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerSpawner : MonoBehaviour
{
    [SerializeField] private GameObject playerPrefab;

    private void Start()
    {
        Debug.Log($"PlayerSpawner runs in scene: {gameObject.scene.name}");
        Transform spawn = SpawnManager.FetchRandomSpawn();
        if (spawn == null) return;

        GameObject player = Instantiate(playerPrefab, spawn.position, spawn.rotation);
        SceneManager.MoveGameObjectToScene(player, gameObject.scene);
    }
}