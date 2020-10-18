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
            friend.UpdateHappiness(100);
        }
    }
}
