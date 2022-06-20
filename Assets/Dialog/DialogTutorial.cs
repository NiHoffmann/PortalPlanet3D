using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogTutorial : MonoBehaviour
{
    [SerializeField] Sprite[] sprites;
    [SerializeField] string[] text;
    [SerializeField] int[] spriteNr;
    [SerializeField] int[] breakPoints;
    [SerializeField] int counter = 0;
    [SerializeField] RawImage slideImage;
    [SerializeField] GameObject textField;
    [SerializeField] bool isEnabled = false;

    //
    [SerializeField] WeaponSelection weaponSelection;

    public void setTexture(Sprite s)
    {
        slideImage.texture = s.texture;
    }

    public void incrementCounter() {
        counter++;

        for (int i = 0; i < breakPoints.Length; i++)
        {
            if (breakPoints[i] != counter)
            {
                isEnabled = true;
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (!isEnabled)
        {
            slideImage.gameObject.SetActive(false);
            textField.gameObject.SetActive(false);
            return;
        }
        else {
            slideImage.gameObject.SetActive(true);
            textField.gameObject.SetActive(true);
        }
        

        if (Input.GetKeyDown(KeyCode.Return))
        {
            counter++;
        }

        for (int i = 0; i < breakPoints.Length; i++) {
            if (breakPoints[i] == counter)
            {
                isEnabled = false;

                //gravity gun tutorial
                if (i == 0) {
                    weaponSelection.gravityGunUnlocked = true;
                    weaponSelection.gravityGun.isEnabled = true;
                    weaponSelection.gravityGun.tutorial = true;
                }

                //walk to the elevator
                if(i == 1)
                {


                }

                return;
            }
        }

        if (counter >= text.Length) {
            isEnabled = false;
            return;
        }

        setTexture(sprites[spriteNr[counter]]);
        TextMeshProUGUI tmp = textField.GetComponent<TextMeshProUGUI>();
        tmp.SetText(text[counter]);
    }
}
