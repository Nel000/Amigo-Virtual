using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerMousey : MonoBehaviour
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
            FindObjectOfType<AudioManager>().Play("Switch");
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
                StartCoroutine(saveOnSleep());
                transition.SetTrigger("TriggerTransition");
                FindObjectOfType<AudioManager>().Play("Click");
                //Application.Quit();
                //Debug.Log("EXIT");
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
            SceneManager.LoadScene("RunnerMousey1");
        }
        if (friendUnlock.custom < 100)
        {
            SceneManager.LoadScene("RunnerMousey2");
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
