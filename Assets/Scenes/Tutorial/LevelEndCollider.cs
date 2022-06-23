using UnityEngine;

public class LevelEndCollider : MonoBehaviour
{
    [SerializeField] GameObject player;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.name.Equals(player.name)) {
            storySlideState.state = storySlideState.STATES.ERSTESLEVEL;
            SManager.loadScene("story");
        }
    }
}
