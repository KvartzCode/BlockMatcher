using System;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class Move3D : MonoBehaviour
{
    private Camera mainCamera;
    private float CameraZDistance;


    void Start()
    {
        mainCamera = Camera.main;
        CameraZDistance =
            mainCamera.WorldToScreenPoint(transform.position).z; //z axis of the game object for screen view
    }


    public void MoveBlock()
    {
        Vector3 ScreenPosition =
            new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        Vector3 NewWorldPosition =
            mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        
        if (Physics.Raycast(ray, out var test, 1000, 1 << 8))
        {
            transform.position = (test.point + test.normal).RoundOff(10);
            //var pos = test.Where(r => r.transform != transform).OrderBy(r => r.distance).ToList();
            //Debug.LogWarning($"ray hits (excluding held block) = {pos.Count}");
            //transform.position = pos.FirstOrDefault().point.RoundOffTop(10);
            //transform.position = transform.position.RoundOff(10);
                //transform.position = new Vector3(test.point.x, test.point.y + 5, test.point.z);
                //transform.position = transform.position.RoundOff(10);
            //if (test.transform.CompareTag("Base"))
            //    transform.position = test.point.RoundOffTop(10);
            //else
            //    transform.position = test.point.RoundOff(10);

            //if (transform.position == test.transform.position)
            //    transform.position = transform.position.RoundOffUp(10);
        }
        else
            transform.position = NewWorldPosition;
    }


    void OnMouseDrag()
    {
        gameObject.layer = 7;
        MoveBlock();

        //Vector3 ScreenPosition =
        //    new Vector3(Input.mousePosition.x, Input.mousePosition.y, CameraZDistance); //z axis added to screen point 
        //Vector3 NewWorldPosition =
        //    mainCamera.ScreenToWorldPoint(ScreenPosition); //Screen point converted to world point

        //transform.position = NewWorldPosition;
        //transform.position = NewWorldPosition.RoundOff(10);
    }

    private void OnMouseUpAsButton()
    {
        gameObject.layer = 8;
    }
}