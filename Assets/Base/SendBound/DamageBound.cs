using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;


public class DamageBound : SendBound
{
    public bool isIncludeMe = false;
    public float invincibleTime = 0f;
    public float damage = 0f;

    private void OnTriggerStay(Collider other)
    {
        //Sample
        IDamage iDamage = other.GetComponent<IDamage>();
        if (iDamage != null)
        {
            DamageMessage msg = new DamageMessage();
            msg.actor = actor;
            msg.sendBound = this;

            msg.isIncludeMe = isIncludeMe;
            msg.invincibleTime = invincibleTime;
            msg.damage = damage;

            msg.hitPoint = GetHitPoint(other);
            msg.hitNormal = GetHitNormal(other);

            iDamage.GetDamage(msg);
        }
    }
}
