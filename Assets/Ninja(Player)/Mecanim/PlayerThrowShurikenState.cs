using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerThrowShurikenState : MecanimState<Player>
{
    public float speed;
    public float acceleration;

    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        if (CanUpdate(animator, stateInfo, layerIndex, controller) == false)
            return;


        entity.speed = speed;
        entity.accelerationGround = acceleration;
        entity.accelerationForward = acceleration;

        entity.controller.Move(entity.inputDirection, entity.speed, entity.accelerationMovement);
        entity.controller.Forwarding(entity.inputDirection, entity.accelerationForward);


        if (Input.GetKeyDown(KeyCode.Mouse1))
            animator.SetTrigger("tThrowShuriken");

        if (Input.GetKeyDown(KeyCode.Space))
            entity.controller.Jump(entity.jumpHeight);

        if (Input.GetKeyDown(KeyCode.LeftShift))
            animator.SetTrigger("tDodge");
    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("tThrowShuriken");
    }

}