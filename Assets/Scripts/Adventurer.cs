using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class Adventurer : MonoBehaviour
{
    private Rigidbody2D rb;
    private RaycastHit2D[] hitDirections;
    private int[] possibleDir;

    private Vector3 moveVector;
    public float decisionTimer = 2f;

    public float[] distances;
    public int moveDirection = 1;
    public float moveSpeed = 2f;
    public float decisionCooldown = 2f;

    private void Start()
    {

    }
    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        Physics2D.queriesStartInColliders = false;
        hitDirections = new RaycastHit2D[4];
        distances = new float[4];
        possibleDir = new int[3];
    }

    void Update()
    {
        if(decisionTimer > 0)
        {
            decisionTimer -= Time.deltaTime;
        }
        if(decisionTimer < 0)
        {
            decisionTimer = 0;
        }
    }
    void FixedUpdate()
    {
        switch (moveDirection)
        {
            case (0):
                moveVector = Vector2.left;
                break;
            case (1):
                moveVector = Vector2.up;
                break;
            case (2):
                moveVector = Vector2.right;
                break;
            case (3):
                moveVector = Vector2.down;
                break;
        }
        if (decisionTimer <= 0)
        {
            hitDirections[0] = Physics2D.Raycast(transform.position, Vector2.left);
            hitDirections[1] = Physics2D.Raycast(transform.position, Vector2.up);
            hitDirections[2] = Physics2D.Raycast(transform.position, Vector2.right);
            hitDirections[3] = Physics2D.Raycast(transform.position, Vector2.down);

            distances[0] = ((Vector3)hitDirections[0].point - transform.position).magnitude;
            distances[1] = ((Vector3)hitDirections[1].point - transform.position).magnitude;
            distances[2] = ((Vector3)hitDirections[2].point - transform.position).magnitude;
            distances[3] = ((Vector3)hitDirections[3].point - transform.position).magnitude;

            if (moveDirection == 0 || distances[0] == 0)//moving left
            {
                int dirNum = 0;
                //check 3, 0, 1
                if (distances[3] > .75f)//check down
                {
                    possibleDir[dirNum] = 3;
                    dirNum++;
                }
                if (distances[0] > .75f)//check left
                {
                    possibleDir[dirNum] = 0;
                    dirNum++;
                }
                if (distances[1] > .75f)//check up
                {
                    possibleDir[dirNum] = 1;
                    dirNum++;
                }
                if (dirNum > 0)
                {
                    int coin = Random.Range(0, dirNum);
                    moveDirection = possibleDir[coin];
                    decisionTimer = decisionCooldown;
                }
                else
                {
                    moveDirection = 2;
                }
            }
            else if (moveDirection == 1 || distances[1] == 0)
            {
                int dirNum = 0;
                //check 0, 1, 2
                if (distances[0] > .75f)//check left
                {
                    possibleDir[dirNum] = 0;
                    dirNum++;
                }
                if (distances[1] > .75f)//check up
                {
                    possibleDir[dirNum] = 1;
                    dirNum++;
                }
                if (distances[2] > .75f)//check right
                {
                    possibleDir[dirNum] = 2;
                    dirNum++;
                }
                if (dirNum > 0)
                {
                    int coin = Random.Range(0, dirNum);
                    moveDirection = possibleDir[coin];
                    decisionTimer = decisionCooldown;
                }
                else
                {
                    moveDirection = 3;
                }
                //don't check 3
            }
            else if (moveDirection == 2 || distances[2] == 0)
            {
                int dirNum = 0;
                //check 0, 1, 2
                if (distances[1] > .75f)//check up
                {
                    possibleDir[dirNum] = 1;
                    dirNum++;
                }
                if (distances[2] > .75f)//check right
                {
                    possibleDir[dirNum] = 2;
                    dirNum++;
                }
                if (distances[3] > .75f)//check down
                {
                    possibleDir[dirNum] = 3;
                    dirNum++;
                }
                if (dirNum > 0)
                {
                    int coin = Random.Range(0, dirNum);
                    moveDirection = possibleDir[coin];
                    decisionTimer = decisionCooldown;
                }
                else
                {
                    moveDirection = 0;
                }
                //don't check 0
            }
            else if (moveDirection == 3 || distances[3] == 0)
            {
                int dirNum = 0;
                //check 0, 1, 2
                if (distances[2] > .75f)//check right
                {
                    possibleDir[dirNum] = 2;
                    dirNum++;
                }
                if (distances[3] > .75f)//check down
                {
                    possibleDir[dirNum] = 3;
                    dirNum++;
                }
                if (distances[0] > .75f)//check left
                {
                    possibleDir[dirNum] = 0;
                    dirNum++;
                }
                if (dirNum > 0)
                {
                    int coin = Random.Range(0, dirNum);
                    moveDirection = possibleDir[coin];
                    decisionTimer = decisionCooldown;
                }
                else
                {
                    moveDirection = 1;
                }
                //don't check 1
            }
        }
        rb.MovePosition((Vector3)rb.position + moveVector * Time.fixedDeltaTime * moveSpeed);
    }
}
