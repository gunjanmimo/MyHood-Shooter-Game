using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int damage = 5;
    private bool killed = false;
    public bool kill { get { return killed; } }
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<Bullet>() != null)
        {
            Bullet bullet = other.GetComponent<Bullet>();
            if (bullet.ShotByPlayer == true)
            {
                health -= bullet.damage;
                bullet.gameObject.SetActive(false);
                if (health <= 0)
                {
                    if (!killed)
                    {
                        killed = true;
                        onKill();
                    }
                }
            }
        }
    }
    protected virtual void onKill() { }
}
