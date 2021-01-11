using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public Text feed;
    public Text wash;
    public Text play;
    public Text sleep;
    //public Text custom;

    public GameObject pointer1;
    public GameObject pointer2;
    public GameObject pointer3;
    public GameObject pointer4;

    private int numOfOptions = 4;

    private int selectedOption;

    // Start is called before the first frame update
    void Start()
    {
        selectedOption = 1;

        feed.color = new Color32(0, 0, 0, 255);
        wash.color = new Color32(0, 0, 0, 0);
        play.color = new Color32(0, 0, 0, 0);
        sleep.color = new Color32(0, 0, 0, 0);
        //custom.color = new Color32(0, 0, 0, 0);

        pointer1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.RightArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption += 1;
            if (selectedOption > numOfOptions) //If at end of list go back to top
            {
                selectedOption = numOfOptions;
            }

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
                    feed.color = new Color32(0, 0, 0, 255);
                    pointer1.SetActive(true);
                    break;
                case 2:
                    wash.color = new Color32(0, 0, 0, 255);
                    pointer2.SetActive(true);
                    break;
                case 3:
                    play.color = new Color32(0, 0, 0, 255);
                    pointer3.SetActive(true);
                    break;
                case 4:
                    sleep.color = new Color32(0, 0, 0, 255);
                    pointer4.SetActive(true);
                    break;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftArrow) /*|| Controller input*/)
        { //Input telling it to go up or down.
            selectedOption -= 1;
            if (selectedOption < 1) //If at end of list go back to top
            {
                selectedOption = -3;
            }

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
                    feed.color = new Color32(0, 0, 0, 255);
                    pointer1.SetActive(true);
                    break;
                case 2:
                    wash.color = new Color32(0, 0, 0, 255);
                    pointer2.SetActive(true);
                    break;
                case 3:
                    play.color = new Color32(0, 0, 0, 255);
                    pointer3.SetActive(true);
                    break;
                case 4:
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
                    
                    break;
                case 2:
                    
                    break;
                case 3:
                    
                    break;
                case 4:
                    
                    break;
            }
        }
    }
}