using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Objects/GameState")]
public class GameState : ScriptableObject
{
    [SerializeField] private SpawnManager spawnManager;
    public enum GiftState
    {
        Spawned,
        Equipped,
    }
    
    public GiftState giftState;
    private int _catsRemaining;

    public int CatsRemaining
    {
        get { return _catsRemaining;  }
        set
        {
            if (value is < 0 or > 5)
            {
                throw new ArgumentOutOfRangeException(nameof(value), "X must be in range [0, 5]");
            }
            _catsRemaining = value;
        }
    }

    private void ResetState()
    {
        giftState = GiftState.Spawned;
        _catsRemaining = 5;
    }

    private void OnEnable()
    {
        ResetState();
    }
}