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
    [SerializeField] protected int speed;
    [SerializeField] protected int gems;

    public virtual void Attack()
    {
        Debug.Log("My name is: " + this.gameObject.name);
    }

    public abstract void Update(); // initialise it like this; no implementation code. Forces us to have unique implementations
}
