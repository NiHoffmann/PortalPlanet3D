using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    public float mouseSensitivity = 100f;
    public Transform playerBody;
    public static float xRotation = 0f;
    public static float yRotation = 0f;
    public static float zRotation;
    public static bool free = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        xRotation = transform.rotation.eulerAngles.x;
        yRotation = transform.rotation.eulerAngles.y;
        zRotation = transform.rotation.eulerAngles.z;
    }

    // Update is called once per frame
    void Update()
    {
        if (!free) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        yRotation += mouseX;
        
        while (xRotation > 90f) {
            xRotation -= 90f;
        }
        while(xRotation > 90f)
        {
            xRotation -= 90f;
        }

        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        playerBody.transform.rotation = Quaternion.Euler(playerBody.transform.eulerAngles.x, yRotation, playerBody.transform.eulerAngles.z);
     
    }

}
