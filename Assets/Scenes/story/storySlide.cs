using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class storySlide : MonoBehaviour
{
    [SerializeField] Sprite[] tutorial2 = new Sprite[5];
    [SerializeField] string[] text2 = new string[5];
    [SerializeField] string tutorialScene;
    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    int counter = 0;

    public void setTexture(Sprite s) {
        slideImage.texture = s.texture;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
            counter += 1;

        if (Input.GetMouseButtonDown(1))
        {
            if (counter == 0) {
                return;
            }
            counter -= 1;
        }

        if (storySlideState.state == storySlideState.STATES.TUTORIAL2)
        {
            if (counter >= tutorial2.Length) {
                storySlideState.state = storySlideState.STATES.TUTORIAL3;
                SManager.loadScene(tutorialScene);
                return;
            }

            setTexture(tutorial2[counter]);
            TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();
            tmp.SetText(text2[counter].Substring(3));

            if (text2[counter].Substring(0, 3).Equals("[b]")) {
                tmp.color = Color.black;
            }
            if (text2[counter].Substring(0, 3).Equals("[w]"))
            {
                tmp.color = Color.white;
            }
            if (text2[counter].Substring(0, 3).Equals("[r]"))
            {
                tmp.color = Color.red;
            }

        }
    }
}

