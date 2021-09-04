using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bound
{
    public class DirectionBound : SendBound
    {
        public DirectionMessage message;

        protected override void SetBoundMessage(BoundMessage _msg, Collider other)
        {
            base.SetBoundMessage(_msg, other);

            DirectionMessage _message = _msg as DirectionMessage;
            _message.SetDirection(other.transform);
        }


        protected override void OnTriggerEnter(Collider other)
        {
            ReceiveBound rBound = other.GetComponent<ReceiveBound>();

            if (rBound)
            {
                SetBoundMessage(message, other);
                rBound.ReceiveBoundMessage(message);
            }
        }
    }
}