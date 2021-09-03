using System.Collections;
using System.Collections.Generic;
using UnityEngine;



namespace Movement
{
    public class GuidedMovement : BaseMovement
    {
        [Range(0.001f, 1f)] public float guided;

        public Vector3 toTarget => (targetPosition - rigidbody.position);

        


        private void Update()
        {
            direction = velocity.normalized + (toTarget * Time.deltaTime / guided);
            velocity = direction * speed;

            rigidbody.MovePosition(rigidbody.position + velocity * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            if (rigidbody)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawLine(rigidbody.position, targetPosition);
                Gizmos.DrawWireSphere(targetPosition, 0.2f);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(rigidbody.position, rigidbody.position + velocity);
            }
        }

    }

}