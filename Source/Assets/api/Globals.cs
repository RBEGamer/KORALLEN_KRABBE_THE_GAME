using UnityEngine;
using UnityEditor;

public class Globals : MonoBehaviour
{
    public LayerMask NavMeshLayer;
    public int MaxGarbagePerArea = 20;
	public string player_obj_name = "player";



	public enum GAME_STATES
	{
		GS_SPAWN,
		GS_MENU,
		GS_PLAYING,
		GS_DIE
	}

	public GAME_STATES game_state = GAME_STATES.GS_MENU;
}