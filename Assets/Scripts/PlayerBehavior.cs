using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public enum STATE { MOVE, IDLE, JUMP, FALL, DAMAGE}
    public bool canMove;

    STATE state;
    Animator charAnimator,emotionAnimator;
    Vector2 targetPosition;
    SpriteRenderer emotionSprite;
    const float SPEED = 10.0f;
    const float CHECK_DISTANCE = 0.1f;

    void Start()
    {
        canMove = true;
        targetPosition = transform.position;
        charAnimator = GetComponentsInChildren<Animator>()[0];
        emotionAnimator = GetComponentsInChildren<Animator>()[1];
        state = STATE.IDLE;
        emotionSprite = GetComponentsInChildren<SpriteRenderer>()[1];
    }

    // Update is called once per frame
    void Update()
    {

        Move();
        SwitchAnimation();
    }

  

    void SwitchAnimation()
    {
        switch (state)
        {
            case STATE.MOVE:
                emotionSprite.enabled = true;
                emotionAnimator.SetTrigger("Heart");
                charAnimator.SetBool("isMove", true);
                break;
            case STATE.IDLE:
                charAnimator.SetBool("isMove", false);
                break;
            case STATE.JUMP:
                charAnimator.SetBool("isOnGround", false);
                break;
            case STATE.DAMAGE:
                charAnimator.SetTrigger("Damage");
                break;
            case STATE.FALL:
                charAnimator.SetBool("isFall", true);
                break;
            default:
                break;
        }
    }

    void Move()
    {
        Vector2 playerPosition = transform.position;
        float offsetX = targetPosition.x - playerPosition.x;
        if (Mathf.Abs(offsetX) > CHECK_DISTANCE)
        {
            GetComponentInChildren<SpriteRenderer>().flipX = offsetX > 0;
            SetState(STATE.MOVE);
            transform.position = Vector2.MoveTowards(playerPosition, targetPosition, Time.deltaTime * SPEED);
        }
        else
        {
            SetState(STATE.IDLE);
        }
       
    }

    //public
    public void SetState(STATE st)
    {
        state = st;
    }

    public void SetTarget(Vector3 value)
    {
        targetPosition = value;
    }
}
