using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Movement
{
    public class Bezier3Movement : BaseMovement
    {
        public List<Vector3> bezierPoints = new List<Vector3>(2);
        
        public float duration;
        public float timer;

        
        private void OnEnable()
        {
            if (bezierPoints.Count < 2)
            {
                bezierPoints.Add(rigidbody.position);
                bezierPoints.Add(rigidbody.position);
            }
        }

        private void Update()
        {
            float _timer = timer / duration;

            rigidbody.MovePosition(GetInterpolatePoint(bezierPoints));
            
            timer += Time.deltaTime;
        }


        public Vector3 GetInterpolatePoint(List<Vector3> points)
        {
            List<Vector3> iPoints = new List<Vector3>();
            
            for (int i = 0; i < points.Count - 1; i++)
            {
                iPoints.Add(Vector3.Lerp(points[i], points[i + 1], timer));
#if UNITY_EDITOR
                Debug.DrawLine(points[i], points[i + 1]);
#endif
            }
            points = iPoints;

            if (points.Count <= 1)
            {
                return points[0];
            }
            else
            {
                return GetInterpolatePoint(points);
            }
        }

        

    }
}