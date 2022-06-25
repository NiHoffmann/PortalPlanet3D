using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenu : MonoBehaviour
{

    [SerializeField] GameObject canvasMenu;
    [SerializeField] GameObject gameOverlay;
    [SerializeField] bool open = false;
    [SerializeField] Button exit;
    [SerializeField] Button restart;
    [SerializeField] Button save;
    [SerializeField] string currentLevel;


    void Start()
    {
        save.onClick.AddListener(SaveButton);
        exit.onClick.AddListener(ExitButton);
        restart.onClick.AddListener(RestartButton);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            if (open) {
                gameOverlay.SetActive(true);
                canvasMenu.SetActive(false);
                Time.timeScale = 1;
                Cursor.lockState = CursorLockMode.Locked;
                open = false;
            }
            else
            {
                gameOverlay.SetActive(false);
                canvasMenu.SetActive(true);
                Time.timeScale = 0;
                Cursor.lockState = CursorLockMode.None;
                open = true;
            }
        }
    }

    private void SaveButton() 
    {
        ReadFile.WriteString("save", currentLevel);
        save.image.color = Color.green;
    }

    private void ExitButton()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.None;
        SceneManager.LoadScene("main_menu");
    }
    private void RestartButton()
    {
        Time.timeScale = 1;
        Cursor.lockState = CursorLockMode.Locked;
        SManager.loadScene(currentLevel);
    }

}
