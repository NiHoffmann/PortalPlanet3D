using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class storySlide : MonoBehaviour
{
    [SerializeField] Sprite[] tutorial = new Sprite[5];
    [SerializeField] string[] text = new string[5];
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
            counter -= 1;

        if (storySlideState.state == storySlideState.STATES.TUTORIAL)
        {
            if (counter >= tutorial.Length) {
                SceneManager.LoadScene(tutorialScene);
                return;
            }

            setTexture(tutorial[counter]);
            TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();
            tmp.SetText(text[counter].Substring(3));

            if (text[counter].Substring(0, 3).Equals("[b]")) {
                tmp.color = Color.black;
            }
            if (text[counter].Substring(0, 3).Equals("[w]"))
            {
                tmp.color = Color.white;
            }
        }
    }
}

