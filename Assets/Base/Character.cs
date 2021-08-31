using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;

public class Character : MonoBehaviour
{
    public bool isInvincible = false;
    public float invincibleTime = 1f;


    public void GetDamage(DamageMessage msg, Body body)
    {
        if (isInvincible == false)
        {
            if (msg.isIncludeMe == false && 
                msg.attacker == this.gameObject)
                return;

            float iTime = (msg.invincibleTime > 0f) ? msg.invincibleTime : invincibleTime;
            StartCoroutine(HitRoutine(iTime));
            string log = "";
            if (msg.attacker)
                log += msg.attacker.name + " �� ";

            log += msg.attack.name + " �� " + body.name + " �� ����";
            
            Debug.Log(log);
        }
    }

    IEnumerator HitRoutine(float time)
    {
        isInvincible = true;
        yield return new WaitForSeconds(time);
        isInvincible = false;
    }


}
