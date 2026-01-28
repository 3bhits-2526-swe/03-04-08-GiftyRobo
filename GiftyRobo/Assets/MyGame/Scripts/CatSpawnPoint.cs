using UnityEngine;

public class CatSpawnPoint : MonoBehaviour
{
    public bool Occupied { private set; get; }

    private void Awake()
    {
        Occupied = false;
    }
}