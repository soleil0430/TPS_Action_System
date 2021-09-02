using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;
using System;

namespace Bound
{
    [CreateAssetMenu(fileName = "Damage ReceiveSO", menuName = "Bound/Receive/Damage")]
    public class DamageReceiveSO : ReceiveProcessSO, ISerializationCallbackReceiver
    {
        [Header("Editor")]
        [SerializeField] private float damageMultiple;

        [Header("Runtime")]
        [DisableField] public float rDamageMultiple;

        public override void Process(object msg, Character character)
        {
            if (msg is DamageMessage)
            {
                IDamage iDamage = character.GetComponent<IDamage>();
                if (iDamage != null)
                {
                    DamageMessage dMsg = msg as DamageMessage;
                    dMsg.damage *= rDamageMultiple;

                    iDamage.GetDamage(dMsg);
                }
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rDamageMultiple = damageMultiple;
        }
    }
}