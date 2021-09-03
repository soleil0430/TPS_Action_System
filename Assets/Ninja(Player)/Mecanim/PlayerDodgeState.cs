using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;


public class PlayerDodgeState : MecanimState<Player>
{
    [SerializeField] private AnimationCurve moveCurve = new AnimationCurve();

    [SerializeField, Range(0f, 1f)] private float startMoveTimePer;
    [SerializeField, Range(0f, 1f)] private float endMoveTimePer;

    [SerializeField] private float accelerationGround;
    [SerializeField] private float accelerationForward;

    float timer;
    float startMoveTime;
    float endMoveTime;

    float startDelta;
    float endDelta;


    public override void OnStateEnter(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        timer = 0f;

        startMoveTime = stateInfo.length * startMoveTimePer;
        endMoveTime = stateInfo.length * endMoveTimePer;

        endDelta = endMoveTime - startDelta;

    }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        if (CanUpdate(animator, stateInfo, layerIndex, controller) == false)
            return;

        if (startMoveTime <= timer && timer <= endMoveTime)
        {
            entity.speed = entity.dodgeSpeed * moveCurve.Evaluate(timer / endDelta);
        }
        else
        {
            entity.speed = 0f;
        }

        entity.accelerationGround = accelerationGround;
        entity.controller.Move(entity.controller.forward, entity.speed, accelerationGround);

        entity.accelerationForward = accelerationForward;
        entity.controller.Forwarding(entity.inputDirection, entity.accelerationForward);

        if (Input.GetKeyDown(KeyCode.Space))
            entity.controller.Jump(entity.jumpHeight);

        timer += Time.deltaTime;


        if (Input.GetKeyDown(KeyCode.Mouse0))
            animator.SetTrigger("tAttack");

    }

    public override void OnStateExit(Animator animator, AnimatorStateInfo stateInfo, int layerIndex)
    {
        animator.ResetTrigger("tDodge");
    }
}
