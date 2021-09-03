using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;


namespace Bound
{
    [CreateAssetMenu(fileName = "Damage SendSO", menuName = "Bound/Send/Damage")]
    public class DamageSendSO : SendProcessSO, ISerializationCallbackReceiver
    {
        [Header("Editor")]
        [SerializeField] private DamageMessage msg;

        [Header("RunTime")]
        [DisableField] public DamageMessage rMsg;

        public override void Process(GameObject creator, Collider sender, Collider receiver, AttackDirection attackDirection)
        {
            ReceiveBound rBound = receiver.GetComponent<ReceiveBound>();
            DamageMessage dMsg = new DamageMessage(creator, sender.gameObject, receiver.gameObject,
                                                    GetHitPoint(sender, receiver), GetHitNormal(sender, receiver),
                                                    attackDirection,
                                                    rMsg.isIncludeMe, rMsg.invincibleTime, rMsg.damage);

            rBound.Receive(dMsg);
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rMsg = (DamageMessage)msg.Clone();
        }
    }
}