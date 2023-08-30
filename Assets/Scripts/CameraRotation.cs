using System.Linq;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{
    [SerializeField] Transform target;
    Vector2 angle;
    Vector3 offset;
    [SerializeField] float distance = 10;

    Vector3 lastMousePos;
    [SerializeField] float rotateSpeed = 300;
    [SerializeField] float scrollSpeed = 1;


    private void Start()
    {
        angle = new Vector2(transform.eulerAngles.x, transform.eulerAngles.y);
    }

    private void Update()
    {
        HandleNavigation();
    }


    void HandleNavigation()
    {
        var newMousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);

        if (Input.GetMouseButton(1))
        {
            Vector2 mouseDiff = (newMousePos - lastMousePos) * rotateSpeed;
            mouseDiff = new Vector2(-mouseDiff.y, mouseDiff.x);
            angle = new Vector2(angle.x + mouseDiff.x, angle.y + mouseDiff.y);
        }

        if (Input.mouseScrollDelta.y != 0)
            distance -= Input.mouseScrollDelta.y * scrollSpeed;

        Quaternion rotation = Quaternion.Euler(angle.x, angle.y, 0);
        Vector3 position = rotation * new Vector3(0, 0, -distance) + target.position + offset;

        transform.SetPositionAndRotation(position, rotation);

        lastMousePos = newMousePos;
    }
}
