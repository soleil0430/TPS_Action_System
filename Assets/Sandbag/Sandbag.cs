using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Bound;

public class Sandbag : Character
{
    [GetComponent, DisableField] public Rigidbody body;

    [SerializeField] MeshRenderer render;

    public float knockback;
    public float nowHp;
    public float maxHp;

    Color color = Color.white;


    public Vector3 startPos;
    [Min(1f)] public float respawnInterval;

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        startPos = transform.position;

        StartCoroutine(RespawnRoutine());
    }

    IEnumerator RespawnRoutine()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnInterval);
            transform.position = startPos;
            nowHp = maxHp;
            color = new Color(1f, nowHp / maxHp, nowHp / maxHp);
            render.material.color = color;
        }
    }



    public override bool GetDamage(DamageMessage msg)
    {
        if (isInvincible)
            return false;

        nowHp -= msg.damage;

        if (nowHp <= 0f)
            nowHp = maxHp;

        color = new Color(1f, nowHp / maxHp, nowHp / maxHp);

        render.material.color = color;

        OnInvincible(msg.invincibleDuration);
        return true;
    }

    public override bool GetDirection(DirectionMessage msg)
    {
        if (isInvincible)
            return false;

        body.AddForce(msg.direction * msg.power * knockback, ForceMode.VelocityChange);
        return true;
    }
}
