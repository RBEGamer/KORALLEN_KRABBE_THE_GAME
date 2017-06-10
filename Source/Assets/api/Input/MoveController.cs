using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveController : MonoBehaviour
{
    [Header("Assign")]
    public Camera GameCamera;
    public Transform MoveObject;

    private void LateUpdate()
    {
        if (Input.GetMouseButtonUp(0))
        {
            FindNextWayPoint();
        }
    }

    void FindNextWayPoint()
    {
        var ray = GameCamera.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if (Physics.Raycast(ray, out hit, 100, API.Current.Globals.NavMeshLayer))
        {
            var point = hit.point;
            MoveObject.position = point;
        }
    }
}
