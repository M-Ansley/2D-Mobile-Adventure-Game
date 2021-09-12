using System.Collections;
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
        FlipSprite(false);
    }

    public override void Update()
    {
        if (_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }
        CheckWaypoints();
        MoveToPoint();

    }

    private void CheckWaypoints()
    {
        if (transform.position == pointA.position)
        {
            targetPoint = pointB;
            _animator.SetTrigger("Idle");
            StartCoroutine(FlipSpriteCoroutine(true));
        }
        else if (transform.position == pointB.position)
        {
            targetPoint = pointA;
            _animator.SetTrigger("Idle");
            StartCoroutine(FlipSpriteCoroutine(false));
        }
    }

    private IEnumerator FlipSpriteCoroutine(bool leftToRight)
    {
        yield return new WaitForSecondsRealtime(1.3f);
        // yield return !_animator.GetCurrentAnimatorStateInfo(0).IsName("Idle");
        FlipSprite(leftToRight);


    }

    private void FlipSprite (bool leftToRight)
    {
        Vector3 currentSpriteGameObjectScale = _spriteGameObject.transform.localScale;

        if (leftToRight)
        {
            currentSpriteGameObjectScale.x = 1;
            _spriteGameObject.transform.localScale = currentSpriteGameObjectScale;
        }
        else
        {
            currentSpriteGameObjectScale.x = -1;
            _spriteGameObject.transform.localScale = currentSpriteGameObjectScale;
        }
    }
}
