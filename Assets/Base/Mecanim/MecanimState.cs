using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;

public abstract class MecanimState<T> : StateMachineBehaviour where T : MonoBehaviour
{
    [DisableField] public T entity;
    [SerializeField] private bool isTransitionOnUpdate = false;

    public sealed override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex) { }


    public override void OnStateUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        
    }

    protected bool CanUpdate(Animator animator, AnimatorStateInfo stateInfo, int layerIndex, AnimatorControllerPlayable controller)
    {
        if (isTransitionOnUpdate == false)
        {
            if (controller.IsInTransition(layerIndex))
            {
                AnimatorStateInfo nextStateInfo = controller.GetNextAnimatorStateInfo(layerIndex);

                int nowHash = stateInfo.tagHash;
                int nextHash = nextStateInfo.tagHash;
#if UNITY_EDITOR

                if (nowHash == 0 || nextHash == 0)
                {
                    Debug.LogError("[" + animator.gameObject.name + " ] 의 State중 Tag값이 없는 State가 있습니다. Layer : " + layerIndex);
                    return false;
                }
#endif

                if (nowHash != nextHash)
                    return false;
                else
                    return true;
            }
            return true;
        }

        return true;
    }



}
