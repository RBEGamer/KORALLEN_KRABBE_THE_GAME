using UnityEngine;

public class API : MonoBehaviour
{
    public static API Current;

    public Globals Globals;
    public GlobalEvents GlobalEvents;

    private void Awake()
    {
        Current = this;
    }
}