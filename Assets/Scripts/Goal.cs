using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Goal : MonoBehaviour
{
    public int health = 10;
    public Text scoreText;
    public Transform player;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = health.ToString();
        scoreText.color = Color.yellow;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Adventurer"))
        {
            Destroy(collision.gameObject);
            health--;
            scoreText.text = health.ToString();
            if(health < 3)
            {
                scoreText.color = Color.red;
            }
            if(health <= 0)
            {
                Destroy(player.gameObject);
            }
        }
    }
}
