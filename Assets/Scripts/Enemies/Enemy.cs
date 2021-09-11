using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Abstract class (specific enemies inherit from this)
/// </summary>
public class Enemy : MonoBehaviour
{
    [Header("Enemy Properties (Common)")]
    [SerializeField] protected int health;
    [SerializeField] protected int speed;
    protected int gems;

    public void Attack()
    {
        Debug.Log("My name is: " + this.gameObject.name);
    }
}
