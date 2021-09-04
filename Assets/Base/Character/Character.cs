using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bound;

public abstract class Character : MonoBehaviour
{
    public bool isInvincible = false;
    public float invincibleDuration = 1f;

    public abstract bool GetDamage(DamageMessage msg);

    //public virtual void GetSlow(SlowMessage msg) { }

    public abstract bool GetDirection(DirectionMessage msg);

    //public virtual void GetSlow(SlowMessage msg, ReceiveBound body)
    //{
    //    Debug.Log("Get Slow");
    //}


    protected virtual void OnInvincible(float _time)
    {
        if (_time > 0f)
            StartCoroutine(InvincibleRoutine(_time));
        else
            StartCoroutine(InvincibleRoutine(invincibleDuration));
    }

    protected virtual IEnumerator InvincibleRoutine(float _time)
    {
        yield return new WaitForEndOfFrame();
        isInvincible = true;
        yield return new WaitForSeconds(_time);
        isInvincible = false;
    }


}
