using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class (specific enemies inherit from this)
/// </summary>
public abstract class Enemy : MonoBehaviour
{
    #region Variable_Declarations

    [Header("Enemy Properties (Common)")]
    [SerializeField] protected int health;
    [SerializeField] protected float speed = 2;
    [SerializeField] protected int gems;

    protected SpriteRenderer spriteRenderer;
    protected Animator animator;

    [SerializeField] protected Transform pointA, pointB;
    protected Transform targetPoint;

    protected bool dying, isHit;// inCombat;

    private static Player player;

    #endregion

    #region Setup

    private void Start()
    {
        Initialise(); // will in fact call the overridden version of this method in a child class
    }

   // protected abstract void MyMethod();

    protected virtual void Initialise()
    {
        if (player == null)
        {
            player = FindObjectOfType<Player>();
        }
        targetPoint = pointA;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Update

    public virtual void Update()
    {
        if (!animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            FlipSprite();
        }


        CheckWaypoints();
        if (!isHit && !dying && !animator.GetBool("InCombat"))
        {
            if (animator.GetCurrentAnimatorStateInfo(0).IsName("Walk"))
            {
                MoveToPoint();
            }
        }
        try
        {
            if (Vector3.Distance(this.gameObject.transform.position, player.transform.position) > 1)
            {
                isHit = false;
                // inCombat = false;
                animator.SetBool("InCombat", false);

            }
            else
            {
                if (animator.GetBool("InCombat"))
                {
                    FacePlayer();

                }
                //  inCombat = true;
                //  animator.SetBool("InCombat", true);
            }

        }
        catch
        {

        }
    }

    #endregion

    #region Attacks
    public virtual void Attack()
    {
        // Debug.Log("My name is: " + this.gameObject.name);
    }
    #endregion

    #region Movement_and_Movement_Visuals
    protected virtual void MoveToPoint()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    }

    protected virtual void CheckWaypoints()
    {
        if (transform.position == pointA.position)
        {
            targetPoint = pointB;
            animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            targetPoint = pointA;
            animator.SetTrigger("Idle");
        }
    }

    protected virtual void FlipSprite()
    {
        if (targetPoint == pointA)
        {
            spriteRenderer.flipX = true;
        }
        else
        {
            spriteRenderer.flipX = false;
        }
    }

    protected void FacePlayer()
    {
        try
        {
            Vector3 direction = player.transform.position - transform.position;
            if (direction.x > 0)
            {
                spriteRenderer.flipX = false;
            }
            else if (direction.x < 0)
            {
                spriteRenderer.flipX = true;
            }
        }
        catch (Exception e)
        {
            Debug.LogError("Exception in FacePlayer: " + e.Message);
        }
    }

    protected bool ShouldFaceRight(int i)
    {
        try
        {
            switch (i)
            {
                // In relation to player pos
                case 0:
                    Vector3 direction = player.transform.position - transform.position;
                    if (direction.x > 0)
                    {
                        return true;
                    }
                    else if (direction.x < 0)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;

                    // In regards to current direction
                case 1:
                    if (spriteRenderer.flipX)
                    {
                        return false;
                    }
                    else
                    {
                        return true;
                    }
                    break;
                default:
                    return false;
                    break;
            }
           
        }
        catch (Exception e)
        {
            Debug.LogError("Exception in ShouldFaceRight: " + e.Message);
            return true;
        }
    }

    #endregion

    #region Health

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

    #endregion

}
