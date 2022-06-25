using UnityEngine.SceneManagement;
using UnityEngine;

public class ButtonBehaviourMainMenu : MonoBehaviour
{
    public string newGameScene;
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
        storySlideState.state = storySlideState.STATES.TUTORIAL1;
        try
        {
            string saveFile = ReadFile.ReadString("save");
            if (saveFile.Contains("Level1"))
            {
                storySlideState.state = storySlideState.STATES.ERSTESLEVEL;
            }
            else
        if (saveFile.Contains("Level2"))
            {
                storySlideState.state = storySlideState.STATES.BOSSLEVEL;
            }
            else
            {
                OnButtonPressNewGame();
                return;
            }
        }
        catch
        {

        }
        finally {
            SceneManager.LoadScene("story");
        }   
    }

    public void OnButtonPressSettings()
    {
        SceneManager.LoadScene(settingsScene);
    }

}
