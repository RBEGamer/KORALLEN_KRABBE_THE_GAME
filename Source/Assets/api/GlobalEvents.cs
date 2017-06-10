using UnityEngine;
using UnityEditor;

public class GlobalEvents : MonoBehaviour
{
    public event System.Action OnGameOver;
    public event System.Action OnNewSpawn;

    public void TriggerGameOver()
    {
        if (OnGameOver != null)
            OnGameOver();
    }

    public void TriggerNewSpawn()
    {
        if (OnNewSpawn != null)
            OnNewSpawn();
    }
}