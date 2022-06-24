using UnityEngine;
using UnityEngine.SceneManagement;

public class game_over_script : MonoBehaviour
{
    
    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown) {
            if(storySlideState.state == storySlideState.STATES.TUTORIAL1)
                SManager.loadScene("tutorial1");
            if (storySlideState.state == storySlideState.STATES.ERSTESLEVEL)
                SManager.loadScene("Level1");
            if (storySlideState.state == storySlideState.STATES.BOSSLEVEL)
                SManager.loadScene("Level2");
        }
    }
}
