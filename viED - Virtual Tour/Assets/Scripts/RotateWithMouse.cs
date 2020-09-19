using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Security.Cryptography;
using UnityEngine;

public class RotateWithMouse : MonoBehaviour
{
    public float Speed = 5;

    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.eulerAngles += Speed * new Vector3(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
        }

        Zoom();
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
