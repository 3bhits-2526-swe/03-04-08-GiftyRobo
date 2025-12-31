using System.Net.Sockets;
using System.Runtime.CompilerServices;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class TriangleTest : MonoBehaviour
{
    [SerializeField] private InputObjectState buttonA;
    private void Update()
    {
        if (buttonA.state == InputObjectState.StateTypes.Positive)
        {
            Vector3 myposition = transform.position;
            myposition.y -= 0.05f;
            transform.position = myposition;
        }
    }
}