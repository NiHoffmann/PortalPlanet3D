using UnityEngine;
using UnityEngine.SceneManagement;

public class FInalBossAttack : MonoBehaviour
{

    // Update is called once per frame

    public void shoot(Vector3 referencePoint,Vector3 player, float force ) {
        transform.position = referencePoint;

        Vector3 fromEnemyToPlayer = player - referencePoint;

        GetComponent<Rigidbody>().velocity = fromEnemyToPlayer.normalized*force;
    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Player")) {
            //GameOver
            storySlideState.state = storySlideState.STATES.BOSSLEVEL;
            SceneManager.LoadScene("game_over");
        }

        Destroy(gameObject);
    }
}
