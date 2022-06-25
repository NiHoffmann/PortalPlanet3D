using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogLevel2 : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] string[] text;
    [SerializeField] int[] spriteNr;
    [SerializeField] int[] breakPoints;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] int[] soundNr;
    [SerializeField] int counter = 0;
    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    [SerializeField] public GameObject objectiveTextField;
    [SerializeField] bool isEnabled = false;
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] FinalBossScript finalBossScript;
    [SerializeField] WeaponSelection weaponSelection;
    bool fightingStarted = false;

    float timePassedTotal = 0;
    public enum State
    {
        fighting,
        finished
    }

    private void Start()
    {
        weaponSelection.portalGunUnlocked = false;
        weaponSelection.gravityGunUnlocked = false;
        weaponSelection.portalGun.isEnabled = false;
        weaponSelection.gravityGun.isEnabled = false;

    }

    public void setTexture(Sprite s)
    {
        slideImage.texture = s.texture;
    }

    public void incrementCounter()
    {
        counter++;
        if (breakPoint() == -1)
        {
            soundPlayer.clip = sounds[soundNr[counter]];
            soundPlayer.Play();
            isEnabled = true;
        }

    }

    public int breakPoint()
    {
        for (int i = 0; i < breakPoints.Length; i++)
        {
            if (breakPoints[i] == counter)
            {
                isEnabled = false;
                return i;
            }
        }
        return -1;
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled)
        {
            slideImage.gameObject.SetActive(false);
            textField.gameObject.SetActive(false);
        }
        else
        {
            slideImage.gameObject.SetActive(true);
            textField.gameObject.SetActive(true);

            if (Input.GetKeyDown(KeyCode.F))
            {
                incrementCounter();
            }

        }

        TextMeshProUGUI objectiveText = objectiveTextField.GetComponent<TextMeshProUGUI>();

        int i = breakPoint();
        //fighting
        if (i == (int)State.fighting)
        {
            if (!fightingStarted) {
                finalBossScript.started = true;
                weaponSelection.portalGunUnlocked = true;
                weaponSelection.gravityGunUnlocked = true;
                weaponSelection.portalGun.isEnabled = true;
                fightingStarted = true;
            }

            timePassedTotal += Time.deltaTime;

            objectiveText.SetText("Survive 1.5 Minutes : " + (int)timePassedTotal + " sec passed");
        }

        if (i == (int)State.finished) {
            storySlideState.state = storySlideState.STATES.GAMEEND;
            SManager.loadScene("story");
        }

        if (i != -1) return;

        if (counter >= text.Length)
        {
            isEnabled = false;
            return;
        }

        setTexture(sprites[spriteNr[counter]]);
        TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();
        tmp.SetText(text[counter]);
    }
}
