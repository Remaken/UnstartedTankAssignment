using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Tank : BaseController
{
    [SerializeField] private float _movespeed;
    [SerializeField] private float _rotatepeed;
    private bool canCheat = false;
    private bool canCheatTwo = false;
    [SerializeField] private GameObject _murs;
    void Update()
    {
        TankFire();
        RotateHeadTowardDirection();
        CheatCode();
    }

    private void FixedUpdate()
    {
        MoveTank();
    }

    private void MoveTank()
    {
     
        this.transform.Translate(0f,0f,Input.GetAxis("Vertical")*_movespeed * Time.fixedDeltaTime);
       this.transform.Rotate(new Vector3(0f, Input.GetAxis("Horizontal")*_movespeed*10f*Time.fixedDeltaTime, 0f));

        /*if (Input.GetKey(KeyCode.Z))
        {
            this.transform.Translate(new Vector3(0, 0, _movespeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.S))
        {
            this.transform.Translate(new Vector3(0, 0, -_movespeed * Time.deltaTime));
        }
        if (Input.GetKey(KeyCode.Q))
        {
            this.transform.Rotate(Vector3.up,-_rotatepeed*Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Rotate(Vector3.up,_rotatepeed*Time.deltaTime);
        }*/
    }

    public void GetMousePosition()
    {
        RaycastHit hitmouse;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray ,out hitmouse))
        {
            headTransform.LookAt(new Vector3(hitmouse.point.x, headTransform.position.y, hitmouse.point.z));
        }
        //TODO: Follow Mouse Mouvement
    }

    private void TankFire()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            StartCoroutine(Fire());
        }
        
    }

    private void CheatCode()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetKey(KeyCode.Space))
                {
                    canCheat = true;
                }
            }
        }
        
        if (Input.GetKey(KeyCode.L)&&canCheat==true)
        {
            canCheatTwo = true;
        }
        if (Input.GetKey(KeyCode.Return)&&canCheatTwo==true)
        {
            _murs.SetActive(false);
            canCheat = false;
            canCheatTwo = false;
        }
    }
}
