using UnityEngine;
using UnityEngine.SceneManagement;

public static class SManager 
{
    public static string sceeneToLoad;

    public static void loadScene(string sceene) {
        sceeneToLoad = sceene;
        SceneManager.LoadScene("loading");
    }
}
