using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Video;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Friend friendUnlock;

    public GameObject happinessText;
    public GameObject hungerText;
    public GameObject cleanlinessText;
    public GameObject energyText;

    public GameObject namePanel;
    public GameObject nameInput;
    public GameObject nameText;

    public GameObject friend;
    public GameObject friendPanel;
    public GameObject[] friendList;

    public Image hatOn;
    //public Image hatOff;
    public Image glassOn;
    //public Image glassOff;
    public Image maskOn;
    //public Image maskOff;
    public Image jacketOn;
    //public Image jacketOff;
    public Image shoesOn;
    //public Image shoesOff;

    public RawImage bubbleImg;

    public VideoPlayer bubbles;

    public Image[] select;

    public Text feed;
    public Text wash;
    public Text play;
    public Text sleep;

    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;
    public GameObject pointer4;

    public GameObject pointer1Press;
    public GameObject pointer2Press;
    public GameObject pointer3Press;
    public GameObject pointer4Press;

    public GameObject[] objectPointers;

    private int numOfOptions = 9;

    [SerializeField]
    private int selectedOption;

    [SerializeField]
    private bool outOfBounds;

    public GameObject[] customizationItems;

    public Animator transition;
    public Animator transitionShower;

    [SerializeField]
    private bool isHeadOn;
    [SerializeField]
    private bool isEyesOn;
    [SerializeField]
    private bool isMaskOn;
    [SerializeField]
    private bool isJacketOn;
    [SerializeField]
    private bool isShoesOn;

    public bool locked;

    int head;
    int eyes;
    int mask;
    int jacket;
    int shoes;

    private void Start()
    {
        /*if (!PlayerPrefs.HasKey("looks"))
            PlayerPrefs.SetInt("looks", 0);
        CreateFriend(PlayerPrefs.GetInt("looks"));*/

        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.None;

        PlayerPrefs.GetInt("head");

        if (PlayerPrefs.HasKey("head"))
        {
            customizationItems[0].SetActive(true);
            isHeadOn = true;
            select[0].enabled = true;
        }

        PlayerPrefs.GetInt("eyes");

        if (PlayerPrefs.HasKey("eyes"))
        {
            customizationItems[1].SetActive(true);
            isEyesOn = true;
            select[1].enabled = true;
        }

        PlayerPrefs.GetInt("mask");

        if (PlayerPrefs.HasKey("mask"))
        {
            customizationItems[2].SetActive(true);
            isMaskOn = true;
            select[2].enabled = true;
        }

        PlayerPrefs.GetInt("jacket");

        if (PlayerPrefs.HasKey("jacket"))
        {
            customizationItems[3].SetActive(true);
            isJacketOn = true;
            select[3].enabled = true;
        }

        PlayerPrefs.GetInt("shoes");

        if (PlayerPrefs.HasKey("shoes"))
        {
            customizationItems[4].SetActive(true);
            customizationItems[5].SetActive(true);
            isShoesOn = true;
            select[4].enabled = true;
        }

        selectedOption = 6;

        hatOn.color = new Color32(0, 0, 0, 20);
        //hatOff.color = new Color32(0, 0, 0, 20);
        glassOn.color = new Color32(0, 0, 0, 20);
        //glassOff.color = new Color32(0, 0, 0, 20);
        maskOn.color = new Color32(0, 0, 0, 20);
        //maskOff.color = new Color32(0, 0, 0, 20);
        jacketOn.color = new Color32(0, 0, 0, 20);
        //jacketOff.color = new Color32(0, 0, 0, 20);
        shoesOn.color = new Color32(0, 0, 0, 20);
        //shoesOff.color = new Color32(0, 0, 0, 20);

        feed.color = new Color32(255, 255, 255, 255);
        wash.color = new Color32(0, 0, 0, 0);
        play.color = new Color32(0, 0, 0, 0);
        sleep.color = new Color32(0, 0, 0, 0);

        pointer1.SetActive(true);
    }

    private void Update()
    {
        happinessText.GetComponent<Text>().text =
            "" + friend.GetComponent<Friend>().pHappiness;
        hungerText.GetComponent<Text>().text =
            "" + friend.GetComponent<Friend>().pHunger;
        cleanlinessText.GetComponent<Text>().text =
            "" + friend.GetComponent<Friend>().pCleanliness;
        energyText.GetComponent<Text>().text =
            "" + friend.GetComponent<Friend>().pEnergy;
        /*nameText.GetComponent<Text>().text =
            friend.GetComponent<Friend>().pName;*/
       
        if (friendUnlock.isLocked == false)
        {
            if (Input.GetKeyDown(KeyCode.LeftArrow) && selectedOption > 6
            || Input.GetKeyDown(KeyCode.LeftArrow) && selectedOption <= 6 && friendUnlock.hasHat != false
            || Input.GetKeyDown(KeyCode.RightArrow) && selectedOption < numOfOptions)
            {
                FindObjectOfType<AudioManager>().Play("Switch");
            }

            if (selectedOption >= 6)
                outOfBounds = false;

            if (Input.GetKeyDown(KeyCode.RightArrow) && outOfBounds == true)
            {
                selectedOption += 1;

                if (friendUnlock.hasHat != false && selectedOption > 1
                    && friendUnlock.hasGlasses == false
                    && friendUnlock.hasMask == false
                    && friendUnlock.hasJacket == false
                    && friendUnlock.hasShoes == false)
                {
                    selectedOption = 6;
                }

                else if (friendUnlock.hasGlasses != false && selectedOption > 2
                    && friendUnlock.hasMask == false
                    && friendUnlock.hasJacket == false
                    && friendUnlock.hasShoes == false)
                {
                    selectedOption = 6;
                }

                else if (friendUnlock.hasMask != false && selectedOption > 3
                    && friendUnlock.hasJacket == false
                    && friendUnlock.hasShoes == false)
                {
                    selectedOption = 6;
                }

                else if (friendUnlock.hasJacket != false && selectedOption > 4
                    && friendUnlock.hasShoes == false)
                {
                    selectedOption = 6;
                }

                else if (friendUnlock.hasShoes != false && selectedOption > 5)
                {
                    selectedOption = 6;
                }

                hatOn.color = new Color32(0, 0, 0, 20);
                //hatOff.color = new Color32(0, 0, 0, 20);
                glassOn.color = new Color32(0, 0, 0, 20);
                //glassOff.color = new Color32(0, 0, 0, 20);
                maskOn.color = new Color32(0, 0, 0, 20);
                //maskOff.color = new Color32(0, 0, 0, 20);
                jacketOn.color = new Color32(0, 0, 0, 20);
                //jacketOff.color = new Color32(0, 0, 0, 20);
                shoesOn.color = new Color32(0, 0, 0, 20);
                //shoesOff.color = new Color32(0, 0, 0, 20);

                for (int i = 0; i < objectPointers.Length; i++)
                    objectPointers[i].SetActive(false);

                feed.color = new Color32(0, 0, 0, 0);

                switch (selectedOption)
                {
                    case 1:
                        //hatOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[0].SetActive(true);
                        break;                  
                    case 2:
                        //glassOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[1].SetActive(true);
                        break;                  
                    case 3:
                        //maskOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[2].SetActive(true);
                        break;                    
                    case 4:
                        //jacketOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[3].SetActive(true);
                        break;                    
                    case 5:
                        //shoesOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[4].SetActive(true);
                        break;                   
                    case 6:
                        feed.color = new Color32(255, 255, 255, 255);
                        pointer1.SetActive(true);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.RightArrow) && outOfBounds == false /*|| Controller input*/)
            { //Input telling it to go up or down.
                selectedOption += 1;
                if (selectedOption > numOfOptions) //If at end of list go back to top
                {
                    selectedOption = numOfOptions;
                }

                hatOn.color = new Color32(0, 0, 0, 20);
                //hatOff.color = new Color32(0, 0, 0, 20);
                glassOn.color = new Color32(0, 0, 0, 20);
                //glassOff.color = new Color32(0, 0, 0, 20);
                maskOn.color = new Color32(0, 0, 0, 20);
                //maskOff.color = new Color32(0, 0, 0, 20);
                jacketOn.color = new Color32(0, 0, 0, 20);
                //jacketOff.color = new Color32(0, 0, 0, 20);
                shoesOn.color = new Color32(0, 0, 0, 20);
                //shoesOff.color = new Color32(0, 0, 0, 20);

                for (int i = 0; i < objectPointers.Length; i++)
                    objectPointers[i].SetActive(false);

                feed.color = new Color32(0, 0, 0, 0);
                wash.color = new Color32(0, 0, 0, 0);
                play.color = new Color32(0, 0, 0, 0);
                sleep.color = new Color32(0, 0, 0, 0);
                //custom.color = new Color32(0, 0, 0, 0);

                pointer1.SetActive(false);
                pointer2.SetActive(false);
                pointer3.SetActive(false);
                pointer4.SetActive(false);

                switch (selectedOption) //Set the visual indicator for which option you are on.
                {
                    /*case 1:
                        //custom.color = new Color32(0, 0, 0, 255);
                        break;*/
                    case 1:
                        //hatOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[0].SetActive(true);
                        break;
                    case 2:
                        //glassOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[1].SetActive(true);
                        break;
                    case 3:
                        //maskOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[2].SetActive(true);
                        break;
                    case 4:
                        //jacketOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[3].SetActive(true);
                        break;
                    case 5:
                        //shoesOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[4].SetActive(true);
                        break;
                    case 6:
                        feed.color = new Color32(255, 255, 255, 255);
                        pointer1.SetActive(true);
                        break;
                    case 7:
                        wash.color = new Color32(255, 255, 255, 255);
                        pointer2.SetActive(true);
                        break;
                    case 8:
                        play.color = new Color32(255, 255, 255, 255);
                        pointer3.SetActive(true);
                        break;
                    case 9:
                        sleep.color = new Color32(255, 255, 255, 255);
                        pointer4.SetActive(true);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && outOfBounds == true)
            {
                if (selectedOption <= 1)
                    selectedOption = 6;
                else
                    selectedOption -= 1;

                hatOn.color = new Color32(0, 0, 0, 20);
                //hatOff.color = new Color32(0, 0, 0, 20);
                glassOn.color = new Color32(0, 0, 0, 20);
                //glassOff.color = new Color32(0, 0, 0, 20);
                maskOn.color = new Color32(0, 0, 0, 20);
                //maskOff.color = new Color32(0, 0, 0, 20);
                jacketOn.color = new Color32(0, 0, 0, 20);
                //jacketOff.color = new Color32(0, 0, 0, 20);
                shoesOn.color = new Color32(0, 0, 0, 20);
                //shoesOff.color = new Color32(0, 0, 0, 20);

                for (int i = 0; i < objectPointers.Length; i++)
                    objectPointers[i].SetActive(false);

                feed.color = new Color32(0, 0, 0, 0);

                switch (selectedOption)
                {
                    case 1:
                        //hatOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[0].SetActive(true);
                        break;                  
                    case 2:
                        //glassOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[1].SetActive(true);
                        break;                  
                    case 3:
                        //maskOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[2].SetActive(true);
                        break;                    
                    case 4:
                        //jacketOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[3].SetActive(true);
                        break;                    
                    case 5:
                        //shoesOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[4].SetActive(true);
                        break;                   
                    case 6:
                        feed.color = new Color32(255, 255, 255, 255);
                        pointer1.SetActive(true);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.LeftArrow) && outOfBounds == false /*|| Controller input*/)
            { //Input telling it to go up or down.
                selectedOption -= 1;
                if (selectedOption < 6) //If at end of list go back to top
                {
                    //selectedOption = 1;
                    outOfBounds = true;

                    if (friendUnlock.hasHat != false)
                        selectedOption = 1;
                    else if (friendUnlock.hasHat == false)
                        selectedOption = 6;
                }

                hatOn.color = new Color32(0, 0, 0, 20);
                //hatOff.color = new Color32(0, 0, 0, 20);
                glassOn.color = new Color32(0, 0, 0, 20);
                //glassOff.color = new Color32(0, 0, 0, 20);
                maskOn.color = new Color32(0, 0, 0, 20);
                //maskOff.color = new Color32(0, 0, 0, 20);
                jacketOn.color = new Color32(0, 0, 0, 20);
                //jacketOff.color = new Color32(0, 0, 0, 20);
                shoesOn.color = new Color32(0, 0, 0, 20);
                //shoesOff.color = new Color32(0, 0, 0, 20);

                for (int i = 0; i < objectPointers.Length; i++)
                    objectPointers[i].SetActive(false);

                feed.color = new Color32(0, 0, 0, 0);
                wash.color = new Color32(0, 0, 0, 0);
                play.color = new Color32(0, 0, 0, 0);
                sleep.color = new Color32(0, 0, 0, 0);
                //custom.color = new Color32(0, 0, 0, 0);

                pointer1.SetActive(false);
                pointer2.SetActive(false);
                pointer3.SetActive(false);
                pointer4.SetActive(false);

                switch (selectedOption) //Set the visual indicator for which option you are on.
                {
                    /*case 1:
                        //custom.color = new Color32(0, 0, 0, 255);
                        break;*/
                    case 1:
                        //hatOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[0].SetActive(true);
                        break;
                    case 2:
                        //glassOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[1].SetActive(true);
                        break;
                    case 3:
                        //maskOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[2].SetActive(true);
                        break;
                    case 4:
                        //jacketOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[3].SetActive(true);
                        break;
                    case 5:
                        //shoesOn.color = new Color32(40, 150, 0, 255);
                        objectPointers[4].SetActive(true);
                        break;
                    case 6:
                        feed.color = new Color32(255, 255, 255, 255);
                        pointer1.SetActive(true);
                        break;
                    case 7:
                        wash.color = new Color32(255, 255, 255, 255);
                        pointer2.SetActive(true);
                        break;
                    case 8:
                        play.color = new Color32(255, 255, 255, 255);
                        pointer3.SetActive(true);
                        break;
                    case 9:
                        sleep.color = new Color32(255, 255, 255, 255);
                        pointer4.SetActive(true);
                        break;
                }
            }

            if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
            {
                Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

                switch (selectedOption) //Set the visual indicator for which option you are on.
                {
                    case 1:
                        if (friendUnlock.hasHat == true)
                        {
                            if (Input.GetKeyDown(KeyCode.Return) && isHeadOn == false)
                            {
                                customizationItems[0].SetActive(true);
                                select[0].enabled = true;
                                isHeadOn = true;
                                head = 1;
                                PlayerPrefs.SetInt("head", head);
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            else if (Input.GetKeyDown(KeyCode.Return) && isHeadOn == true)
                            {
                                customizationItems[0].SetActive(false);
                                select[0].enabled = false;
                                isHeadOn = false;
                                head = 0;
                                PlayerPrefs.DeleteKey("head");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }                       
                        }
                        break;
                    /*case 2:
                        if (friendUnlock.hasHat == true)
                        {
                            customizationItems[0].SetActive(false);
                            isHeadOn = false;
                            head = 0;
                            PlayerPrefs.DeleteKey("head");
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        break;*/
                    case 2:
                        if (friendUnlock.hasGlasses == true)
                        {
                            if (Input.GetKeyDown(KeyCode.Return) && isEyesOn == false)
                            {
                                customizationItems[1].SetActive(true);
                                select[1].enabled = true;
                                isEyesOn = true;
                                eyes = 1;
                                PlayerPrefs.SetInt("eyes", eyes);
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            else if (Input.GetKeyDown(KeyCode.Return) && isEyesOn == true)
                            {
                                customizationItems[1].SetActive(false);
                                select[1].enabled = false;
                                isEyesOn = false;
                                eyes = 0;
                                PlayerPrefs.DeleteKey("eyes");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }                          
                        }
                        break;
                    /*case 4:
                        if (friendUnlock.hasGlasses == true)
                        {
                            customizationItems[1].SetActive(false);
                            isEyesOn = false;
                            eyes = 0;
                            PlayerPrefs.DeleteKey("eyes");
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        break;*/
                    case 3:
                        if (friendUnlock.hasMask == true)
                        {
                            if (Input.GetKeyDown(KeyCode.Return) && isMaskOn == false)
                            {
                                customizationItems[2].SetActive(true);
                                select[2].enabled = true;
                                isMaskOn = true;
                                mask = 1;
                                PlayerPrefs.SetInt("mask", mask);
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            else if (Input.GetKeyDown(KeyCode.Return) && isMaskOn == true)
                            {
                                customizationItems[2].SetActive(false);
                                select[2].enabled = false;
                                isMaskOn = false;
                                mask = 0;
                                PlayerPrefs.DeleteKey("mask");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }                          
                        }
                        break;
                    /*case 6:
                        if (friendUnlock.hasMask == true)
                        {
                            customizationItems[2].SetActive(false);
                            isMaskOn = false;
                            mask = 0;
                            PlayerPrefs.DeleteKey("mask");
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        break;*/
                    case 4:
                        if (friendUnlock.hasJacket == true)
                        {
                            if (Input.GetKeyDown(KeyCode.Return) && isJacketOn == false)
                            {
                                customizationItems[3].SetActive(true);
                                select[3].enabled = true;
                                isJacketOn = true;
                                jacket = 1;
                                PlayerPrefs.SetInt("jacket", jacket);
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            else if (Input.GetKeyDown(KeyCode.Return) && isJacketOn == true)
                            {
                                customizationItems[3].SetActive(false);
                                select[3].enabled = false;
                                isJacketOn = false;
                                jacket = 0;
                                PlayerPrefs.DeleteKey("jacket");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }                         
                        }
                        break;
                    /*case 8:
                        if (friendUnlock.hasJacket == true)
                        {
                            customizationItems[3].SetActive(false);
                            isJacketOn = false;
                            jacket = 0;
                            PlayerPrefs.DeleteKey("jacket");
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        break;*/
                    case 5:
                        if (friendUnlock.hasShoes == true)
                        {
                            if (Input.GetKeyDown(KeyCode.Return) && isShoesOn == false)
                            {
                                customizationItems[4].SetActive(true);
                                customizationItems[5].SetActive(true);
                                select[4].enabled = true;
                                isShoesOn = true;
                                shoes = 1;
                                PlayerPrefs.SetInt("shoes", shoes);
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                            else if (Input.GetKeyDown(KeyCode.Return) && isShoesOn == true)
                            {
                                customizationItems[4].SetActive(false);
                                customizationItems[5].SetActive(false);
                                select[4].enabled = false;
                                isShoesOn = false;
                                shoes = 0;
                                PlayerPrefs.DeleteKey("shoes");
                                FindObjectOfType<AudioManager>().Play("Click");
                            }
                        }
                        break;
                    /*case 10:
                        if (friendUnlock.hasShoes == true)
                        {
                            customizationItems[4].SetActive(false);
                            customizationItems[5].SetActive(false);
                            isShoesOn = false;
                            shoes = 0;
                            PlayerPrefs.DeleteKey("shoes");
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        break;*/
                    case 6:
                        friend.GetComponent<Friend>().RequestFood();
                        pointer1Press.SetActive(true);
                        friendUnlock.isLocked = true;
                        FindObjectOfType<AudioManager>().Play("Click");
                        break;
                    case 7:
                        //friend.GetComponent<Friend>().UpdateCleanliness(100);
                        FindObjectOfType<AudioManager>().Play("Shower");
                        transitionShower.SetBool("Showering", true);
                        friendUnlock.isLocked = true;
                        StartCoroutine(Shower());
                        pointer2Press.SetActive(true);
                        FindObjectOfType<AudioManager>().Play("Click");
                        break;
                    case 8:
                        if (friendUnlock.isTired == false)
                        {
                            StartCoroutine(transitionAfterDelay());
                            transition.SetTrigger("TriggerTransition");
                            friendUnlock.isLocked = true;
                            pointer3Press.SetActive(true);
                            FindObjectOfType<AudioManager>().Play("Click");
                        }
                        break;
                    case 9:
                        StartCoroutine(saveOnSleep());
                        transition.SetTrigger("TriggerTransition");
                        friendUnlock.isLocked = true;
                        pointer4Press.SetActive(true);
                        FindObjectOfType<AudioManager>().Play("Click");
                        break;
                }
            }

            if (Input.GetKeyUp(KeyCode.Return) || Input.GetKeyUp("joystick button 0"))
            {
                switch (selectedOption)
                {
                    case 11:
                        //pointer1Press.SetActive(false);
                        break;
                    case 12:
                        //pointer2Press.SetActive(false);
                        break;
                    case 13:
                        //pointer3Press.SetActive(false);
                        break;
                    case 14:
                        //pointer4Press.SetActive(false);
                        break;
                }
            }
        }
    }

    public void TriggerNamePanel(bool b)
    {
        namePanel.SetActive(!namePanel.activeInHierarchy);

        if (b)
        {
            friend.GetComponent<Friend>().name =
                nameInput.GetComponent<InputField>().text;
            PlayerPrefs.SetString(
                "Name", friend.GetComponent<Friend>().name);
        }
    }

    public void ButtonBehavior(int i)
    {
        switch (i)
        {
            case (0):
            default:
                friendPanel.SetActive(!friendPanel.activeInHierarchy);
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (1):
                if (friendUnlock.isTired == false)
                {
                    StartCoroutine(transitionAfterDelay());
                    transition.SetTrigger("TriggerTransition");
                    FindObjectOfType<AudioManager>().Play("Click");
                }
                //SceneManager.LoadScene("RunnerNew 1");
                //friend.GetComponent<Friend>().SaveFriend();
                break;
            case (2):
                friend.GetComponent<Friend>().RequestFood();
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (3):
                friend.GetComponent<Friend>().UpdateCleanliness(100);
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (4):
                //friend.GetComponent<Friend>().UpdateEnergy(100);
                //friend.GetComponent<Friend>().SaveFriend();
                //Application.Quit();
                //Debug.Log("EXIT");
                StartCoroutine(saveOnSleep());
                transition.SetTrigger("TriggerTransition");
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (5):
                //PlayerPrefs.DeleteAll();
                //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                //SceneManager.LoadScene("Menu");
                //friend.GetComponent<Friend>().SaveFriend();
                break;

        }
    }

    public void CustomizationButtonBehavior(int i)
    {
        switch (i)
        {
            case (0):
                customizationItems[0].SetActive(true);
                isHeadOn = true;
                head = 1;
                PlayerPrefs.SetInt("head", head);
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (1):
                customizationItems[0].SetActive(false);
                isHeadOn = false;
                head = 0;
                PlayerPrefs.DeleteKey("head");
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (2):
                customizationItems[1].SetActive(true);
                isEyesOn = true;
                eyes = 1;
                PlayerPrefs.SetInt("eyes", eyes);
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (3):
                customizationItems[1].SetActive(false);
                isEyesOn = false;
                eyes = 0;
                PlayerPrefs.DeleteKey("eyes");
                FindObjectOfType<AudioManager>().Play("Click");
                break;
            case (4):

                break;
        }
    }

    public void CreateFriend(int i)
    {
        if (friend)
            Destroy(friend);
        friend = Instantiate(
            friendList[i])/*, Vector3.zero, Quaternion.identity)*/ as GameObject;

        if (friendPanel.activeInHierarchy)
            friendPanel.SetActive(false);

        PlayerPrefs.SetInt("looks", i);
    }

    public void Toggle(GameObject g)
    {
        if (g.activeInHierarchy)
            g.SetActive(false);
    }

    IEnumerator Shower()
    {
        yield return new WaitForSeconds(1);
        bubbleImg.enabled = true;
        bubbles.Play();
        yield return new WaitForSeconds(2);
        friend.GetComponent<Friend>().UpdateCleanliness(100);
        yield return new WaitForSeconds(3);
        transitionShower.SetBool("Showering", false);
        bubbleImg.enabled = false;
        pointer2Press.SetActive(false);
        friendUnlock.isLocked = false;
    }

    IEnumerator transitionAfterDelay()
    {
        yield return new WaitForSeconds(1.2f);

        if (friendUnlock.custom == 100)
        {
            SceneManager.LoadScene("RunnerKoala1");
        }
        if (friendUnlock.custom == 50)
        {
            SceneManager.LoadScene("RunnerKoala2");
        }
        if (friendUnlock.custom == 0)
        {
            SceneManager.LoadScene("RunnerKoala3");
        }
        if (friendUnlock.custom == -50)
        {
            SceneManager.LoadScene("RunnerKoala4");
        }
        if (friendUnlock.custom < -50)
        {
            SceneManager.LoadScene("RunnerKoala5");
        }

        friend.GetComponent<Friend>().SaveFriend();
    }

    IEnumerator saveOnSleep()
    {
        yield return new WaitForSeconds(1.2f);
        friend.GetComponent<Friend>().UpdateEnergy(100);
        friend.GetComponent<Friend>().SaveFriend();
        Application.Quit();
        Debug.Log("EXIT");
    }
}
