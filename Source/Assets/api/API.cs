using UnityEngine;
using UnityEditor;

public class API : MonoBehaviour
{
    public static API Current;

    public Globals Globals;

    private void Awake()
    {
        Current = this;
    }
}