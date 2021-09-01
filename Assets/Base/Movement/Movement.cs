using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace Move
{
    public class Movement : MonoBehaviour
    {
        [GetComponent] Rigidbody rigidbody;

        public Transform target;
        public Vector3 targetPoint;
        public Vector3 startPoint;

        public StraightMover straightMover;
        public DecidedMover decidedMover;
        public Bezier3Mover bezier3Mover;
        public GuidedMover guidedMover;
        public WayPointMover wayPointMover;

        public List<IMover> movers;

        public EMover eMover;
        public IMover iMover;


        private void Awake()
        {
            GetComponentAttributeSetter.DoUpdate_GetComponentAttribute(this);

            rigidbody.useGravity = false;
            rigidbody.interpolation = RigidbodyInterpolation.Interpolate;
            rigidbody.collisionDetectionMode = CollisionDetectionMode.ContinuousDynamic;

            movers.Add(straightMover);
            movers.Add(decidedMover);
            movers.Add(bezier3Mover);
            movers.Add(guidedMover);
            movers.Add(wayPointMover);

            SetIMover();
        }

        private void Update()
        {
            iMover?.Move(rigidbody);
        }

        public void SetIMover()
        {
            //switch (eMover)
            //{
            //    case EMover.None:
            //        break;
            //    case EMover.Straight:
            //        iMover = straightMover;
            //        break;
            //    case EMover.Decided:
            //        iMover = decidedMover;
            //        break;
            //    case EMover.Bezier3:
            //        iMover = bezier3Mover;
            //        break;
            //    case EMover.Guided:
            //        iMover = guidedMover;
            //        break;
            //    case EMover.WayPoint:
            //        iMover = wayPointMover;
            //        break;
            //    default:
            //        break;
            //}

            iMover = movers[(int)eMover];
        }

#if UNITY_EDITOR
        private void OnDrawGizmos()
        {
            iMover?.DrawGizmos();
        }
#endif
    }
}