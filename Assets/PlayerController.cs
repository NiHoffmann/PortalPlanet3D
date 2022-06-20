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
    [SerializeField] Rigidbody body;
    void Start()
    {
    }

    void Update()
    {
        doKeyMovement(body);
        doJump(body);
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

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;


        if (Input.GetKey(KeyCode.W))
        {
            transform.position += forward.normalized * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            rigidbody.position += (forward.normalized * -1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            rigidbody.position += (right.normalized * -1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            rigidbody.position += right.normalized * Time.deltaTime * movementSpeed;
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
