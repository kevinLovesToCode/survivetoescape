using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    // Start is called before the first frame update
    [Header("Settings")]
    public string gunName = "";
    public float range = 100f;
    public int Ammocount = 25;
    public int reloadTime = 2;
    public Camera camera;
    public GameObject DanielsBullethoes;
    public bool isShooting = false;
    public float shootTime = .25f;
    public New_Weapon_Recoil_Script recoil;
    
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Shoot();
    }
    void Shoot()
    {
        if (Input.GetButtonDown("Fire1") && !isShooting)
        {
            RaycastHit hit;
                isShooting = true;
            recoil.Fire();

            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, range))
            {
                Debug.DrawRay(transform.position, transform.TransformDirection(Vector3.forward) * hit.distance, Color.yellow);
                Debug.Log(hit.transform.name);
                if (hit.transform != null)
                {

                    Instantiate(DanielsBullethoes, hit.point, Quaternion.LookRotation(hit.normal));
                }

            }
            Invoke("ResetShot", shootTime);


        }
    }
    void ResetShot()
    {
        isShooting = false;
    }
}
