using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;
using UnityEngine.Events;

public class Bullet : MonoBehaviour
{
    /*public delegate void BulletHit();

    public static event BulletHit bulletHitted;*/
    private void OnCollisionEnter(Collision other)
    {/*
        bulletHitted?.Invoke();
        if (other.gameObject.GetComponentInParent<Tank>())
        {
            Destroy(other.gameObject.GetComponentInParent<Tank>().gameObject);
        }

        if (other.gameObject.GetComponentInParent<Turret>())
        {
            Destroy(other.gameObject.GetComponentInParent<Turret>().gameObject);
        }*/
      Destroy(gameObject);
    }
}
