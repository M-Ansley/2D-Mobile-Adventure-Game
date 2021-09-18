using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {

        Debug.Log(other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_canDamage)
            {
                hit.Damage();
                StartCoroutine(ResetJumpRoutine());
            }
        }
    }

    IEnumerator ResetJumpRoutine()
    {
        _canDamage = false;
        yield return new WaitForSecondsRealtime(0.5f);
        _canDamage = true;
    }
}
