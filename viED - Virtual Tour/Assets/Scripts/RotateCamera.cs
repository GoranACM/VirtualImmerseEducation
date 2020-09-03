using UnityEngine;
using System.Collections;

public class RotateCamera : MonoBehaviour
{

    public float speed = 0.5f;
    public Transform rotorY;
    public Transform rotorX;

    private Vector3 dragStart;
    private Vector3 dragDelta;
    private Vector3 initialEulers;

    void Start()
    {
        dragDelta = Vector3.zero;
    }

    void Update()
    {
        Rotation();
        Zoom();
    }

    private void Rotation()
    {
        //start mouse drag
        if (Input.GetMouseButtonDown(0))
        {
            dragStart = Input.mousePosition;
            initialEulers = new Vector3(rotorX.localEulerAngles.x, rotorY.localEulerAngles.y, 0f);
        }
        //drag process
        else if (Input.GetMouseButton(0))
        {
            //find amount of drag
            dragDelta = Input.mousePosition - dragStart;

            //apply y rotation
            Vector3 eulers = rotorY.localEulerAngles;
            eulers.y = initialEulers.y - dragDelta.x * speed;
            rotorY.localEulerAngles = eulers;

            //apply x rotation
            eulers = rotorX.localEulerAngles;
            eulers.x = initialEulers.x + dragDelta.y * speed;

            //Unity 5.5.0: bring rotation range to [-180, 180] interval, instead of default [0, 360]
            if (eulers.x > 180f)
                eulers.x -= 360f;

            eulers.x = Mathf.Clamp(eulers.x, -89.9f, 89.9f);    //so that rotation does not go on vertical flip
            rotorX.localEulerAngles = eulers;
        }
    }

    private void Zoom()
    {
        //int travel = 0;
        /*int scrollSpeed = 3;

        var d = Input.GetAxis("Mouse ScrollWheel");
        if (d > 0f && travel > -30)
        {
            travel = travel - scrollSpeed;
            Camera.main.transform.Translate(0, 0, 1 * scrollSpeed, Space.Self);
        }
        else if (d < 0f && travel < 100)
        {
            travel = travel + scrollSpeed;
            Camera.main.transform.Translate(0, 0, -1 * scrollSpeed, Space.Self);
        }*/

        float ScrollWheelChange = Input.GetAxis("Mouse ScrollWheel");

        if (ScrollWheelChange != 0)      //If the scrollwheel has changed
        {                                            
            float R = ScrollWheelChange * 15;                                   //The radius from current camera
            float PosX = Camera.main.transform.eulerAngles.x + 90;              //Get up and down
            float PosY = -1 * (Camera.main.transform.eulerAngles.y - 90);       //Get left to right
            PosX = PosX / 180 * Mathf.PI;                                       //Convert from degrees to radians
            PosY = PosY / 180 * Mathf.PI;                                       
            float X = R * Mathf.Sin(PosX) * Mathf.Cos(PosY);                    //Calculate new coords
            float Z = R * Mathf.Sin(PosX) * Mathf.Sin(PosY);                    
            float Y = R * Mathf.Cos(PosX);                                      
            float CamX = Camera.main.transform.position.x;                      //Get current camera postition for the offset
            float CamY = Camera.main.transform.position.y;                      
            float CamZ = Camera.main.transform.position.z;                      
            Camera.main.transform.position = new Vector3(CamX + X, CamY + Y, CamZ + Z);//Move the main camera

            // Put a condition to be able to stop the zoom
            /*if (CamZ > -1.5 && CamZ < 5)
            {
                Camera.main.transform.position = new Vector3(CamX + X, CamY + Y, CamZ + Z);
            }*/

        }

    }
}