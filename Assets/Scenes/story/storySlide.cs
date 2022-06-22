using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class storySlide : MonoBehaviour
{
    [SerializeField] Sprite[] tutorial1 = new Sprite[5];
    [SerializeField] string[] text1 = new string[5];
    [SerializeField] Sprite[] erstesLevel = new Sprite[5];
    [SerializeField] string[] textErstesLevel = new string[5];
    [SerializeField] string tutorialScene;
    [SerializeField] string ertesLevelScene;
    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    [SerializeField] AudioSource flipSound;
    int counter = 0;

    public void setTexture(Sprite s) {
        slideImage.texture = s.texture;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            counter += 1;
            flipSound.Play();
        }

        if (Input.GetMouseButtonDown(1))
        {
            flipSound.Play();
            if (counter == 0)
            {
                return;
            }
            counter -= 1;
        }

        if (storySlideState.state == storySlideState.STATES.TUTORIAL1)
        {
            if (counter >= tutorial1.Length)
            {
                storySlideState.state = storySlideState.STATES.ERSTESLEVEL;
                counter = 0;
                SManager.loadScene(tutorialScene);
                return;
            }

            setTexture(tutorial1[counter]);
            setText(text1);
        }


        if (storySlideState.state == storySlideState.STATES.ERSTESLEVEL)
        {
            if (counter >= erstesLevel.Length)
            {
                counter = 0;
                SManager.loadScene(ertesLevelScene);
                return;
            }

            setTexture(erstesLevel[counter]);
            setText(textErstesLevel);
        }
    }

    void setText(string[] text) {
        TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();
        if (text[counter].Length > 3)
        {
            if (text[counter].Substring(0, 3).Equals("[b]"))
            {
                tmp.color = Color.black;
            }
            if (text1[counter].Substring(0, 3).Equals("[w]"))
            {
                tmp.color = Color.white;
            }
            if (text1[counter].Substring(0, 3).Equals("[r]"))
            {
                tmp.color = Color.red;
            }
        }
        tmp.SetText(text[counter].Substring(3));
    }
}

