using UnityEngine;

public class ElevatorColliderScript : MonoBehaviour
{
    [SerializeField] DialogTutorial dt;
    [SerializeField] GameObject player;
    public bool isEnabled = false;

    void OnTriggerStay(Collider other)
    {
        routine(other);
    }

    void routine(Collider other) {
        if (!isEnabled) return;

        if (other.name.Equals(player.name) && dt.breakPoint() == (int)DialogTutorial.State.elevatorCollider)
        {
            dt.incrementCounter();
            isEnabled = false;
            transform.position = new Vector3(-999, -999, -999);
        }
    }
}

