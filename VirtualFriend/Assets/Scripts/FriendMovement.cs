using UnityEngine;

public class FriendMovement : MonoBehaviour
{
    public Rigidbody rb;

    public float forwardForce;
    public float sidewaysForce;

    private void FixedUpdate()
    {
        transform.position += Vector3.forward * Time.deltaTime * forwardForce;

        if (Input.GetKey("d"))
        {
            rb.AddForce(
                sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }

        if (Input.GetKey("a"))
        {
            rb.AddForce(
                -sidewaysForce * Time.deltaTime, 0, 0, ForceMode.VelocityChange);
        }
    }
}
