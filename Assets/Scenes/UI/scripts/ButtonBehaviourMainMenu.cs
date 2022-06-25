using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviourMainMenu : MonoBehaviour
{
    public string newGameScene;
    public string loadGameScene;
    public string settingsScene;


    private void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }
    public void OnButtonPressNewGame()
    {
        storySlideState.state = storySlideState.STATES.TUTORIAL1;
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
