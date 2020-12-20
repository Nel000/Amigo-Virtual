using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject flashText;

    public Text play;
    public Text reset;
    public Image exit;

    public Animator transition;

    private int numOfOptions = 3;

    private int selectedOption;

    int levelIndex;

    public readonly int defaultLastLevel = 1; // Set as appropriate
    private static bool loaded = false;

    void Start()
    {
        selectedOption = 1;
        play.color = new Color32(255, 255, 255, 255);
        reset.color = new Color32(0, 0, 0, 255);
        exit.color = new Color32(255, 255, 255, 70);

        InvokeRepeating("flashTheText", 0f, 0.5f);

        if (!loaded)
        {
            loaded = true;
            levelIndex = PlayerPrefs.GetInt("Last_Level", defaultLastLevel);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
            SceneManager.LoadScene("Main");

        if (Input.GetKeyDown(KeyCode.RightArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numOfOptions) //If at end of list go back to top
            {
                selectedOption = 1;
            }

            play.color = new Color32(0, 0, 0, 255);
            reset.color = new Color32(0, 0, 0, 255);
            exit.color = new Color32(255, 255, 255, 70);

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    play.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    reset.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    exit.color = new Color32(255, 255, 255, 200);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top
            {
                selectedOption = numOfOptions;
            }

            play.color = new Color32(0, 0, 0, 255); //Make sure all others will be black (or do any visual you want to use to indicate this)
            reset.color = new Color32(0, 0, 0, 255);
            exit.color = new Color32(255, 255, 255, 70);
            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    play.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    reset.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    exit.color = new Color32(255, 255, 255, 200);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    Play();
                    break;
                case 2:
                    PlayerPrefs.DeleteAll();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    break;
                case 3:
                    Debug.Log("Exit");
                    Application.Quit();
                    break;
            }
        }
    }

    void flashTheText()
    {
        if (flashText.activeInHierarchy)
            flashText.SetActive(false);
        else
            flashText.SetActive(true);
    }

    void Play()
    {
        if (!PlayerPrefs.HasKey("isFirstTime") || PlayerPrefs.GetInt("isFirstTime") != 1)
        {
            SceneManager.LoadScene("Setup");
            // Now set the value of isFirstTime to be false in the PlayerPrefs.
            PlayerPrefs.SetInt("isFirstTime", 1);
            PlayerPrefs.Save();
        }
        else
        {
            StartCoroutine(transitionAfterDelay());
            transition.SetTrigger("TriggerTransition");
            //SceneManager.LoadScene(levelIndex);
        }
    }

    IEnumerator transitionAfterDelay()
    {
        yield return new WaitForSeconds(2);
        SceneManager.LoadScene(levelIndex);
    }
}
