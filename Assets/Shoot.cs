using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    // Start is called before the first frame update
    public Camera camera;
    public float range = 100f;
    public float timeToResetShot = 1f;
    public bool isShooting = false;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        StartShooting();
    }

    void StartShooting()
    {
        if(!isShooting && Input.GetMouseButtonDown(0))
        {
            isShooting = true;
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out hit, range))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log("Did Hit");
            }
            else
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * 1000, Color.white);
                Debug.Log("Did not Hit");
            }
            Invoke("ResetShot", timeToResetShot);
        }


    }

    void ResetShot()
    {
        isShooting=false;   
    }
}
