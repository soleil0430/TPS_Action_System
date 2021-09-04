using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Bound
{
    public class DamageBound : SendBound
    {
        public DamageMessage message;
        

        protected override void SetBoundMessage(BoundMessage _msg, Collider other)
        {
            base.SetBoundMessage(_msg, other);
            DamageMessage _message = _msg as DamageMessage;
        }

        protected override void OnTriggerEnter(Collider other)
        {
            ReceiveBound rBound = other.GetComponent<ReceiveBound>();

            if (rBound)
            {
                SetBoundMessage(message, other);
                if (rBound.ReceiveBoundMessage(message) && audioClip)
                    audioSource.PlayOneShot(audioClip);
            }
        }
    }
}