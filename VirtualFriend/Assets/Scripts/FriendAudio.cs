using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FriendAudio : MonoBehaviour
{
    public Friend friend;

    public GameObject yawn;
    public GameObject sniff;
    public GameObject growl;
    public GameObject sigh;

    [SerializeField]
    private bool firstState;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (friend.tired == true && friend.dirty == false && friend.hungry == false && friend.sad == false
            || friend.tired == false && friend.dirty == true && friend.hungry == false && friend.sad == false
            || friend.tired == false && friend.dirty == false && friend.hungry == true && friend.sad == false
            || friend.tired == false && friend.dirty == false && friend.hungry == false && friend.sad == true)
        {
            //firstState = true;
        }
        if (friend.tired == false && friend.dirty == false && friend.hungry == false && friend.sad == false)
        {
            firstState = false;
        }

        if (friend.tired == true && firstState == false)
        {
            yawn.SetActive(true);
            firstState = true;
        }
        else if (friend.tired == false)
        {
            yawn.SetActive(false);
        }

        if (friend.dirty == true && firstState == false)
        {
            sniff.SetActive(true);
            firstState = true;
        }
        else if (friend.dirty == false)
        {
            sniff.SetActive(false);
        }

        if (friend.hungry == true && firstState == false)
        {
            growl.SetActive(true);
            firstState = true;
        }
        else if (friend.hungry == false)
        {
            growl.SetActive(false);
        }

        if (friend.sad == true && firstState == false)
        {
            sigh.SetActive(true);
            firstState = true;
        }
        else if (friend.sad == false)
        {
            sigh.SetActive(false);
        }
    }
}
