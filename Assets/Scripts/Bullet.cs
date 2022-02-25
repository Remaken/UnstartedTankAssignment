using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentInParent<Tank>())
        {
            Destroy(other.gameObject.GetComponentInParent<Tank>().gameObject);
        }

        if (other.gameObject.GetComponentInParent<Turret>())
        {
            Destroy(other.gameObject.GetComponentInParent<Turret>().gameObject);
        }
        Destroy(gameObject);
    }
}
