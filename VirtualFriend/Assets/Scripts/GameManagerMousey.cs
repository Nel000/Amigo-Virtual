using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManagerMousey : MonoBehaviour
{
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

    private bool isHeadOn;

    int head;

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
                break;
            case (1):
                SceneManager.LoadScene("Runner 1");
                friend.GetComponent<Friend>().SaveFriend();
                break;
            case (2):

                break;
            case (3):

                break;
            case (4):
                friend.GetComponent<Friend>().SaveFriend();
                Application.Quit();
                Debug.Log("EXIT");
                break;
            case (5):
                PlayerPrefs.DeleteAll();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
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
                break;
            case (1):
                customizationItems[0].SetActive(false);
                isHeadOn = false;
                head = 0;
                PlayerPrefs.DeleteKey("head");
                break;
            case (2):

                break;
            case (3):

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
}
