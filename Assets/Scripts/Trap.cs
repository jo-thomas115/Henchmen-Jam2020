using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    public bool armed = true;
    public SpriteRenderer sprite;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.tag);
        if (armed && collision.gameObject.CompareTag("Adventurer"))
        {
            Destroy(collision.gameObject);
            armed = false;
            sprite.color = new Color(1f, 1f, 1f, .5f);
        }
        else if (!armed && collision.gameObject.CompareTag("Player"))
        {
            armed = true;
            sprite.color = Color.red;
        }
    }
}
