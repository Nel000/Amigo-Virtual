using System.Collections;
using UnityEngine;
using UnityEngine.UI;
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
    public Image hatOff;
    public Image glassOn;
    public Image glassOff;

    public Text feed;
    public Text wash;
    public Text play;
    public Text sleep;

    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;
    public GameObject pointer4;

    private int numOfOptions = 8;

    [SerializeField]
    private int selectedOption;

    [SerializeField]
    private bool outOfBounds;

    public GameObject[] customizationItems;

    public Animator transition;

    private bool isHeadOn;
    private bool isEyesOn;

    int head;
    int eyes;

    private void Start()
    {
        /*if (!PlayerPrefs.HasKey("looks"))
            PlayerPrefs.SetInt("looks", 0);
        CreateFriend(PlayerPrefs.GetInt("looks"));*/

        Cursor.visible = true;
        //Cursor.lockState = CursorLockMode.None;

        PlayerPrefs.GetInt("head");

        if (PlayerPrefs.HasKey("head"))
        {
            customizationItems[0].SetActive(true);
        }

        PlayerPrefs.GetInt("eyes");

        if (PlayerPrefs.HasKey("eyes"))
        {
            customizationItems[1].SetActive(true);
        }

        selectedOption = 5;

        hatOn.color = new Color32(0, 0, 0, 20);
        hatOff.color = new Color32(0, 0, 0, 20);
        glassOn.color = new Color32(0, 0, 0, 20);
        glassOff.color = new Color32(0, 0, 0, 20);

        feed.color = new Color32(0, 0, 0, 255);
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

        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.RightArrow))
        {
            //FindObjectOfType<AudioManager>().Play("Switch");
        }

        if (selectedOption >= 5)
            outOfBounds = false;

        if (Input.GetKeyDown(KeyCode.RightArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numOfOptions) //If at end of list go back to top
            {
                selectedOption = numOfOptions;
            }

            hatOn.color = new Color32(0, 0, 0, 20);
            hatOff.color = new Color32(0, 0, 0, 20);
            glassOn.color = new Color32(0, 0, 0, 20);
            glassOff.color = new Color32(0, 0, 0, 20);

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
                    hatOn.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    hatOff.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    glassOn.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    glassOff.color = new Color32(255, 255, 255, 255);
                    break;
                case 5:
                    feed.color = new Color32(0, 0, 0, 255);
                    pointer1.SetActive(true);
                    break;
                case 6:
                    wash.color = new Color32(0, 0, 0, 255);
                    pointer2.SetActive(true);
                    break;
                case 7:
                    play.color = new Color32(0, 0, 0, 255);
                    pointer3.SetActive(true);
                    break;
                case 8:
                    sleep.color = new Color32(0, 0, 0, 255);
                    pointer4.SetActive(true);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && outOfBounds == true)
        {
            if (selectedOption <= 1)
                selectedOption = 1;
            else
                selectedOption -= 1;

            hatOn.color = new Color32(0, 0, 0, 20);
            hatOff.color = new Color32(0, 0, 0, 20);
            glassOn.color = new Color32(0, 0, 0, 20);
            glassOff.color = new Color32(0, 0, 0, 20);

            switch (selectedOption)
            {
                case 1:
                    hatOn.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    hatOff.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    glassOn.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    glassOff.color = new Color32(255, 255, 255, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) && outOfBounds == false /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 5) //If at end of list go back to top
            {
                selectedOption = 1;
                outOfBounds = true;
            }

            hatOn.color = new Color32(0, 0, 0, 20);
            hatOff.color = new Color32(0, 0, 0, 20);
            glassOn.color = new Color32(0, 0, 0, 20);
            glassOff.color = new Color32(0, 0, 0, 20);

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
                    hatOn.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    hatOff.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    glassOn.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    glassOff.color = new Color32(255, 255, 255, 255);
                    break;
                case 5:
                    feed.color = new Color32(0, 0, 0, 255);
                    pointer1.SetActive(true);
                    break;
                case 6:
                    wash.color = new Color32(0, 0, 0, 255);
                    pointer2.SetActive(true);
                    break;
                case 7:
                    play.color = new Color32(0, 0, 0, 255);
                    pointer3.SetActive(true);
                    break;
                case 8:
                    sleep.color = new Color32(0, 0, 0, 255);
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
                        customizationItems[0].SetActive(true);
                        isHeadOn = true;
                        head = 1;
                        PlayerPrefs.SetInt("head", head);
                        FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 2:
                    if (friendUnlock.hasHat == true)
                    {
                        customizationItems[0].SetActive(false);
                        isHeadOn = false;
                        head = 0;
                        PlayerPrefs.DeleteKey("head");
                        FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 3:
                    if (friendUnlock.hasGlasses == true)
                    {
                        customizationItems[1].SetActive(true);
                        isEyesOn = true;
                        eyes = 1;
                        PlayerPrefs.SetInt("eyes", eyes);
                        FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 4:
                    if (friendUnlock.hasGlasses == true)
                    {
                        customizationItems[1].SetActive(false);
                        isEyesOn = false;
                        eyes = 0;
                        PlayerPrefs.DeleteKey("eyes");
                        FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 5:
                    friend.GetComponent<Friend>().RequestFood();
                    //FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 6:
                    friend.GetComponent<Friend>().UpdateCleanliness(100);
                    //FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 7:
                    if (friendUnlock.isTired == false)
                    {
                        StartCoroutine(transitionAfterDelay());
                        transition.SetTrigger("TriggerTransition");
                        //FindObjectOfType<AudioManager>().Play("Click");
                    }
                    break;
                case 8:
                    StartCoroutine(saveOnSleep());
                    transition.SetTrigger("TriggerTransition");
                    //FindObjectOfType<AudioManager>().Play("Click");
                    break;
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

    IEnumerator transitionAfterDelay()
    {
        yield return new WaitForSeconds(1);

        if (friendUnlock.custom == 100)
        {
            SceneManager.LoadScene("RunnerKoala1");
        }
        if (friendUnlock.custom < 100)
        {
            SceneManager.LoadScene("RunnerKoala2");
        }

        friend.GetComponent<Friend>().SaveFriend();
    }

    IEnumerator saveOnSleep()
    {
        yield return new WaitForSeconds(1);
        friend.GetComponent<Friend>().UpdateEnergy(100);
        friend.GetComponent<Friend>().SaveFriend();
        Application.Quit();
        Debug.Log("EXIT");
    }
}
