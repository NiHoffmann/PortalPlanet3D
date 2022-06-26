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
    [SerializeField] public GameObject objectiveTextField;
    [SerializeField] bool isEnabled = false;
    [SerializeField] ElevatorColliderScript elevatorColliderScript;
    [SerializeField] PortalGunTutorialScript portalGunTutorialScript;
    [SerializeField] AudioClip[] sounds;
    [SerializeField] AudioSource soundPlayer;
    [SerializeField] MouseLook mouseLook;
    [SerializeField] GameObject lookAt;
    public enum State
    {
        gravityGunTutorial,
        elevatorCollider,
        portalGunTutorialPickup,
        portalGunTutorialUse
    }

    //
    [SerializeField] WeaponSelection weaponSelection;

    private void Start()
    {
        mouseLook.lookAt(lookAt.transform);
        Time.timeScale = 0;
    }

    public void setTexture(Sprite s)
    {
        slideImage.texture = s.texture;
    }

    public void incrementCounter() {
        counter++;

        if (breakPoint() == -1) {
            soundPlayer.clip = sounds[(int)Random.Range(0, sounds.Length - 0.1f)];
            soundPlayer.Play();
            isEnabled = true;
        }
    }

    public int breakPoint() {
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
            return;
        }
        else {
            slideImage.gameObject.SetActive(true);
            textField.gameObject.SetActive(true);
        }
        

        if (Input.GetKeyDown(KeyCode.F))
        {
            incrementCounter();
        }

        TextMeshProUGUI objectiveText = objectiveTextField.GetComponent<TextMeshProUGUI>();

        int i = breakPoint();
        //gravity gun tutorial
        if (i == (int)State.gravityGunTutorial)
        {
            objectiveTextField.SetActive(true);
            objectiveText.SetText("Objective:Try out your Gravitygun");
            weaponSelection.gravityGunUnlocked = true;
            weaponSelection.gravityGun.isEnabled = true;
            weaponSelection.gravityGun.tutorial = true;
         
        }

        //walk to the elevator
        if (i == (int)State.elevatorCollider)
        {
            objectiveTextField.SetActive(true);
            objectiveText.SetText("Objective:Get to the Elevator");
            elevatorColliderScript.isEnabled = true;
        }

        //pick up portal gun
        if (i == (int)State.portalGunTutorialPickup) 
        {
            objectiveTextField.SetActive(true);
            objectiveText.SetText("Objective:Pick up the Portalgun");
            portalGunTutorialScript.isEnabled = true;
        }

        //use portalgun
        if (i == (int)State.portalGunTutorialUse) {
            objectiveTextField.SetActive(true);
            objectiveText.SetText("Objective:Use the Portalgun to get up");
        }

        if (i != -1) {
            return;
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
