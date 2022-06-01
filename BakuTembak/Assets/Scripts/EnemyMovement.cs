using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementSecond : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    public enum EnemyState {MOVE, WAIT};

    private EnemyState state = EnemyState.WAIT;

    public bool direction = true;

    public float speed =  20f;
    public float walkInterval = 5f;
    public float walkCountdown;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        walkCountdown = walkInterval;
    }

    void Update ()
    {
        if(walkCountdown <= 0)
        {
            if (state != EnemyState.MOVE)
            {
                // based on the direction, will face right or left
                StartCoroutine(Moving(direction));
            }
        }
        else
        {
            walkCountdown -= Time.deltaTime;
        }
    }

    IEnumerator Moving(bool faceRight)
    {
        state = EnemyState.MOVE;

        // go to right
        if (faceRight)
        {
            for (float i = 0; i < walkInterval; i++)
            {
                movement.x += speed;
            }
        }
        // go to left
        else if (faceRight == false)
        {
            for (float i = 0; i < walkInterval; i++)
            {
                movement.x -= speed;
            }
        }

        // to enter new state
        WalkContinue();

        yield break;
    }

    void FixedUpdate()
    {
        // to move the enemy
        rb.velocity = new Vector2(movement.x * Time.deltaTime, rb.velocity.y);
    }

    void WalkContinue()
    {
        // change state
        state = EnemyState.WAIT;

        // change the direction it's facing
        direction = !direction;

        walkCountdown = walkInterval;

        //StartCoroutine(Moving(direction));
    }

    void WalkComplete()
    {
        state = EnemyState.WAIT;

        // change the direction it's facing
        // direction = !direction;
        Flip();

        walkCountdown = walkInterval;
    }

    private void Flip()
    {
        // Switch facing
        direction = !direction;

        //rotate the player in y-axis
        transform.Rotate(0f, 180f, 0f);
    }
    
}
