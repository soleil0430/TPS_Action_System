using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

public abstract class Character : MonoBehaviour
{
    public bool isInvincible = false;
    public float invincibleTime = 1f;


    public virtual void GetDamage(DamageMessage msg, ReceiveBound body) 
    {
        Debug.Log("Get Damage");
    }

    public virtual void GetSlow(SlowMessage msg, ReceiveBound body)
    {
        Debug.Log("Get Slow");
    }


    protected virtual void Invincible() { }
}