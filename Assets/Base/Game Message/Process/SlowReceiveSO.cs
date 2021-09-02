using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GameMessage;



namespace Bound
{
    [CreateAssetMenu(fileName = "Slow ReceiveSO", menuName = "Bound/Receive/Slow")]
    public class SlowReceiveSO : ReceiveProcessSO, ISerializationCallbackReceiver
    {
        [Header("Editor")]
        [SerializeField] private float slowMultiple;

        [Header("Runtime")]
        [DisableField] public float rSlowMultiple;

        public override void Process(object msg, Character character)
        {
            if (msg is SlowMessage)
            {
                ISlow iSlow = character.GetComponent<ISlow>();
                if (iSlow != null)
                {
                    SlowMessage sMsg = msg as SlowMessage;
                    sMsg.slow *= rSlowMultiple;

                    iSlow.GetSlow(sMsg);
                }
            }
        }

        void ISerializationCallbackReceiver.OnBeforeSerialize() { }

        void ISerializationCallbackReceiver.OnAfterDeserialize()
        {
            rSlowMultiple = slowMultiple;
        }
    }
}