using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Bound
{
    public abstract class SendBound : MonoBehaviour
    {
        [GetComponent, DisableField] public AudioSource audioSource;
        [SerializeField] protected AudioClip audioClip;
        public Transform sender;

        protected virtual void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
        }


        protected virtual void SetBoundMessage(BoundMessage _msg, Collider other)
        {
            _msg.sender = sender;
            _msg.receiver = other.GetComponent<ReceiveBound>().character.transform;

            _msg.sendBound = gameObject;
            _msg.receiveBound = other.gameObject;

            _msg.hitPoint = other.ClosestPoint(transform.position);
            _msg.hitNormal = (_msg.hitPoint - other.transform.position).normalized;
        }


        protected abstract void OnTriggerEnter(Collider other);
    }

}