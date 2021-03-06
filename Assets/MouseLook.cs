using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{
    [SerializeField] Transform lookAtStarting;
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
        lookAt(lookAtStarting);
    }

    public void lookAt(Transform lookAt)
    {

        transform.LookAt(lookAt);

        xRotation = transform.eulerAngles.x;
        yRotation = transform.eulerAngles.y;
        zRotation = transform.eulerAngles.z;

        rotate();

    }

    // Update is called once per frame
    void Update()
    {
     
        if (!free) return;

        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;
        yRotation += mouseX;

        rotate();
    }

    float clamp(float value, float min, float max)
    {
        if (value >= 0)
        {
            float value_tmp = value - min;
            if (value_tmp >= 360)
            {
                value_tmp -= 360;
            }
            return Mathf.Clamp(value_tmp, 0, max - min) + min;
        }
        else
        {
            return Mathf.Clamp(value, min, 0);
        }
    }

    void rotate() {

        xRotation = clamp(xRotation, -90, 90);

        transform.rotation = Quaternion.Euler(xRotation, yRotation, zRotation);
        playerBody.transform.rotation = Quaternion.Euler(playerBody.transform.eulerAngles.x, yRotation, playerBody.transform.eulerAngles.z);
    }

}
