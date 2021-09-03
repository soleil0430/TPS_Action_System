using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Projectile
{
    public class ProjectileBase : MonoBehaviour
    {
        public float lifeTime;

        private void Awake()
        {
            Destroy(this, lifeTime);
        }


        private void OnTriggerEnter(Collider other)
        {
            Destroy(gameObject);
        }
    }

}