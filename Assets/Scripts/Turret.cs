using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;
using UnityEngine.Serialization;

public enum TurretState
{
    None,
    Searching,
    TankDetected,
}
public class Turret : BaseController
{
    public TurretState state = TurretState.None;
    public TurretState nextState = TurretState.None;

    protected Vector3 directionTank;
    protected RaycastHit chercheurTank;
    public Transform tankTransform;
    public float detectionDistance=2f;
    public float fireDistance = 2f;
    protected float _timereset = 0f;
    protected bool isRotating=true;
    protected int HP = 3;
    
    void Start()
    {
        state = TurretState.Searching;
    }
    
    void Update()
    {
        if (CheckForTransition())
        {
            TransitionOrChangeState();
        }
        StateBehaviour();
    }

    protected bool CheckForTransition()
    {
        switch (state)
        {
          case TurretState.None:
              break;
          case TurretState.Searching:
              if (IsTankDetected())
              {
                  print("is searching");
                  nextState = TurretState.TankDetected;
                  return true;
              }
              TurretSearching();
              break;
          case TurretState.TankDetected:
              if (!IsTankDetected())
              {
                  nextState = TurretState.Searching;
                  return true;
              }
              isRotating = true;
              break;
        }
        return false;
    }

    protected void TransitionOrChangeState()
    {
        switch (nextState)
        {
            case TurretState.None:
                break;
            case TurretState.Searching:
                break;
            case TurretState.TankDetected:
                break;
        }

        state = nextState;
    }

    protected void StateBehaviour()
    {
        switch (state)
        {
            case TurretState.None:
                break;
            case TurretState.Searching:
                break;
            case TurretState.TankDetected:
                TurretShoot();
                print("tank found");

                break;
        }
    }

    protected bool IsTankDetected()
    {
        directionTank = Vector3.Normalize(tankTransform.position - headTransform.position);
        if ( Physics.Raycast(headTransform.position,directionTank, out chercheurTank,detectionDistance ))
        {
            if (chercheurTank.collider.gameObject.GetComponentInParent<Tank>() != null)
            {
                return true;
            }
        }

        isRotating = true;
        return false;
    }

    protected void TurretSearching()
    {
        if (isRotating)
        {
            headTransform.RotateAround(headTransform.position,Vector3.up,0.5f);   
        }
       
    }
protected void TurretShoot()
    {
        if (Physics.Raycast(headTransform.position, directionTank, out chercheurTank, fireDistance)) 
        {
            isRotating =false;
            headTransform.LookAt(new Vector3(chercheurTank.point.x, headTransform.position.y, chercheurTank.point.z));
            if (chercheurTank.collider.gameObject.GetComponentInParent<Tank>() != null)
            {
                StartCoroutine(Fire());
            }
        }
    }

private void OnTriggerEnter(Collider other)
{ 
    if ((HP>0)&&(other.gameObject.CompareTag("Bullet")))
    {
        HP--;
        if (HP<=0)
        {
            Destroy(gameObject.GetComponentInParent<Turret>().gameObject);
        }   
    }
}

void codeUtiliséInutile()
    {
        
        // Debug.DrawRay(headTransform.position, direction,Color.red,2f);
        // private float _timeBeforeFire=2f;
        // Debug.DrawRay(headTransform.position, direction,Color.red,2f);
        //FireTimer();
        
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

    }
}
