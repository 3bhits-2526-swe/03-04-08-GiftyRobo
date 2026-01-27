using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }
    private static SpawnPoint[] spawnPoints;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        spawnPoints = FindObjectsByType<SpawnPoint>(FindObjectsSortMode.None);

        if (spawnPoints.Length == 0)
        {
            Debug.LogWarning("NO SPAWNPOINTS FOUND IN SCENE!");
        }
    }

    public static Transform FetchRandomSpawn()
    {
        if (spawnPoints == null || spawnPoints.Length == 0)
        {
            Debug.LogError("SpawnManager not initialized or no SpawnPoints available!");
            return null;
        }

        int index = Random.Range(0, spawnPoints.Length);
        return spawnPoints[index].transform;
    }
}