using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class loadingScreen : MonoBehaviour
{
    [SerializeField] Sprite[] loading;
    [SerializeField] string[] toolTips;
    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    float elapsed = 0f;
    int counter = 0;

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
            if(counter == 0)
                textField.GetComponent<TextMeshProUGUI>().SetText(toolTips[Random.Range(0, (toolTips.Length))]);
        }
    }

}
