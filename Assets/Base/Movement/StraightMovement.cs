using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Movement
{
    public class StraightMovement : BaseMovement
    {
        void Update()
        {
            rigidbody.MovePosition(rigidbody.position + direction * speed * Time.deltaTime);
        }

        private void OnDrawGizmos()
        {
            if (rigidbody)
            {
                Gizmos.color = Color.red;
                Gizmos.DrawLine(rigidbody.position, rigidbody.position + direction * speed);
            }
        }
    }


}