using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Movement
{
    public class DecidedMovement : BaseMovement
    {
        public AnimationCurve moveCurve = new AnimationCurve();

        public Vector3 startPosition;
        public Vector3 endPosition;
        public float duration;

        public float timer;

        Vector3 toEnd => endPosition - startPosition;
        

        private void Update()
        {
            if (timer < duration)
            {
                rigidbody.MovePosition(startPosition + toEnd * (moveCurve.Evaluate(timer / duration)));
                timer += Time.deltaTime;
            }
        }

        private void OnDrawGizmos()
        {
            if (rigidbody)
            {
                Gizmos.color = Color.green;
                Gizmos.DrawWireSphere(endPosition, 0.2f);
                Gizmos.DrawLine(startPosition, endPosition);

                Gizmos.color = Color.red;
                Gizmos.DrawLine(startPosition, rigidbody.position);
                Gizmos.DrawWireSphere(rigidbody.position, 0.2f);
            }
        }

    }
}