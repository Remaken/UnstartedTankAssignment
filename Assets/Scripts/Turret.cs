using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public class Turret : BaseController
{
    public Transform tankTransform;
    public float _detectionDistance=2f;
    private float _timeBeforeFire=2f;
    private float _timer;
    private float _timereset = 0f;
    
    void Start()
    {
        _timer = _timereset;
    }
    
    void Update()
    {
      IsTankDetected();
    }

    private void IsTankDetected()
    {
        RaycastHit hit;
        Vector3 direction = Vector3.Normalize(tankTransform.position - headTransform.position);
        // Debug.DrawRay(headTransform.position, direction,Color.red,2f);

        if ( Physics.Raycast(headTransform.position,direction, out hit,_detectionDistance ))
        {
            headTransform.LookAt(new Vector3(hit.point.x,headTransform.position.y,hit.point.z));

            if (hit.collider.gameObject.GetComponentInParent<Tank>() != null)
            {
                headTransform.LookAt(new Vector3(hit.point.x,headTransform.position.y,hit.point.z));
                // Debug.DrawRay(headTransform.position, direction,Color.red,2f);
                 //FireTimer();
              StartCoroutine(FireTimer());
            }
            
        }
        
    }

    /*private void FireTimer()
    {
            if (_timer <= _timeBeforeFire)
            {
                _timer +=  Time.deltaTime;
                if (_timer >= _timeBeforeFire)
                {
                    Fire();
                    _timer = _timereset;
                }
            }
    }*/
    
    
  IEnumerator FireTimer()
    {
        yield return new WaitForSeconds(2f);
        Fire();
    }
   
}
