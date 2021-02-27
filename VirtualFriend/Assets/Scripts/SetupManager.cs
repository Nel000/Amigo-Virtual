using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    public Image option1;
    public Image option2;

    public Animator transition;

    private int numOfOptions = 2;

    private int selectedOption;

    public readonly int defaultLastLevel = 1; // Set as appropriate
    private static bool loaded = false;

    int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedOption = 1;

        option1.color = new Color32(255, 255, 255, 220);
        option2.color = new Color32(255, 255, 255, 70);

        if (!loaded)
        {
            loaded = true;
            levelIndex = PlayerPrefs.GetInt("Last_Level", defaultLastLevel);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numOfOptions) //If at end of list go back to top
            {
                selectedOption = 1;
            }

            option1.color = new Color32(255, 255, 255, 70);
            option2.color = new Color32(255, 255, 255, 70);

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 220);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 220);
                    break;
            }

            FindObjectOfType<AudioManager>().Play("Switch");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top
            {
                selectedOption = numOfOptions;
            }

            option1.color = new Color32(255, 255, 255, 70); //Make sure all others will be black (or do any visual you want to use to indicate this)
            option2.color = new Color32(255, 255, 255, 70);

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 220);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 220);
                    break;
            }

            FindObjectOfType<AudioManager>().Play("Switch");
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    StartCoroutine(transitionAfterDelay1());
                    transition.SetTrigger("TriggerTransition");
                    FindObjectOfType<AudioManager>().Play("Click");
                    /*levelIndex = SceneManager.GetActiveScene().buildIndex + 1; // use this instead
                    PlayerPrefs.SetInt("Last_Level", levelIndex);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Main");*/
                    break;
                case 2:
                    StartCoroutine(transitionAfterDelay2());
                    transition.SetTrigger("TriggerTransition");
                    FindObjectOfType<AudioManager>().Play("Click");
                    /*levelIndex = SceneManager.GetActiveScene().buildIndex + 2; // use this instead
                    PlayerPrefs.SetInt("Last_Level", levelIndex);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Main 1");*/
                    break;
            }
        }
    }

    IEnumerator transitionAfterDelay1()
    {
        yield return new WaitForSeconds(1.5f);
        levelIndex = SceneManager.GetActiveScene().buildIndex + 1; // use this instead
        PlayerPrefs.SetInt("Last_Level", levelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main");
    }

    IEnumerator transitionAfterDelay2()
    {
        yield return new WaitForSeconds(1.5f);
        levelIndex = SceneManager.GetActiveScene().buildIndex + 2; // use this instead
        PlayerPrefs.SetInt("Last_Level", levelIndex);
        PlayerPrefs.Save();
        SceneManager.LoadScene("Main 1");
    }
}
