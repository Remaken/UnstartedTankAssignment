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

    [SerializeField] protected MeshRenderer HPColorManager;
    protected Vector3 directionTank;
    protected RaycastHit chercheurTank;
    public Transform tankTransform;
    [SerializeField] private float detectionDistance=2f;
    [SerializeField] private float followDistance = 2f;
    [SerializeField]private float fireDistance = 4f;
    protected float _timereset = 0f;
    protected bool isRotating=true;
    protected int HP = 4;
    
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

    private bool CheckForTransition()
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

    private void TransitionOrChangeState()
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

    private void StateBehaviour()
    {
        switch (state)
        {
            case TurretState.None:
                break;
            case TurretState.Searching:
                break;
            case TurretState.TankDetected:
                TurretShoot();

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
                Debug.DrawRay(transform.position, directionTank, Color.green);
                isRotating = false;
                return true;
            }
        }
        else isRotating = true;

        return false;
    }

    protected void TurretSearching()
    {
        if (!IsTankDetected())
        {
            if (isRotating == true)
            {
                headTransform.RotateAround(headTransform.position,Vector3.up,0.5f);   
            }
        }
            
    }
    protected bool TurretShoot()
        {
            if (Physics.Raycast(headTransform.position, directionTank, out chercheurTank, followDistance)) 
            {
                isRotating =false;
                headTransform.LookAt(new Vector3(chercheurTank.point.x, headTransform.position.y, chercheurTank.point.z));
                if ((chercheurTank.collider.gameObject.GetComponentInParent<Tank>() != null)&&(Physics.Raycast(headTransform.position, directionTank, out chercheurTank, fireDistance))) 
                {
                    StartCoroutine(Fire());
                }
            }

            return true;
        }

    private void OnTriggerEnter(Collider other)
    { 
        if ((HP>0)&&(other.gameObject.CompareTag("Bullet")))
        {
            HP--;
            HPManager();
            if (HP<=0)
            {
                Destroy(gameObject.GetComponentInParent<Turret>().gameObject);
            }   
        }
    }

    protected void HPManager()
    {
            Color newColor = new Color(128f,0f,0f);
            if (HP==3)
            {
                HPColorManager.material.SetColor("_Color", Color.yellow);
            }
            if (HP==2)
            {
                HPColorManager.material.SetColor("_Color", /*newColor*/ Color.magenta);
                HPColorManager.transform.localScale = new Vector3(0.5f, 0.8f, 0.5f);
                
            }
            if (HP==1)
            {  
                HPColorManager.material.SetColor("_Color", Color.red);
                HPColorManager.transform.localScale = new Vector3(0.5f, 0.5f, 0.5f);
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
