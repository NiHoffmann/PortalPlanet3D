using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class storySlide : MonoBehaviour
{
    [SerializeField] AudioSource source;
    [SerializeField] Sprite[] tutorial1 = new Sprite[5];
    [SerializeField] string[] text1 = new string[5];
    [SerializeField] AudioClip tutorialClip;
    [SerializeField] Sprite[] erstesLevel = new Sprite[5];
    [SerializeField] string[] textErstesLevel = new string[5];
    [SerializeField] AudioClip erstesLevelClip;
    [SerializeField] Sprite[] bossLevel = new Sprite[5];
    [SerializeField] string[] textBossLevel = new string[5];
    [SerializeField] AudioClip bossClip;

    [SerializeField] Sprite[] gameEnd = new Sprite[5];
    [SerializeField] string[] textgameEnd = new string[5];
    [SerializeField] AudioClip gameEndClip;

    [SerializeField] Sprite[] credit = new Sprite[5];
    [SerializeField] AudioClip creditClip;

    [SerializeField] string tutorialScene;
    [SerializeField] string ertesLevelScene;
    [SerializeField] string bossLevelScene;
    [SerializeField] string gameEndScene;
    [SerializeField] string mainMenuScene;

    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    [SerializeField] AudioClip flipSound;
    Sprite current;
    int counter = 0;

    private void Start()
    {
        if (storySlideState.state == storySlideState.STATES.TUTORIAL1)
        {
            source.clip = tutorialClip;
        }
        if (storySlideState.state == storySlideState.STATES.ERSTESLEVEL) 
        {
            source.clip = erstesLevelClip;
        }
        if (storySlideState.state == storySlideState.STATES.BOSSLEVEL) {
            source.clip = bossClip;
        }

        if (storySlideState.state == storySlideState.STATES.GAMEEND) {
            source.clip = gameEndClip;
        }

        if (storySlideState.state == storySlideState.STATES.CREDITS)
        {
            source.clip = creditClip;
        }

        source.Play();
    }

    public void setTexture(Sprite s)
    {
        slideImage.texture = s.texture;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetMouseButtonDown(0))
        {
            counter += 1;
        }

        if (Input.GetMouseButtonDown(1))
        {
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
                counter = 0;
                SManager.loadScene(tutorialScene);
                return;
            }

            if (counter - 1 >= 0)
                if (!tutorial1[counter].Equals(current))
                {
                    source.PlayOneShot(flipSound);
                }

            setTex(tutorial1[counter]);
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

            if (counter >= 1)
                if (!erstesLevel[counter].Equals(current))
                {
                    source.PlayOneShot(flipSound);
                }

            setTex(erstesLevel[counter]);
            setText(textErstesLevel);
        }

        if (storySlideState.state == storySlideState.STATES.BOSSLEVEL) {
            if (counter >= bossLevel.Length)
            {
                counter = 0;
                SManager.loadScene(bossLevelScene);
                return;
            }

            if (counter - 1 >= 0)
                if (!bossLevel[counter].Equals(current))
                {
                    source.PlayOneShot(flipSound);
                }

            setTex(bossLevel[counter]);
            setText(textBossLevel);
        }

        if (storySlideState.state == storySlideState.STATES.GAMEEND)
        {
            if (counter >= gameEnd.Length)
            {
                counter = 0;
                storySlideState.state = storySlideState.STATES.CREDITS;
                SceneManager.LoadScene(gameEndScene);
                return;
            }

            if (counter - 1 >= 0)
                if (!gameEnd[counter].Equals(current))
                {
                    source.PlayOneShot(flipSound);
                }

            setTex(gameEnd[counter]);
            setText(textgameEnd);
        }

        if (storySlideState.state == storySlideState.STATES.CREDITS) {
            if (counter >= credit.Length)
            {
                counter = 0;
                storySlideState.state = storySlideState.STATES.TUTORIAL1;
                SceneManager.LoadScene(mainMenuScene);
                return;
            }

            if (counter - 1 >= 0)
                if (!credit[counter].Equals(current))
                {
                    source.PlayOneShot(flipSound);
                }

            setTex(credit[counter]);
        }
    }

    void setTex(Sprite sprite)
    {
        current = sprite;
        setTexture(current);
    }

    void setText(string[] text)
    {
        TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();
        if (text[counter].Length > 3)
        {
            if (text[counter].ToLower().Contains(("[b]").ToLower()))
            {
                tmp.color = Color.black;
            }
            if (text1[counter].ToLower().Contains(("[w]").ToLower()))
            {
                tmp.color = Color.white;
            }
            if (text1[counter].ToLower().Contains(("[r]").ToLower()))
            {
                tmp.color = Color.red;
            }
        }

        if(text[counter].Length >= 3)
            tmp.SetText(text[counter].Substring(3));
    }
}
