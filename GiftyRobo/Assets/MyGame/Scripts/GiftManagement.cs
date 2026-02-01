using UnityEngine;

public class GiftManagement : MonoBehaviour
{
    public static void DespawnGift(Collider2D gift)
    {
        Destroy(gift);
    }
}