using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Player movement
// Code is from Unity Tutorial:
// https://stuartspixelgames.com/2018/06/24/simple-2d-top-down-movement-unity-c/

public class Controller : MonoBehaviour
{
    Rigidbody2D body;

    float vertical = 0;
    float horizontal = 0;
    public float speed = 20.0f;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        vertical = Input.GetAxisRaw("Vertical");
        horizontal = Input.GetAxisRaw("Horizontal");
    }

    private void FixedUpdate()
    {
        body.MovePosition(body.position + new Vector2(horizontal, vertical) * speed * Time.fixedDeltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Adventurer"))
        {
            Destroy(gameObject);
        }
    }
    /*private void OnCollisionEnter2D(Collision collision)
    {
        Debug.Log(collision.gameObject.tag);
        if (collision.gameObject.CompareTag("Adventurer"))
        {
            Debug.Log("Attempting ignore collision");
            Physics.IgnoreCollision(collision.collider, Collider);
        }
    }*/
}
