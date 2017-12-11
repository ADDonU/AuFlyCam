using UnityEngine;
using System.Collections;
//Yelling Lion Studio © 2017
public class FlyCam : MonoBehaviour
{
    public float turnSpeed = 4.0f; 
    public float panSpeed = 4.0f; 
    public float zoomSpeed = 4.0f;
    public bool noCursor = false;
    private Vector3 mouseOrigin;
    private bool isPanning;
    private bool isRotating;
    private bool isZooming; 
    void Update()
    {
        if (noCursor == true)
        {
            Cursor.visible = true;
        }
        else
        {
            Cursor.visible = false;
        }
        if (Input.GetMouseButtonDown(0))
        {
            mouseOrigin = Input.mousePosition;
            isRotating = true;
        }
        if (Input.GetMouseButtonDown(1))
        {
            mouseOrigin = Input.mousePosition;
            isPanning = true;
        }
        if (Input.GetMouseButtonDown(2))
        {
            mouseOrigin = Input.mousePosition;
            isZooming = true;
        }
        if (!Input.GetMouseButton(0)) isRotating = false;
        if (!Input.GetMouseButton(1)) isPanning = false;
        if (!Input.GetMouseButton(2)) isZooming = false;
        if (isRotating)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            transform.RotateAround(transform.position, transform.right, -pos.y * turnSpeed);
            transform.RotateAround(transform.position, Vector3.up, pos.x * turnSpeed);
        }
        if (isPanning)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = new Vector3(pos.x * panSpeed, pos.y * panSpeed, 0);
            transform.Translate(move, Space.Self);
        }
        if (isZooming)
        {
            Vector3 pos = Camera.main.ScreenToViewportPoint(Input.mousePosition - mouseOrigin);

            Vector3 move = pos.y * zoomSpeed * transform.forward;
            transform.Translate(move, Space.World);
        }
    }
}