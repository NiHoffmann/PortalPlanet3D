using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // If the player character is on ground
    public bool isGrounded = true;
    // How fast the player should move (wasd)
    public float movementSpeed = 5.0f;
    // How high the player should jump (space)
    public float jumpHeight = 4.5F;

    public Transform camera;

    void Start()
    {
    }

    void Update()
    {
        Rigidbody rigidbody = GetComponent<Rigidbody>();
        doKeyMovement(rigidbody);
        doJump(rigidbody);
    }

    void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Entered");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        Debug.Log("Exited");
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void doKeyMovement(Rigidbody rigidbody)
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += Camera.main.transform.forward * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.position += (Camera.main.transform.forward * -1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.position += (Camera.main.transform.right * -1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.position += Camera.main.transform.right * Time.deltaTime * movementSpeed;
        }
    }

    private void doJump(Rigidbody rigidbody)
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rigidbody.AddForce(
                new Vector3(0F, jumpHeight, 0F),
                ForceMode.VelocityChange
            );
        }
    }
}
