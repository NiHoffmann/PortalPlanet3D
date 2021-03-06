using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // If the player character is on ground
    public static bool isGrounded = true;
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
        if (body.transform.position.y < -40f) {
            SceneManager.LoadScene("game_over");
        }
    }

    private void OnCollisionStay(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    private void doKeyMovement(Rigidbody body)
    {

        Vector3 forward = Camera.main.transform.forward;
        Vector3 right = Camera.main.transform.right;
        forward.y = 0;
        right.y = 0;


        if (Input.GetKey(KeyCode.W))
        {
            body.transform.position += forward.normalized * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.S))
        {
            body.transform.position += (forward.normalized * -1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.A))
        {
            body.transform.position += (right.normalized * -1) * Time.deltaTime * movementSpeed;
        }
        if (Input.GetKey(KeyCode.D))
        {
            body.transform.position += right.normalized * Time.deltaTime * movementSpeed;
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
