using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeLevel : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine(loadSceneAfterDelay(25));
    }

    IEnumerator loadSceneAfterDelay(float waitBySecs)
    {
        yield return new WaitForSeconds(waitBySecs);
        SceneManager.LoadScene("Main");
    }
}
