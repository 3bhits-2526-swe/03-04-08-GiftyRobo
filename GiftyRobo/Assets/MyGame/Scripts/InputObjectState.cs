using UnityEngine;

[CreateAssetMenu(fileName = "InputObjectState", menuName = "Scriptable Objects/InputObjectState")]
public class InputObjectState : ScriptableObject
{
    public enum StateTypes
    {
        Neutral = 0,
        Negative = -1,
        Positive = 1
    }
    public StateTypes state;
    private void OnEnable()
    {
        state = StateTypes.Neutral;
    }
}