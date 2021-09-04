using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public class PlayerJumpThrowShurikenState : MecanimState<Player>
{
    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("tThrowShuriken");
    }

    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        if (CanUpdate(animator, stateInfo, layerIndex, controller) == false)
            return;


        if (entity.controller.isGround)
        {
            entity.speed = entity.runSpeed;
            entity.accelerationMovement = entity.accelerationGround;
            entity.accelerationForward = entity.accelerationGround;
        }
        else
        {
            entity.speed = entity.runSpeed * entity.speedAirMultiple;
            entity.accelerationMovement = entity.accelerationAir;
            entity.accelerationForward = entity.accelerationAir;
        }

        entity.controller.Move(entity.inputDirection, entity.speed, entity.accelerationMovement);
        entity.controller.Forwarding(entity.inputDirection, entity.accelerationForward);

        if (Input.GetKeyDown(KeyCode.Mouse1))
            animator.SetTrigger("tThrowShuriken");

        animator.SetFloat("MovementMultipiler", entity.speed / 6f);
    }


    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("tThrowShuriken");
    }
}
