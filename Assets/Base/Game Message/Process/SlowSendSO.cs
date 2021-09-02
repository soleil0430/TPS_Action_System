using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;


namespace Bound
{
    [CreateAssetMenu(fileName = "Slow SendSO", menuName = "Bound/Send/Slow")]
    public class SlowSendSO : SendProcessSO, ISerializationCallbackReceiver
    {
        [Header("Editor")]
        [SerializeField] private SlowMessage msg;

        [Header("RunTime")]
        [DisableField] public SlowMessage rMsg;


        public override void Process(GameObject creator, Collider sender, Collider receiver)
        {
            ReceiveBound rBound = receiver.GetComponent<ReceiveBound>();
            SlowMessage sMsg = new SlowMessage(creator, sender.gameObject, receiver.gameObject,
                                               GetHitPoint(sender, receiver), GetHitNormal(sender, receiver),
                                               rMsg.slow);

            rBound.Receive(sMsg);
        }


        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rMsg = msg;
        }
    }
}