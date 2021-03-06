﻿using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public GameObject flashText;

    public Text play;
    public Text reset;
    public Text instructions;
    public Text dataSheet;
    public Text quit;
    public Text back;
    //public Image exit;

    public GameObject dataSheetText;
    public GameObject instructionsImg;
    public Image background;
    public Image instructionsCorner;

    public GameObject[] menuElements;
    public GameObject returnImg;

    public Animator transition;

    private int numOfOptions = 6;

    [SerializeField]
    private int selectedOption;

    [SerializeField]
    private bool isInstruction;

    [SerializeField]
    private bool isDataSheet;

    [SerializeField]
    int levelIndex;

    public readonly int defaultLastLevel = 1; // Set as appropriate
    private static bool loaded = false;

    void Start()
    {
        Cursor.visible = false;

        isInstruction = false;
        isDataSheet = false;

        selectedOption = 3;
        play.color = new Color32(255, 255, 255, 255);
        reset.color = new Color32(0, 0, 0, 255);
        instructions.color = new Color32(0, 0, 0, 255);
        dataSheet.color = new Color32(0, 0, 0, 255);
        quit.color = new Color32(0, 0, 0, 255);
        back.color = new Color32(255, 255, 255, 0);

        InvokeRepeating("flashTheText", 0f, 0.5f);

        if (!loaded)
        {
            loaded = true;
            levelIndex = PlayerPrefs.GetInt("Last_Level", defaultLastLevel);
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) 
            && isInstruction == false && isDataSheet == false /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > 5) //If at end of list go back to top
            {
                selectedOption = 1;
            }

            play.color = new Color32(0, 0, 0, 255);
            reset.color = new Color32(0, 0, 0, 255);
            instructions.color = new Color32(0, 0, 0, 255);
            dataSheet.color = new Color32(0, 0, 0, 255);
            quit.color = new Color32(0, 0, 0, 255);

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    dataSheet.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    instructions.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    play.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    reset.color = new Color32(255, 255, 255, 255);
                    break;
                case 5:
                    quit.color = new Color32(255, 255, 255, 255);
                    break;
            }

            FindObjectOfType<AudioManager>().Play("Switch");
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) 
            && isInstruction == false && isDataSheet == false /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top
            {
                selectedOption = 5;
            }

            play.color = new Color32(0, 0, 0, 255); //Make sure all others will be black (or do any visual you want to use to indicate this)
            reset.color = new Color32(0, 0, 0, 255);
            instructions.color = new Color32(0, 0, 0, 255);
            dataSheet.color = new Color32(0, 0, 0, 255);
            quit.color = new Color32(0, 0, 0, 255);
            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 1:
                    dataSheet.color = new Color32(255, 255, 255, 255);
                    break;
                case 2:
                    instructions.color = new Color32(255, 255, 255, 255);
                    break;
                case 3:
                    play.color = new Color32(255, 255, 255, 255);
                    break;
                case 4:
                    reset.color = new Color32(255, 255, 255, 255);
                    break;
                case 5:
                    quit.color = new Color32(255, 255, 255, 255);
                    break;
            }

            FindObjectOfType<AudioManager>().Play("Switch");
        }

        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Picked: " + selectedOption); //For testing as the switch statment does nothing right now.

            switch (selectedOption) //Set the visual indicator for which option you are on.
            {
                case 3:
                    Play();
                    FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 4:
                    PlayerPrefs.DeleteAll();
                    SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
                    FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 1:
                    isDataSheet = true;
                    for (int i = 0; i < menuElements.Length; i++)
                        menuElements[i].SetActive(false);
                    back.color = new Color32(255, 255, 255, 255);
                    returnImg.SetActive(true);
                    instructionsCorner.enabled = false;
                    dataSheetText.SetActive(true);
                    background.color = new Color32(120, 120, 120, 255);
                    FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 2:
                    //SceneManager.LoadScene("Instructions");
                    isInstruction = true;
                    //selectedOption = 5;
                    for (int i = 0; i < menuElements.Length; i++)
                        menuElements[i].SetActive(false);
                    back.color = new Color32(255, 255, 255, 255);
                    returnImg.SetActive(true);
                    instructionsImg.SetActive(true);
                    instructionsCorner.enabled = false;
                    background.color = new Color32(120, 120, 120, 255);
                    FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 5:
                    StartCoroutine(transitionToExit());
                    transition.SetTrigger("TriggerTransition");
                    FindObjectOfType<AudioManager>().Play("Click");
                    break;
                case 6:
                    if (isInstruction == true)
                    {
                        isInstruction = false;
                        instructionsImg.SetActive(false);
                        selectedOption = 2;
                    }
                    if (isDataSheet == true)
                    {
                        isDataSheet = false;
                        dataSheetText.SetActive(false);
                        selectedOption = 1;
                    }                                    
                    for (int i = 0; i < menuElements.Length; i++)
                        menuElements[i].SetActive(true);
                    back.color = new Color32(255, 255, 255, 0);
                    returnImg.SetActive(false);                   
                    background.color = new Color32(255, 255, 255, 255);
                    instructionsCorner.enabled = true;
                    FindObjectOfType<AudioManager>().Play("Click");
                    break;
            }
        }

        if (isInstruction == true || isDataSheet == true)
        {
            selectedOption = 6;
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

    IEnumerator transitionToExit()
    {
        yield return new WaitForSeconds(1);
        Debug.Log("Exit");
        Application.Quit();
    }
}
