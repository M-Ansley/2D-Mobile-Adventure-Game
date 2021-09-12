﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private GameObject _spriteGameObject;
    private Animator _animator;

    private void Start()
    {
        targetPoint = pointA;
        _spriteGameObject = GetComponentInChildren<SpriteRenderer>().gameObject;
        _animator = _spriteGameObject.GetComponent<Animator>();
    }

    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        FlipSprite();
        CheckWaypoints();
        MoveToPoint();

    }

    private void FlipSprite()
    {
        if (targetPoint == pointA)
        {
            _spriteGameObject.GetComponent<SpriteRenderer>().flipX = true;
        }
        else
        {
            _spriteGameObject.GetComponent<SpriteRenderer>().flipX = false;
        }
    }

    private void CheckWaypoints()
    {
        if (transform.position == pointA.position)
        {
            targetPoint = pointB;
            _animator.SetTrigger("Idle");
        }
        else if (transform.position == pointB.position)
        {
            targetPoint = pointA;
            _animator.SetTrigger("Idle");
        }
    }


}
