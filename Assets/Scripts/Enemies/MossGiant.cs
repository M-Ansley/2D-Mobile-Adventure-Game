using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy, IDamageable
{
   public int Health { get; set; }

    public void Damage()
    {

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
