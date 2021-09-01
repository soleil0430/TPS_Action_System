using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move;

public class Shooter : MonoBehaviour
{
    public GameObject prefab;
    public Transform muzzle;

    public Transform target;
    //public WayPointMoverSO wMover;

    public List<Vector3> wayPoints;
    public float speed;


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            muzzle.LookAt(target);

            GameObject instance = Instantiate(prefab, muzzle.position, muzzle.rotation);
            Movement movement = instance.GetComponent<Movement>();

            
            WayPointMoverSO moveSO = ScriptableObject.CreateInstance<WayPointMoverSO>();

            moveSO.rWayPoints = wayPoints.ConvertAll(o => o);
            moveSO.rSpeed = speed;

            movement.moverSO = moveSO;
        }
    }

}
