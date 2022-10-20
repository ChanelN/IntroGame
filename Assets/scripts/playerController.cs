using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class playerController : MonoBehaviour
{
    public Vector2 moveValue;
    public float speed;
    private int count;

    private void Start()
    {
        count = 0;
    }

    void OnMove(InputValue value)
    {
        moveValue = value.Get<Vector2>();
    }

    void FixedUpdate()
    {
        Vector3 movement = new Vector3(moveValue.x, 0.0f, moveValue.y);

        GetComponent<Rigidbody>().AddForce(movement * speed * Time.fixedDeltaTime);
    }

    //this is entered when a a pick up trigger collider collides with the players collision
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == " PickUp ")
        {
            //we make the pick up item disappear after its collided
            count += 1;
            other.gameObject.SetActive(false);
        }
    }
}
