using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunnerManager : MonoBehaviour
{
    private void Start()
    {
        Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        StartCoroutine(loadSceneAfterDelay(25));
    }

    IEnumerator loadSceneAfterDelay(float waitBySecs)
    {
        yield return new WaitForSeconds(waitBySecs);
        SceneManager.LoadScene("Main");
    }
}
