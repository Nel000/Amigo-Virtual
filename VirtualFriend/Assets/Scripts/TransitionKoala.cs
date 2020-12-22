using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TransitionKoala : MonoBehaviour
{
    public GameObject friend;

    public Animator animator;
    public float transitionDelayTime = 1.0f;

    void Awake()
    {
        animator = GameObject.Find("Transition").GetComponent<Animator>();

        //StartCoroutine(loadSceneAfterDelay(12));
    }

    void Update()
    {
        /*if (Input.GetKey(KeyCode.Space))
        {
            LoadLevel();
        }*/
    }

    public void LoadLevel()
    {
        StartCoroutine(DelayLoadLevel());
    }

    IEnumerator DelayLoadLevel()
    {
        animator.SetTrigger("TriggerTransition");
        yield return new WaitForSeconds(transitionDelayTime);
        SceneManager.LoadScene("Main");
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            StartCoroutine(loadSceneAfterDelay(1));
        }
    }

    IEnumerator loadSceneAfterDelay(float waitBySecs)
    {
        yield return new WaitForSeconds(waitBySecs);
        LoadLevel();
        friend.GetComponent<Friend>().SaveFriend();
    }
}
