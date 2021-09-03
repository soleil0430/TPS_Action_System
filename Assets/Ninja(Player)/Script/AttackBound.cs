using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;


namespace Bound
{

    public class AttackBound : SendBound
    {
        [GetComponent, DisableField] public CinemachineImpulseSource impulseSource;
        [SerializeField] public AudioSource audioSource; 
        [SerializeField] public AudioClip sfx;


        protected override void Awake()
        {
            base.Awake();
        }

        protected override void OnTriggerEnter(Collider other)
        {
            ReceiveBound rBound = other.GetComponent<ReceiveBound>();
            if (rBound)
            {
                foreach (var process in processSOs)
                {
                    process.Process(creator, collider, other, attackDirection);
                }
                impulseSource.GenerateImpulse();
            }

            audioSource.PlayOneShot(sfx);
        }
    }
}