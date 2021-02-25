using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    public Friend friend;

    public GameObject mudSplash;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Walk on mud");
            //Destroy(gameObject);
            mudSplash.SetActive(true);
            friend.UpdateCleanliness(-10);
            FindObjectOfType<AudioManager>().Play("Mud");
            //friend.UpdateTop(-50);
        }
    }
}
