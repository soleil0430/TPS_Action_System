using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

namespace GameMessage
{
    [System.Serializable]
    public class BoundMessage : ICloneable
    {
        public GameObject receiveCreator;

        public GameObject sender;
        public GameObject receiver;

        public Vector3 hitPoint;
        public Vector3 hitNormal;

        public BoundMessage(GameObject _receiveCreator,
                            GameObject _sender, GameObject _receiver,
                            Vector3 _hitPoint, Vector3 _hitNormal)
        {
            receiveCreator = _receiveCreator;

            sender = _sender;
            receiver = _receiver;

            hitPoint = _hitPoint;
            hitNormal = _hitNormal;
        }

        public virtual object Clone()
        {
            BoundMessage msg = new BoundMessage(receiveCreator,
                                                sender, receiver,
                                                hitPoint, hitNormal);

            return msg;
        }
    }
}