using System;
using UnityEngine;

[CreateAssetMenu(fileName = "GameState", menuName = "Scriptable Objects/GameState")]
public class GameState : ScriptableObject
{
    [Header("Input States")]
    [SerializeField] private InputObjectState joystickLR;
    [SerializeField] private InputObjectState joystickBT;
    [SerializeField] private InputObjectState buttonA;

    [Header("Game State")]
    [SerializeField] private SpawnManager spawnManager;
    public enum GiftState
    {
        Spawned,
        Equipped,
    }
    
    public GiftState giftState;
    private int _catsRemaining;
    public bool LevelComplete { get; private set; }

    public int CatsRemaining
    {
        get { return _catsRemaining;  }
        set
        {
            if (value is < 0 or > 5)
                throw new ArgumentOutOfRangeException(nameof(value), "X must be in range [0, 5]");

            int previous = _catsRemaining;
            _catsRemaining = value;

            // Only complete when you actually go from some cats to none
            if (!LevelComplete && previous > 0 && _catsRemaining == 0)
            {
                LevelComplete = true;
                EndLevel.CompleteLevel(); // use your wrapper if you have it
                // or: EndLevel.OnLevelComplete?.Invoke();
            }
        }
    }

    public void ResetState()
    {
        giftState = GiftState.Spawned;
        CatsRemaining = 0;
        LevelComplete = false;
    }

    public void EquipGift()
    {
        giftState = GiftState.Equipped;
    }

    public void UnequipGift()
    {
        giftState = GiftState.Spawned;
    }

    private void OnEnable()
    {
        //ResetState();
        ResetForNewRun();
    }
    
    public void ResetToDefaults()
    {
        // Reset without firing end-level logic.
        LevelComplete = false;
        _catsRemaining = 0;
        giftState = GiftState.Spawned;
    }
    public void ResetForNewRun()
    {
        giftState = GiftState.Spawned;

        // Set backing field directly to avoid completion logic
        _catsRemaining = 0;

        LevelComplete = false;

        joystickLR.ResetState();
        joystickBT.ResetState();
        buttonA.ResetState();
    }

}