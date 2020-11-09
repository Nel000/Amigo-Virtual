using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerManagerMousey : MonoBehaviour
{
    public GameObject friend;
    public Canvas canvas;

    public GameObject hat;

    private void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        PlayerPrefs.GetInt("head");

        if (PlayerPrefs.HasKey("head"))
        {
            hat.SetActive(true);
        }

        StartCoroutine(loadSceneAfterDelay(7));
    }

    IEnumerator loadSceneAfterDelay(float waitBySecs)
    {
        yield return new WaitForSeconds(waitBySecs);
        SceneManager.LoadScene("Main 1");
        friend.GetComponent<Friend>().SaveFriend();
    }
}
