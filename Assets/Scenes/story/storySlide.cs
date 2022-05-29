using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class storySlide : MonoBehaviour
{
    [SerializeField] Sprite[] tutorial = new Sprite[5];
    [SerializeField] string tutorialScene;
    [SerializeField] RawImage slideImage;
    int counter = 0;

    public void setTexture(Sprite s) {
        slideImage.texture = s.texture;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
            counter += 1;

        if (storySlideState.state == storySlideState.STATES.TUTORIAL)
        {
            if (counter >= tutorial.Length) {
                SceneManager.LoadScene(tutorialScene);
                return;
            }

            setTexture(tutorial[counter]);
        }
    }
}
