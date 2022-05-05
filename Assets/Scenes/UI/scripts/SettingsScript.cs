using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingsScript : MonoBehaviour
{
    public string mainMenuScene;
    public bool fullScreen;

    public void OnButtonPressBack()
    {
        SceneManager.LoadScene(mainMenuScene);
    }

    public void onDropDownValueChangeResolution(int val) {
        
        if (val == 0)
        {
            Screen.SetResolution(1600, 900, fullScreen);
        }

        if (val == 1) {
            Screen.SetResolution(1280, 960, fullScreen);
        }

    }

    public void onDropDownValueChangeWindowMode(int val) 
    {
        //Full Screen
        if(val == 0) {
            fullScreen = true;
            Screen.fullScreenMode = FullScreenMode.ExclusiveFullScreen;
        }
        //Windowed
        if (val == 1) {
            fullScreen = false;
            Screen.fullScreenMode = FullScreenMode.Windowed;
        }
    }

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

}
