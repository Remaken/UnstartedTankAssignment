using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class Turret : BaseController
{
    public Transform tankTransform;
    public float detectionDistance=4f;
    private bool _isTankDetected = false;
    private float _timeBeforeFire;
    private float _timer;
    
    void Start()
    {
        
    }
    
    void Update()
    {
      IsTankDetected();
    }

    private void IsTankDetected()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(tankTransform.position - headTransform.position);
        if ( Physics.Raycast(headTransform.position,direction, out hit,detectionDistance ))
        {
            if (hit.collider.GetComponentInParent<Tank>())
            {
                Debug.DrawLine(headTransform.position, direction,Color.red,1f);
            }
            
        }
        
        
    }

    /*private bool FireTimer()
    {
        yield return WaitForSeconds=2f;
        Fire();
        
    }
    */
}
