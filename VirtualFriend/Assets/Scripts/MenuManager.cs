using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    public GameObject flashText;

    void Start()
    {
        InvokeRepeating("flashTheText", 0f, 0.5f);
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
            SceneManager.LoadScene("Main");
    }

    void flashTheText()
    {
        if (flashText.activeInHierarchy)
            flashText.SetActive(false);
        else
            flashText.SetActive(true);
    }
}
