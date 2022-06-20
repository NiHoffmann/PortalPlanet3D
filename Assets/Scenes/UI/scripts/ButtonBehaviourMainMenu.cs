using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviourMainMenu : MonoBehaviour
{
    public string newGameScene;
    public string loadGameScene;
    public string settingsScene;

    public void OnButtonPressNewGame()
    {
        storySlideState.state = storySlideState.STATES.TUTORIAL2;
        SManager.loadScene(newGameScene);
    }

    public void OnButtonPressLoadGame()
    {
        SceneManager.LoadScene(loadGameScene);
    }

    public void OnButtonPressSettings()
    {
        SceneManager.LoadScene(settingsScene);
    }

}
