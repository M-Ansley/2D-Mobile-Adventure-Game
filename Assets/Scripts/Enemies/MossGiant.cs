using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MossGiant : Enemy
{
    private void Start()
    {
        targetPoint = pointA;
        Initialise();
    }

    public override void Update()
    {
        if (animator.GetCurrentAnimatorStateInfo(0).IsName("Idle"))
        {
            return;
        }

        FlipSprite();
        CheckWaypoints();
        MoveToPoint();
    } 


}
