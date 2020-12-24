using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    public Friend friend;

    private void OnTriggerEnter(Collider collider)
    {
        if(collider.gameObject.tag == "Player")
        {
            print("Item picked up");
            Destroy(gameObject);
            FindObjectOfType<AudioManager>().Play("PickUp");
            friend.UpdateHappiness(100);
            friend.UpdateCustom(-50);
        }
    }
}
