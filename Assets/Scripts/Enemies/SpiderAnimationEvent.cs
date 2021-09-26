using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderAnimationEvent : MonoBehaviour
{
    private Spider _spider;

    private void Start()
    {
        try
        {
            _spider = gameObject.transform.parent.gameObject.GetComponent<Spider>();
        }
        catch (Exception e)
        {
            Debug.LogError("An exception occurred in SpiderAnimationEvent.Start: " + e.Message);
        }
    }

    public void Fire()
    {
        _spider.Fire();
    }
}
