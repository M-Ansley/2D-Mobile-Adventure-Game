using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable, IKillable
{
   public int Health { get; set; }

    /// <summary>
    /// Use for intialisation
    /// </summary>
    protected override void Initialise()
    {
        base.Initialise();
        Health = base.health;
    }


    public void Damage(int damageAmount = 1)
    {
        Health -= damageAmount;
        if (Health < 1)
        {
            StartCoroutine(Die());
        }
        else
        {
            isHit = true;
            animator.SetTrigger("Hit");
            animator.SetBool("InCombat", true);
        }
    }



}
