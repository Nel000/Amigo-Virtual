using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerManager : MonoBehaviour
{
    public GameObject friend;
    public Canvas canvas;

    public GameObject hat;
    public GameObject eyes;

    private void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        PlayerPrefs.GetInt("head");
        PlayerPrefs.GetInt("eyes");

        if (PlayerPrefs.HasKey("head"))
        {
            hat.SetActive(true);
        }

        if (PlayerPrefs.HasKey("eyes"))
        {
            eyes.SetActive(true);
        }
    }
}
