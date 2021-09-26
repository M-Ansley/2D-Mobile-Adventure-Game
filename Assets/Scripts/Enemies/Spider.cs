using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{

    public int Health { get; set; }

    [SerializeField] private GameObject _acidGameObject;

    public override void Update()
    {
        
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
            // animator.SetBool("InCombat", true);
        }
    }

    /// <summary>
    /// Use for intialisation
    /// </summary>
    protected override void Initialise()
    {
        base.Initialise();
        Health = base.health;
        StartCoroutine(AttackForTime(Random.Range(2f, 4f)));
    }


    private IEnumerator AttackForTime(float time)
    {
        yield return new WaitForSecondsRealtime(time);
        animator.SetBool("Attacking", true);
        yield return new WaitForSecondsRealtime(time);
        animator.SetBool("Attacking", false);
        StartCoroutine(AttackForTime(Random.Range(2f, 6f)));
    }


    public void Fire()
    {
        try
        {
            GameObject acid = Instantiate(_acidGameObject, ReturnAcidPositionOffset(), Quaternion.identity);
            AcidProjectile acidScript = acid.GetComponent<AcidProjectile>();
            if (ShouldFaceRight(1))
            {
                acidScript.Begin(Vector3.right, 3, 3);                

            }
            else
            {
                acidScript.Begin(Vector3.left, 3, 3);
            }

        }
        catch (System.Exception e)
        {
            Debug.LogError("An exception occurred in Spider.Fire: " + e.Message);
        }


    }

    private Vector3 ReturnAcidPositionOffset()
    {
        if (ShouldFaceRight(1))
        {
            return new Vector3(transform.position.x + 0.15f, transform.position.y, transform.position.z);
        }
        else
        {
            return new Vector3(transform.position.x - 0.15f, transform.position.y, transform.position.z);
        }
    }
}
