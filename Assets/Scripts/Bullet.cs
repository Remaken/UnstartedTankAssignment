using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    public UnityEvent alert;


    private void OnCollisionEnter(Collision other)
    {
        if (other.gameObject.GetComponentInParent<Tank>())
        {
            Destroy(other.gameObject.GetComponentInParent<Tank>().gameObject);
        }

        if (other.gameObject.GetComponentInParent<Turret>())
        {
            alert.Invoke();
            Destroy(other.gameObject.GetComponentInParent<Turret>().gameObject);
        }
        Destroy(gameObject);
    }
}
