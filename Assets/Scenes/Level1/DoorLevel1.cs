using UnityEngine;

public class DoorLevel1 : MonoBehaviour
{

    [SerializeField] Transform door;
    [SerializeField] float moveSpeed = 10;
    [SerializeField] Vector3 offsetPosition;

    [SerializeField] Vector3 startPos;
    [SerializeField] bool isOpen = false;

    void Update()
    {
        if (isOpen)
        {
            door.position = Vector3.MoveTowards(door.position, offsetPosition, moveSpeed * Time.deltaTime);
        }
        else
        {
            door.position = Vector3.MoveTowards(door.position, startPos, moveSpeed * Time.deltaTime);
        }
    }

    void OnTriggerStay(Collider other)
    {
        isOpen = true;
    }

    private void OnTriggerExit(Collider other)
    {
        isOpen = false;
    }
}
