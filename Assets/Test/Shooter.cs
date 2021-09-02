using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Move;



public class Shooter : MonoBehaviour
{
    public GameObject prefab;
    public Transform muzzle;
    public int count;

    public Transform target;

    public int nowCount;

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            GameObject instance = Instantiate(prefab, muzzle.position, muzzle.rotation);
        }
    }

}
