using System.Collections.Generic;
using System.Linq;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SpawnManager : MonoBehaviour
{
    //public readonly int catsToSpawn = 2;
    
    public static SpawnManager Instance { get; private set; }

    private static List<PlayerSpawnPoint> playerSpawnPoints;
    private static List<CatSpawnPoint> catSpawnPoints;
    private static List<GiftSpawnPoint> giftSpawnPoints;
    
    [SerializeField] private GameObject playerPrefab;
    [SerializeField] private GameObject catPrefab;
    [SerializeField] private GameObject giftPrefab;
    [SerializeField] private GameState gameState;

    private void OnEnable()
    {
        EndLevel.OnLevelComplete += DespawnPlayer;
    }

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
        giftSpawnPoints = FindObjectsByType<GiftSpawnPoint>(FindObjectsSortMode.None).ToList();

        if (playerSpawnPoints.Count < 1)
        {
            Debug.LogWarning("NO PLAYERSPAWNPOINTS FOUND IN SCENE!");
        }

        if (catSpawnPoints.Count < 1)
        {
            Debug.LogWarning("NO CATSPAWNPOINTS FOUND IN SCENE!");
        }
        if (giftSpawnPoints.Count < 1)
        {
            Debug.LogWarning("NO GIFTSPAWNPOINTS FOUND IN SCENE!");
        }
    }

    private void Start()
    {
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

        int index = UnityEngine.Random.Range(0, playerSpawnPoints.Count);
        return playerSpawnPoints[index].transform;
    }

    public static Transform FetchRandomGiftSpawn()
    {
        if (giftSpawnPoints == null || giftSpawnPoints.Count == 0)
        {
            Debug.LogError("SpawnManager not initialized or no SpawnPoints available! [GIFT]");
            return null;
        }
        int index = UnityEngine.Random.Range(0, giftSpawnPoints.Count);
        return giftSpawnPoints[index].transform;
    }

    [CanBeNull]
    public static Transform FetchRandomCatSpawn()
    {
        if (catSpawnPoints == null || catSpawnPoints.Count == 0)
        {
            Debug.LogError("SpawnManager not initialized or no SpawnPoints available! [CAT]");
            return null;
        }

        int index = UnityEngine.Random.Range(0, catSpawnPoints.Count);
        Transform spawn = catSpawnPoints[index].transform;
        catSpawnPoints.RemoveAt(index); // remove this cats spawnpoint to avoid 2 or multiple cats spawning on eachother
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

    private void DespawnPlayer()
    {
        Destroy(FindObjectsByType<Player>(FindObjectsSortMode.None)[0]);
    }
}