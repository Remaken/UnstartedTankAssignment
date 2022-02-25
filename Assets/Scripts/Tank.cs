using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tank : BaseController
{
    [SerializeField] private float _movespeed;
    [SerializeField] private float _rotatepeed;
    void Start()
    {
        
    }
    void Update()
    {
        GetMouseClick();
        RotateHeadTowardDirection();
        MoveTank();
    }

    private void MoveTank()
    {
        
        if (Input.GetKey(KeyCode.Z))
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
        }
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

    private void GetMouseClick()
    {
        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
        }
        
    }
}
