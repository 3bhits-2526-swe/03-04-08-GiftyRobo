using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using UnityEngine.Serialization;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager Instance { get; private set; }

    private static List<PlayerSpawnPoint> playerSpawnPoints;
    private static List<CatSpawnPoint> catSpawnPoints;
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject catPrefab;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;

        playerSpawnPoints = FindObjectsByType<PlayerSpawnPoint>(FindObjectsSortMode.None).ToList();
        catSpawnPoints = FindObjectsByType<CatSpawnPoint>(FindObjectsSortMode.None).ToList();

        if (playerSpawnPoints.Count < 1)
        {
            Debug.LogWarning("NO SPAWNPOINTS FOUND IN SCENE!");
        }

        if (catSpawnPoints.Count < 1)
        {
            Debug.LogWarning("NO CATSPAWNPOINTS FOUND IN SCENE!");
        }
    }

    private void Start()
    {
        SpawnCats();
        SpawnPlayer();
    }

    [CanBeNull]
    public static Transform FetchRandomPlayerSpawn()
    {
        if (playerSpawnPoints == null || playerSpawnPoints.Count == 0)
        {
            Debug.LogError("SpawnManager not initialized or no SpawnPoints available! [PLAYER]");
            return null;
        }

        int index = Random.Range(0, playerSpawnPoints.Count);
        return playerSpawnPoints[index].transform;
    }

    [CanBeNull]
    public static Transform FetchRandomCatSpawn()
    {
        if (catSpawnPoints == null || catSpawnPoints.Count == 0)
        {
            Debug.LogError("SpawnManager not initialized or no SpawnPoints available! [CAT]");
            return null;
        }

        int index = Random.Range(0, catSpawnPoints.Count);
        Transform spawn = catSpawnPoints[index].transform;
        catSpawnPoints.ToList();
        return spawn;
    }

    private void SpawnPlayer()
    {
        Transform? spawn = null;
        spawn = FetchRandomPlayerSpawn();
        if (null == spawn) return;
        GameObject player = Instantiate(playerPrefab, spawn.position, spawn.rotation);
        SceneManager.MoveGameObjectToScene(player, gameObject.scene);
    }

    private void SpawnCat()
    {
        Transform? spawn = null;
        while (spawn == null)
        {
            spawn = FetchRandomCatSpawn();
        }
        if (spawn == null) return;

        GameObject cat = Instantiate(catPrefab, spawn.position, spawn.rotation);
        SceneManager.MoveGameObjectToScene(cat, gameObject.scene);
    }

    private void SpawnCats()
    {
        for (int i = 0; i < 5; i++)
        {
            SpawnCat();
        }
    }
}