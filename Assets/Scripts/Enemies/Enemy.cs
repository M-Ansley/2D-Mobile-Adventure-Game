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

    #endregion

    #region Setup

    private void Start()
    {
        Initialise(); // will in fact call the overridden version of this method in a child class
    }

    protected virtual void Initialise()
    {
        targetPoint = pointA;
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        animator = GetComponentInChildren<Animator>();
    }
    #endregion

    #region Update

    public virtual void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        FlipSprite();
        CheckWaypoints();
        MoveToPoint();
    }

    #endregion

    #region Attacks
    public virtual void Attack()
    {
        Debug.Log("My name is: " + this.gameObject.name);
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
    #endregion       
}
