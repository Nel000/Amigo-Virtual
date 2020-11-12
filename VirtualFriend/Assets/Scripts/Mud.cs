using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mud : MonoBehaviour
{
    public Friend friend;

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Player")
        {
            print("Walk on mud");
            //Destroy(gameObject);
            friend.UpdateCleanliness(-10);
            //friend.UpdateTop(-50);
        }
    }
}
