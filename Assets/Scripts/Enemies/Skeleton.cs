using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skeleton : Enemy, IDamageable, IKillable
{
    public int Health { get; set; }

    public void Damage( )
    {
        Health--;
        if (Health < 1)
        {
            StartCoroutine(Die());
        }
        else
        {
            animator.SetTrigger("Hit");
            animator.SetBool("InCombat", true);
        }
    }

    public IEnumerator Die()
    {
        
        animator.SetTrigger("Die");
        yield return new WaitForSecondsRealtime(0.1f);
        animator.SetBool("Dead", true);
        while (animator.GetCurrentAnimatorStateInfo(0).IsName("Death"))
        {
            yield return null;
        }
        Destroy(transform.parent.gameObject);
    }

    /// <summary>
    /// Use for intialisation
    /// </summary>
    protected override void Initialise()
    {
        base.Initialise();
        Health = base.health;
    }
}
