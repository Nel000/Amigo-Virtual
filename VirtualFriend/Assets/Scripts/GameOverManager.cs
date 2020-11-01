using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOverManager : MonoBehaviour
{
    public Text option1;
    public Text option2;

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
                    SceneManager.LoadScene("Menu");
                    break;
                case 2:
                    Application.Quit();
                    break;
            }
        }
    }
}
