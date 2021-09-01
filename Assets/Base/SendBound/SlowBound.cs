using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

public class SlowBound : SendBound
{
    public float slow;

    private void OnTriggerStay(Collider other)
    {
        //Sample
        ISlow iSlow = other.GetComponent<ISlow>();

        if (iSlow != null)
        {
            SlowMessage msg = new SlowMessage();
            msg.actor = actor;
            msg.sendBound = this;

            msg.hitPoint = GetHitPoint(other);
            msg.hitNormal = GetHitNormal(other);

            msg.slow = slow;

            iSlow.GetSlow(msg);
        }
    }



}
