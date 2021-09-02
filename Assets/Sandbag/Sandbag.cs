using GameMessage;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sandbag : Character
{
    [GetComponent] Rigidbody body;

    [SerializeField] MeshRenderer render;

    public float knockback;
    public float nowHp;
    public float maxHp;

    Color color = Color.white;

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
    }




    public override void GetDamage(DamageMessage msg)
    {
        Debug.Log(msg.damage);
        nowHp -= msg.damage;

        if (nowHp <= 0f)
            nowHp = maxHp;

        color = new Color(1f, nowHp / maxHp, nowHp / maxHp);

        render.material.color = color;
        body.AddForce(-msg.hitNormal * msg.damage * knockback, ForceMode.VelocityChange);
    }

}
