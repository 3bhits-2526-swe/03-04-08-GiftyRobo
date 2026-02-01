using System;
using UnityEngine;

public class GiftManagement : MonoBehaviour
{
    public static GiftManagement Instance { get; private set; }

    [SerializeField] private GameObject giftPrefab;
    [SerializeField] private GameState _gameState;

    private void Awake()
    {
        Instance = this;
    }

    public void DespawnGift(Collider2D gift)
    {
        Destroy(gift.gameObject);
    }

    public void SpawnGift(Collider2D other)
    {
        Transform giftTransform = SpawnManager.FetchRandomGiftSpawn();
        GameObject gift = Instantiate(giftPrefab, giftTransform.position, Quaternion.identity);
        _gameState.UnequipGift();
    }

    private void EquipGift(Collider2D gift)
    {
        gift.transform.SetParent(FindFirstObjectByType<Player>().transform);
        _gameState.EquipGift();
    }

    private void Start()
    {
        SpawnGift(new Collider2D());
    }


    private void OnEnable()
    {
        //Player.OnTouchGift += DespawnGift;
        Player.OnTouchGift += EquipGift;
        Player.OnTouchCat += SpawnGift;
    }

    private void OnDisable()
    {
        Player.OnTouchGift -= EquipGift;
        Player.OnTouchGift -= DespawnGift;
        Player.OnTouchCat -= SpawnGift;
    }
}