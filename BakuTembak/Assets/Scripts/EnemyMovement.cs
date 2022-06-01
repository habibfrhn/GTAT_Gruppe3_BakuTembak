using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovementThird : MonoBehaviour
{
    public Rigidbody2D rb;
    Vector2 movement;

    // the states needed
    public enum EnemyState {MOVE, WAIT};
    private EnemyState state = EnemyState.WAIT;

    // if direction is true, it means it is facing right
    public bool direction = true;

    public float speed =  20f;
    public float walkInterval = 5f;
    public float walkCountdown;

    void Start()
    {
        // get the component
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

        // to enter new state
        WalkContinue();

        yield break;
    }

    void FixedUpdate()
    {
        // to move the enemy
        // always move either right or left
        if (direction)
        {
            rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        }
        else
        {
            rb.velocity = new Vector2(-speed * Time.deltaTime, rb.velocity.y);
        }
    }

    void WalkContinue()
    {
        // change state
        state = EnemyState.WAIT;

        // change the direction it's facing
        direction = !direction;

        // reset the countdown
        walkCountdown = walkInterval;
    }

}
