using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace GameMessage
{
    [System.Serializable]
    public class SlowMessage : BoundMessage
    {
        public float slow;

        public SlowMessage(GameObject _receiveCreator,
                            GameObject _sender, GameObject _receiver,
                            Vector3 _hitPoint, Vector3 _hitNormal,
                            AttackDirection _attackDirection,
                            float _slow) 
            : base(_receiveCreator, _sender, _receiver, _hitPoint, _hitNormal, _attackDirection)
        {
            slow = _slow;
        }
    }

    public interface ISlow
    {
        void GetSlow(SlowMessage msg);
    }


}