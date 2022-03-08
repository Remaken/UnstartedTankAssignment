using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseController : MonoBehaviour
{
    public Tank tankManager;
    public Turret turretManager;
    public Transform headTransform;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
    public Rigidbody rb;
    protected Vector3 headDirection;
    
    void Start()
    {
        
    }

    
    void Update()
    {
    }


    protected void RotateHeadTowardDirection()
    {
        tankManager.GetMousePosition();
    }

    protected void Fire()
    {
        GameObject bouboule =Instantiate(projectilePrefab,projectileSpawnPoint.position,Quaternion.LookRotation(headTransform.up));
        rb = bouboule.GetComponent<Rigidbody>();
        rb.AddForce(headTransform.forward*500);
    }
}
