using UnityEngine;

public class FriendMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce;
    public float sidewaysForce;

    private void FixedUpdate()
    {
        var x = Input.GetAxisRaw("Horizontal") * Time.deltaTime * 5.0f;
        transform.position += Vector3.forward * Time.deltaTime * forwardForce;

        if (Input.GetKey("d"))
        {
            transform.Translate(x, 0, 0);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(x, 0, 0);
        }
    }
}
