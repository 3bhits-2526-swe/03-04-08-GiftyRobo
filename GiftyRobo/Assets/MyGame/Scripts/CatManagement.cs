using System;
using UnityEngine;
using UnityEngine.Serialization;

public class CatManagement : MonoBehaviour
{
    public static CatManagement Instance { get; private set; }
    [SerializeField] private GameObject catPrefab;
    [SerializeField] private GameState gameState;

    private void Awake()
    {
        Instance = this;
    }

    public void DespawnCat(Collider2D cat)
    {
        Destroy(cat.gameObject);
        gameState.CatsRemaining -= 1;
    }

    public void SpawnCat(Vector2 position)
    {
        GameObject cat = Instantiate(catPrefab, position, Quaternion.identity);
        gameState.CatsRemaining += 1;
    }

    private void OnEnable()
    {
        Player.OnTouchCat += DespawnCat;
    }

    private void OnDisable()
    {
        Player.OnTouchCat -= DespawnCat;
    }

    private void Start()
    {
        for (int i = 0; i < 1; i++)
        {
            SpawnCat(SpawnManager.FetchRandomCatSpawn().position);
        }
    }
}