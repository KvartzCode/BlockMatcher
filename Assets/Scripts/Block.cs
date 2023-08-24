using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Block : MonoBehaviour
{
    public int ID = -1;
    public bool isSnapped = false;

    private float CameraZDistance;


    void Start()
    {
        CameraZDistance = Camera.main.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }


    public void MoveBlock()
    {
        Vector3 ScreenPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition = Camera.main.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out var hit, 1000, 1 << 8))
        {
            transform.position = (hit.point + hit.normal).RoundOff(10);
            isSnapped = true;
        }
        else
        {
            transform.position = NewWorldPosition;
            isSnapped = false;
        }
    }


    private void OnMouseDrag()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        gameObject.layer = 7;
        MoveBlock();
    }

    private void OnMouseUp()
    {
        if (EventSystem.current.IsPointerOverGameObject())
            return;

        gameObject.layer = 8;
    }
}
