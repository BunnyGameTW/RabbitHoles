using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehavior : MonoBehaviour
{
    public enum STATE { MOVE, IDLE, JUMP, DAMAGE, FALL}
    STATE state;
    Animator animator;
    // Start is called before the first frame update

        //TODO 受傷事件
        //
    void Start()
    {
        animator = GetComponentInChildren<Animator>();
        state = STATE.IDLE;
    }

    // Update is called once per frame
    void Update()
    {
      //  PlayerInput();
        SwitchAnimation();
    }
    void PlayerInput()
    {
     
    }
    void SwitchAnimation()
    {

    }

    //public
    public void SetState(STATE st)
    {
        state = st;
    }
}
