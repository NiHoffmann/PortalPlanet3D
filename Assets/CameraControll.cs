using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraControll : MonoBehaviour
{

    public float turnSpeed = 4.0f;
    public Transform player;
    private Vector3 offset;
    public float x;
    public float y;
    public float z;

    void Start()
    {
        offset = new Vector3(player.position.x + x, player.position.y + y, player.position.z + z);
    }

    void LateUpdate()
    {
        offset = Quaternion.AngleAxis(Input.GetAxis("Mouse X") * turnSpeed, Vector3.up) * offset;
        transform.position = player.position + offset;
        transform.LookAt(player.position);
    }

}
