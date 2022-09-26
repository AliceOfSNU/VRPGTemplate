using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using MovementState = ClientCharacterMovement.MovementState;

public class ClientCharacterVisual : MonoBehaviour
{
    [SerializeField] private Animator _anim;


    public void OnMovementStateEntered(MovementState state)
    {
        switch (state)
        {
            case MovementState.Idle:
                _anim.SetBool("bWalk", false);
                break;

            case MovementState.Walking:
                _anim.SetBool("bWalk", true);
                break;

            case MovementState.Jump:
                _anim.SetTrigger("tJump");
                break;

            case MovementState.Landing:
                _anim.SetTrigger("tLand");
                break;
        }
    }
}
