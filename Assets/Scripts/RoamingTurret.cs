using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;
using UnityEngine.AI;

public class RoamingTurret : Turret
{
    public Transform[] positionDeDeplacement;
    private NavMeshAgent roamingTurret;
    private bool[] checkPositions = {true, false, false, false};
    private Vector3 _exDestination;
    private bool detec = false;
    private void Start()
    {
        roamingTurret = GetComponent<NavMeshAgent>();
        state = TurretState.Searching;
        HP = 2;
        roamingTurret.SetDestination(positionDeDeplacement[0].position);
    }

    private void Update()
    {
        Roaming();
        if (CheckForTransition())
        {
            TransitionOrChangeState();
        }
        StateBehaviour();
        HPManager();
        TankFollow();
    }
    private void Roaming()
    {
        if ((roamingTurret.remainingDistance<1)&&(checkPositions[0]==true)&&!IsTankDetected())
        {
            print("Patrouille pos 1");
            roamingTurret.SetDestination(positionDeDeplacement[1].position);
            checkPositions[1] = true;
            checkPositions[0] = false;
        }
        if ((roamingTurret.remainingDistance<=1)&&checkPositions[1]==true&&!IsTankDetected())
        {
            print("Patrouille pos 2");
            roamingTurret.SetDestination(positionDeDeplacement[3].position);
            checkPositions[3] = true;
            checkPositions[1] = false;
        }
        if ((roamingTurret.remainingDistance<=1)&&checkPositions[3]==true&&!IsTankDetected())
        {
            print("Patrouille pos 3");
            roamingTurret.SetDestination(positionDeDeplacement[2].position);
            checkPositions[2] = true;
            checkPositions[3] = false;
        } 
        if ((roamingTurret.remainingDistance<=1)&&checkPositions[2]==true&&!IsTankDetected())
        {
            print("Patrouille pos 4");
            roamingTurret.SetDestination(positionDeDeplacement[0].position);
            checkPositions[0] = true;
            checkPositions[2] = false;
        }
        /*else if (roamingTurret.remainingDistance<=1)
        {
            roamingTurret.SetDestination(positionDeDeplacement[2].position);
            
        }
        else if (roamingTurret.remainingDistance<=1)
        {
            roamingTurret.SetDestination(positionDeDeplacement[3].position);
            
        }
        else if (roamingTurret.remainingDistance<=1)
        {
            roamingTurret.SetDestination(positionDeDeplacement[0].position);
            
        }*/
    }

    private void TankFollow()
    {
        if (IsTankDetected())
        {
            if (detec == false)
            {
                _exDestination = roamingTurret.destination;
                detec = true;
            }
            print("Suit");
            roamingTurret.SetDestination(tankTransform.position);
        }
        else
        {
            detec = false;
            roamingTurret.SetDestination(_exDestination);
        }
        
    }

}
