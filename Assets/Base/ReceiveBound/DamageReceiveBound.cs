using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

public class DamageReceiveBound : ReceiveBound, IDamage
{
    public float damageMultiple;

    void IDamage.GetDamage(DamageMessage msg)
    {
        if (isReceive)
        {
            msg.damage = msg.damage * damageMultiple;

            character.GetDamage(msg, this);
        }
    }
}
