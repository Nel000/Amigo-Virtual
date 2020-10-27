using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SetupManager : MonoBehaviour
{
    public Image option1;
    public Image option2;

    private int numOfOptions = 2;

    private int selectedOption;

    public readonly int defaultLastLevel = 1; // Set as appropriate
    private static bool loaded = false;

    int levelIndex;

    // Start is called before the first frame update
    void Start()
    {
        selectedOption = 1;

        option1.color = new Color32(255, 255, 255, 255);
        option2.color = new Color32(0, 0, 0, 255);

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

            option1.color = new Color32(0, 0, 0, 255);
            option2.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
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

            option1.color = new Color32(0, 0, 0, 255); //Make sure all others will be black (or do any visual you want to use to indicate this)
            option2.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    option1.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    option2.color = new Color32(255, 255, 255, 255);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    levelIndex = SceneManager.GetActiveScene().buildIndex + 1; // use this instead
                    PlayerPrefs.SetInt("Last_Level", levelIndex);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Main");
                    break;
                case 2:
                    levelIndex = SceneManager.GetActiveScene().buildIndex + 2; // use this instead
                    PlayerPrefs.SetInt("Last_Level", levelIndex);
                    PlayerPrefs.Save();
                    SceneManager.LoadScene("Main 1");
                    break;
            }
        }
    }
}
