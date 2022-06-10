using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class loadingScreen : MonoBehaviour
{
    [SerializeField] Sprite[] loading;
    [SerializeField] string[] toolTips;
    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    float elapsed = 0f;
    int counter = 0;
    AsyncOperation op;

    private void Start()
    {
        textField.GetComponent<TextMeshProUGUI>().SetText(toolTips[Random.Range(0, (toolTips.Length))]);
        op = SceneManager.LoadSceneAsync(SManager.sceeneToLoad);
        op.allowSceneActivation = false;
        
    }
    // Update is called once per frame
    void Update()
    {
        elapsed += Time.deltaTime;
        //1 sekunde ist vorbei
        if (elapsed >= 1f)
        {
            elapsed = elapsed % 1f;
            counter += 1;
            counter %= loading.Length;

            slideImage.texture = loading[counter].texture;
            if (counter == 0)
            {
                op.allowSceneActivation = true;
                textField.GetComponent<TextMeshProUGUI>().SetText(toolTips[Random.Range(0, (toolTips.Length))]);    
            }
        }
    }

}
