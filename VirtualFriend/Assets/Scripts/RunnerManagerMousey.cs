using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerManagerMousey : MonoBehaviour
{
    public GameObject friend;
    public Canvas canvas;

    public GameObject hat;
    public GameObject eyes;
    public GameObject mask;
    public GameObject jacket;
    public GameObject[] shoes;

    public AudioSource steps;

    private void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        PlayerPrefs.GetInt("head");
        PlayerPrefs.GetInt("eyes");
        PlayerPrefs.GetInt("mask");
        PlayerPrefs.GetInt("jacket");
        PlayerPrefs.GetInt("shoes");

        if (PlayerPrefs.HasKey("head"))
        {
            hat.SetActive(true);
        }

        if (PlayerPrefs.HasKey("eyes"))
        {
            eyes.SetActive(true);
        }

        if (PlayerPrefs.HasKey("mask"))
        {
            mask.SetActive(true);
        }

        if (PlayerPrefs.HasKey("jacket"))
        {
            jacket.SetActive(true);
        }

        if (PlayerPrefs.HasKey("shoes"))
        {
            for (int i = 0; i < shoes.Length; i++)
                shoes[i].SetActive(true);
        }

        StartCoroutine(timeToStart());
    }

    IEnumerator timeToStart()
    {
        yield return new WaitForSeconds(0);
        Time.timeScale = 0;
        yield return new WaitForSecondsRealtime(3.5f);
        Time.timeScale = 1;
        steps.Play();
    }
}
