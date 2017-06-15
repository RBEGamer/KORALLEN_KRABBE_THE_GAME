﻿using UnityEngine;

public class GlobalEvents : MonoBehaviour
{
    public event System.Action OnGameOver;
    public event System.Action OnNewSpawn;
    public event System.Action<GarbageArea> OnGarbageAreaFull;

    public void TriggerGameOver()
    {
        if (OnGameOver != null)
            OnGameOver();
		API.Current.Globals.game_state = Globals.GAME_STATES.GS_DIE;
    }

    public void TriggerNewSpawn()
    {
        if (OnNewSpawn != null)
            OnNewSpawn();
    }

    public void TriggerGarbageAreaFull(GarbageArea area)
    {
        if (OnGarbageAreaFull != null)
            OnGarbageAreaFull(area);
    }



}