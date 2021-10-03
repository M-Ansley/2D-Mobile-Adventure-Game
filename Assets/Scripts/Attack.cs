using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    [SerializeField] private int _damageAmount = 1;
    private bool _canDamage = true;

    private void OnTriggerEnter2D(Collider2D other)
    {

       // Debug.Log(other.name);

        IDamageable hit = other.GetComponent<IDamageable>();

        if (hit != null)
        {
            if (_canDamage)
            {
                hit.Damage(_damageAmount);
                StartCoroutine(ResetAttackRoutine());
            }
        }
    }

    IEnumerator ResetAttackRoutine()
    {
        _canDamage = false;
        yield return new WaitForSecondsRealtime(0.5f);
        _canDamage = true;
    }
}
