using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable, IKillable
{
   public int Health { get; set; }

    public void Damage()
    {
        Health--;
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

    public IEnumerator Die()
    {
        dying = true;
        animator.SetTrigger("Die");
        yield return new WaitForSecondsRealtime(0.1f);
        animator.SetBool("Dead", true);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            yield return null;
        }
        Destroy(transform.parent.gameObject);
    }

    //[Flags]
    //public enum ItemType
    //{
    //    Mocha = 1,
    //    Latte = 2,
    //    Cappuccino = 4,
    //    Bacon = 8,
    //    Muffin = 16,
    //    Croissant = 32
    //}

    // [SerializeField] private ItemType _itemType;

    /// <summary>
    /// Use for intialisation
    /// </summary>
    protected override void Initialise()
    {
        base.Initialise();
        Health = base.health;
    }
}
