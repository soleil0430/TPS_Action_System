using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

public class Body : MonoBehaviour, IDamage
{
    [GetComponentInParent] Character character;

    public float damageMultiple;

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
    }


    void IDamage.GetDamage(DamageMessage msg)
    {
        msg.damage = msg.damage * damageMultiple;

        character.GetDamage(msg, this);
    }

}
