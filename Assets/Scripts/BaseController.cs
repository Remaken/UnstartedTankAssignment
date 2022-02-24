using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class BaseController : MonoBehaviour
{
    public Tank tankManager;
    public Transform headTransform;
    public Transform projectileSpawnPoint;
    public GameObject projectilePrefab;
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
        Instantiate(projectilePrefab,projectileSpawnPoint);
    }
}
