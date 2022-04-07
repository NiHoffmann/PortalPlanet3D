using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControll : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float playerSpeed;
    public float jumpHeight;
    public float gravityValue;
    public float accelerationSpeed;

    private void Start()
    {
        controller = gameObject.AddComponent<CharacterController>();
        gameObject.tag = "Player";
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        Vector3 relativeHorizontal = Vector3.Cross(Vector3.up, Vector3.Cross(Camera.main.transform.forward , Vector3.up)) * Input.GetAxis("Vertical");
        Vector3 realativeVertical = Vector3.Cross(Vector3.up, Vector3.Cross(Camera.main.transform.right, Vector3.up)) * Input.GetAxis("Horizontal");
        relativeHorizontal.Normalize();
        realativeVertical.Normalize();
        Vector3 move = relativeHorizontal + realativeVertical;
        //this projects to the plain BUT the vector will be shorter -> aka the ball slower forward than sides 


        controller.Move(move * Time.deltaTime * playerSpeed * accelerationSpeed);

        if (move != Vector3.zero)
        {
            gameObject.transform.forward = move;
        }

        if (groundedPlayer)
        {
            playerVelocity.y = 0;
        }
        else
        {
            playerVelocity.y += gravityValue * Time.deltaTime;
        }

        // Changes the height position of the player..
        if (Input.GetButtonDown("Jump"))
        {
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
        }

        controller.Move(playerVelocity * Time.deltaTime);
    }
}
