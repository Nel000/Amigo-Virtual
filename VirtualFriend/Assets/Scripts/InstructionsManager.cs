using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InstructionsManager : MonoBehaviour
{
    public Text turnBack;

    // Start is called before the first frame update
    void Start()
    {
        turnBack.color = new Color32(255, 255, 255, 255);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) || Input.GetKeyDown("joystick button 0"))
        {
            SceneManager.LoadScene("Menu");
            FindObjectOfType<AudioManager>().Play("Click");
        }
    }
}
