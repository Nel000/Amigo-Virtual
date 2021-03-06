﻿using UnityEngine;
using System;
using System.Collections;
using UnityEngine.SceneManagement;

public class Friend : MonoBehaviour
{
    public float maxValue = 100;
    public float minValue = 5;

    [SerializeField]
    private float hunger;
    [SerializeField]
    private float happiness;
    [SerializeField]
    private float cleanliness;
    [SerializeField]
    private float energy;
    [SerializeField]
    public float custom;
    [SerializeField]
    private string sName;

    public GameObject[] customImages;
    public GameObject topButtonOn;
    public GameObject topButtonOff;
    public GameObject eyeButtonOn;
    public GameObject eyeButtonOff;

    private GameObject randomImage;
    //public GameObject balloon;
    public GameObject water;
    public GameObject juice;
    public GameObject salad;
    public GameObject pizza;
    public GameObject hamburger;
    public GameObject apple;
    public GameObject[] images;

    public GameObject pointer1Press;

    public float subtractHunger = -5;
    public float subtractHappiness = -5;
    public float subtractCleanliness = -5;
    public float subtractEnergy = -5;

    public bool isHungry;
    public bool isHungryLowMed;
    public bool isTired;

    public bool tired;
    public bool dirty;
    public bool hungry;
    public bool sad;

    public bool hasHat;
    public bool hasGlasses;
    public bool hasMask;
    public bool hasJacket;
    public bool hasShoes;

    private bool serverTime;
    private int clickCount;

    public bool isLocked;

    public Animator friendAnim;

    public StatBar hungerBar;
    public StatBar happinessBar;
    public StatBar cleanlinessBar;
    public StatBar energyBar;

    void Start()
    {
        //PlayerPrefs.SetString("then", "05/14/2020 09:20:12");
        UpdateStatus();
        if (!PlayerPrefs.HasKey("Name"))
            PlayerPrefs.SetString("Name", "friend");
        sName = PlayerPrefs.GetString("Name");
        hungerBar.SetMaxHealth(maxValue);
        happinessBar.SetMaxHealth(maxValue);
        cleanlinessBar.SetMaxHealth(maxValue);
        energyBar.SetMaxHealth(maxValue);

        CheckForUnlocked();
        //CheckStatus();
    }

    void Update()
    {
        CheckStatus();      

        if (Input.GetMouseButtonUp(0))
        {
            Vector2 v =
                new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            RaycastHit2D hit =
                Physics2D.Raycast(
                    Camera.main.ScreenToWorldPoint(v), Vector2.zero);
            if (hit)
            {
                Debug.Log(hit.transform.gameObject.name);
                if (hit.transform.gameObject.tag == "Friend")
                {
                    clickCount++;
                    if (clickCount >= 3)
                    {
                        clickCount = 0;
                        UpdateHappiness(1);
                    }
                }
            }
        }

        if (energy < 20)
            isTired = true;
        else if (energy > 20)
            isTired = false;

        hunger = Mathf.Clamp(
            hunger - subtractHunger * Time.deltaTime, minValue, maxValue);
        hungerBar.SetHealth(hunger);

        happiness = Mathf.Clamp(
            happiness - subtractHappiness * Time.deltaTime, minValue, maxValue);
        happinessBar.SetHealth(happiness);

        cleanliness = Mathf.Clamp(
            cleanliness - subtractCleanliness * Time.deltaTime, minValue, maxValue);
        cleanlinessBar.SetHealth(cleanliness);

        energy = Mathf.Clamp(
            energy - subtractEnergy * Time.deltaTime, minValue, maxValue);
        energyBar.SetHealth(energy);

        /*if (hunger <= 0 || energy <= 0)
        {
            GameOver();
        }*/

        if (isHungry == true)
        {
            if (Input.GetKeyDown("g") && water.activeSelf == true)
            {
                Debug.Log("Feed");
                UpdateHunger(45);
                UpdateHappiness(5);
                randomImage.SetActive(false);
                isHungry = false;
                isLocked = false;
                pointer1Press.SetActive(false);
                FindObjectOfType<AudioManager>().Play("DrinkMousey");
            }

            if (Input.GetKeyDown("h") && juice.activeSelf == true)
            {
                Debug.Log("Feed");
                UpdateHunger(60);
                UpdateHappiness(5);
                randomImage.SetActive(false);
                isHungry = false;
                isLocked = false;
                pointer1Press.SetActive(false);
                FindObjectOfType<AudioManager>().Play("DrinkMousey");
            }

            if (Input.GetKeyDown("j") && salad.activeSelf == true)
            {
                Debug.Log("Feed");
                UpdateHunger(80);
                UpdateHappiness(5);
                randomImage.SetActive(false);
                isHungry = false;
                isLocked = false;
                pointer1Press.SetActive(false);
                FindObjectOfType<AudioManager>().Play("Eat");
            }

            if (Input.GetKeyDown("k") && pizza.activeSelf == true)
            {
                Debug.Log("Feed");
                UpdateHunger(100);
                UpdateHappiness(5);
                randomImage.SetActive(false);
                //balloon.SetActive(false);
                //pizza.SetActive(false);
                isHungry = false;
                isLocked = false;
                pointer1Press.SetActive(false);
                FindObjectOfType<AudioManager>().Play("Eat");
            }

            /*if (Input.GetKeyDown("k") && hamburger.activeSelf == true)
            {
                Debug.Log("Feed");
                UpdateHunger(70);
                UpdateHappiness(5);
                randomImage.SetActive(false);
                isHungry = false;
            }*/

            if (Input.GetKeyDown("l") && apple.activeSelf == true)
            {
                Debug.Log("Feed");
                UpdateHunger(60);
                UpdateHappiness(5);
                randomImage.SetActive(false);
                isHungry = false;
                isLocked = false;
                pointer1Press.SetActive(false);
                FindObjectOfType<AudioManager>().Play("EatApple");
            }
        }       
    }

    void UpdateStatus()
    {
        if (!PlayerPrefs.HasKey("hunger"))
        {
            hunger = 100;
            PlayerPrefs.SetFloat("hunger", hunger);
        }
        else
        {
            hunger = PlayerPrefs.GetFloat("hunger");
        }

        if (!PlayerPrefs.HasKey("happiness"))
        {
            happiness = 100;
            PlayerPrefs.SetFloat("happiness", happiness);
        }
        else
        {
            happiness = PlayerPrefs.GetFloat("happiness");
        }
        if (!PlayerPrefs.HasKey("cleanliness"))
        {
            cleanliness = 100;
            PlayerPrefs.SetFloat("cleanliness", happiness);
        }
        else
        {
            cleanliness = PlayerPrefs.GetFloat("cleanliness");
        }
        if (!PlayerPrefs.HasKey("energy"))
        {
            energy = 100;
            PlayerPrefs.SetFloat("energy", energy);
        }
        else
        {
            energy = PlayerPrefs.GetFloat("energy");
        }
        if (!PlayerPrefs.HasKey("custom"))
        {
            custom = 100;
            PlayerPrefs.SetFloat("custom", custom);
        }
        else
        {
            custom = PlayerPrefs.GetFloat("custom");
        }

        /*if (!PlayerPrefs.HasKey("then"))
            PlayerPrefs.SetString("then", getStringTime());

        TimeSpan ts = getTimeSpan();

        hunger -= (int)(ts.TotalHours * 2);
        if (hunger < 0)
            hunger = 0;
        happiness -= (int)((100 - hunger)*(ts.TotalHours / 5));
        if (happiness < 0)
            happiness = 0;
        cleanliness -= (int)(ts.TotalHours * 1.5);
        if (cleanliness < 0)
            cleanliness = 0;
        energy -= (int)(ts.TotalHours * 1.2);
        if (energy < 0)
            energy = 0;*/

        //Debug.Log(getTimeSpan().ToString());
        //Debug.Log(getTimeSpan().TotalHours);

        /*if (serverTime)
            UpdateServer();
        else
            InvokeRepeating("UpdateDevice", 0f, 30f);*/
    }

    void UpdateServer()
    {

    }

    void UpdateDevice()
    {
        PlayerPrefs.SetString("then", getStringTime());
    }

    TimeSpan getTimeSpan()
    {
        if (serverTime)
            return new TimeSpan();
        else
            return DateTime.Now -
                Convert.ToDateTime(PlayerPrefs.GetString("then"));
    }

    string getStringTime()
    {
        DateTime now = DateTime.Now;
        return now.Month + "/" + now.Day + "/" + now.Year + " " +
            now.Hour + ":" + now.Minute + ":" + now.Second;
    }

    public float pHunger
    {
        get { return hunger; }
        set { hunger = value; }
    }

    public float pHappiness
    {
        get { return happiness; }
        set { happiness = value; }
    }

    public float pCleanliness
    {
        get { return cleanliness; }
        set { cleanliness = value; }
    }

    public float pEnergy
    {
        get { return energy; }
        set { energy = value; }
    }

    public string pName
    {
        get { return sName; }
        set { sName = value; }
    }

    public void UpdateHappiness(int i)
    {
        happiness += i;
        if (happiness > 100)
            happiness = 100;
    }

    public void UpdateHunger(int i)
    {
        hunger += i;
        if (hunger > 100)
            hunger = 100;
    }

    public void UpdateCleanliness(int i)
    {
        cleanliness += i;
        if (cleanliness > 100)
            cleanliness = 100;
    }

    public void UpdateEnergy(int i)
    {
        energy += i;
        if (energy > 100)
            energy = 100;
    }

    public void UpdateCustom(int i)
    {
        custom += i;
        if (custom > 100)
            custom = 100;
    }

    public void SaveFriend()
    {
        /*if (!serverTime)
            UpdateDevice();*/
        PlayerPrefs.SetFloat("hunger", hunger);
        PlayerPrefs.SetFloat("happiness", happiness);
        PlayerPrefs.SetFloat("cleanliness", cleanliness);
        PlayerPrefs.SetFloat("energy", energy);
        PlayerPrefs.SetFloat("custom", custom);
    }

    public void CheckForUnlocked()
    {
        if (custom < 100)
        {
            //topButtonOn.SetActive(true);
            //topButtonOff.SetActive(true);
            hasHat = true;
            customImages[0].SetActive(true);
            customImages[1].SetActive(true);
        }

        if (custom < 50)
        {
            //eyeButtonOn.SetActive(true);
            //eyeButtonOff.SetActive(true);
            hasGlasses = true;
            customImages[2].SetActive(true);
            customImages[3].SetActive(true);
        }

        if (custom < 0)
        {
            hasMask = true;
            customImages[4].SetActive(true);
            customImages[5].SetActive(true);
        }

        if (custom < -50)
        {
            hasJacket = true;
            customImages[6].SetActive(true);
            customImages[7].SetActive(true);
        }

        if (custom < -100)
        {
            hasShoes = true;
            customImages[8].SetActive(true);
            customImages[9].SetActive(true);
        }
    }

    public void CheckStatus()
    {
        if (energy < 40)
        {
            friendAnim.SetBool("Tired", true);
            tired = true;
        }
        else if (energy > 40)
        {
            friendAnim.SetBool("Tired", false);
            tired = false;
        }
        if (cleanliness < 40)
        {
            friendAnim.SetBool("Dirty", true);
            dirty = true;
        }
        else if (cleanliness > 40)
        {
            friendAnim.SetBool("Dirty", false);
            dirty = false;
        }
        if (hunger < 40)         
        {
            friendAnim.SetBool("Hungry", true);
            hungry = true;
        }
        else if (hunger > 40)
        {
            friendAnim.SetBool("Hungry", false);
            hungry = false;
        }
        if (happiness < 40)
        {
            friendAnim.SetBool("Sad", true);
            sad = true;
        }
        else if (happiness > 40)
        {
            friendAnim.SetBool("Sad", false);
            sad = false;
        }
    }

    public void RequestFood()
    {
        if (hunger < 100 && isHungry == false)
        {
            int num = UnityEngine.Random.Range(0, images.Length);
            randomImage = images[num];
            randomImage.SetActive(true);
            //balloon.SetActive(true);
            //pizza.SetActive(true);
            isHungry = true;
        }
        /*else
        {
            balloon.SetActive(false);
            pizza.SetActive(false);
            isHungryLow = false;
        }*/

        /*if (hunger < 60 && hunger > 40)
        {
            balloon.SetActive(true);
            hamburger.SetActive(true);
            isHungryLowMed = true;
        }
        else
        {
            balloon.SetActive(false);
            hamburger.SetActive(false);
            isHungryLowMed = false;
        }*/
    }

    public void GameOver()
    {
        PlayerPrefs.DeleteAll();
        SceneManager.LoadScene("GameOver");
    }
}
