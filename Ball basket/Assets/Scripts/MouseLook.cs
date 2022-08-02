using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float sensX;
    public float sensY;

    public Transform orientation;  //Transform for player orientation.

    float xRotation;
    float yRotation;
   private void Start()
    {
        //Lock cursor in the middle + make it invisible;
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false; 
    }

   private void Update()
    {
        //Get mouse input
        float mouseX = Input.GetAxisRaw("Mouse X") * Time.deltaTime * sensX;
        float mouseY = Input.GetAxisRaw("Mouse Y") * Time.deltaTime * sensY;

        yRotation += mouseX;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f); //lock camera so it doesn't go over head.

        //rotate camera + orientation.
        transform.rotation = Quaternion.Euler(xRotation, yRotation, 0);
        orientation.rotation = Quaternion.Euler(xRotation, yRotation, 0);
    }
}
