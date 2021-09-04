using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class PlayerParticle : MonoBehaviour
{
    public enum EParticle
    {
        ThrowShuriken = 0,
        Attack1,
        Attack2,
        Attack3,
        JumpAttack,
    }

    [GetComponent, DisableField] public AudioSource audioSource;
    public ParticleSystem[] particles;

    private void Awake()
    {
        GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);
    }

    public void PlayParticle(EParticle ep)
    {
        particles[(int)ep].Stop(true);
        particles[(int)ep].Play(true);
    }

    public void PlaySound(AudioClip clip)
    {
        audioSource.PlayOneShot(clip);
    }
}
