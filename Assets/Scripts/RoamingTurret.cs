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
    private void Start()
    {
        roamingTurret = GetComponent<NavMeshAgent>();
        state = TurretState.Searching;
        HP = 1;
        roamingTurret.SetDestination(positionDeDeplacement[0].position);
    }

    private void Update()
    {
        Roaming();
        TankFollow();
        if (CheckForTransition())
        {
            TransitionOrChangeState();
        }
        StateBehaviour();
    }
    private void Roaming()
    {
        if ((roamingTurret.remainingDistance<=1)&&(checkPositions[0]==true))
        {
            roamingTurret.SetDestination(positionDeDeplacement[1].position);
            checkPositions[1] = true;
            checkPositions[0] = false;
        }
        else if ((roamingTurret.remainingDistance<=1)&&(checkPositions[1]==true))
        {
            roamingTurret.SetDestination(positionDeDeplacement[3].position);
            checkPositions[3] = true;
            checkPositions[1] = false;
        }
        else if ((roamingTurret.remainingDistance<=1)&&(checkPositions[3]==true))
        {
            roamingTurret.SetDestination(positionDeDeplacement[2].position);
            checkPositions[2] = true;
            checkPositions[3] = false;
        }else if ((roamingTurret.remainingDistance<=1)&&(checkPositions[2]==true))
        {
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
            roamingTurret.SetDestination(tankTransform.position);
        }
    }
}
