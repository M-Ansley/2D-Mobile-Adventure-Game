using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class (specific enemies inherit from this)
/// </summary>
public abstract class Enemy : MonoBehaviour
{
    [Header("Enemy Properties (Common)")]
    [SerializeField] protected int health;
    [SerializeField] protected float speed = 2;
    [SerializeField] protected int gems;

    [SerializeField] protected Transform pointA, pointB;
    protected Transform targetPoint;

    public virtual void Attack()
    {
        Debug.Log("My name is: " + this.gameObject.name);
    }

    public abstract void Update(); // initialise it like this; no implementation code. Forces us to have unique implementations
    
    #region Movement
    protected virtual void MoveToPoint()
    {
        float step = speed * Time.deltaTime;
        transform.position = Vector3.MoveTowards(transform.position, targetPoint.position, step);
    }


    #endregion
}
