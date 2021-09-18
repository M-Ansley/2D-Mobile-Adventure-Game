﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spider : Enemy, IDamageable
{

    public int Health { get; set; }

    public void Damage()
    {

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
