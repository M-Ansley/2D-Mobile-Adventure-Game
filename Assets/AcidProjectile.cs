using System.Collections;
using UnityEngine;

public class AcidProjectile : MonoBehaviour
{

    public void Begin(Vector3 moveDirection, float lifetime = 3, float speed = 2)
    {
        StartCoroutine(Move(moveDirection, lifetime, speed));
    }

    private IEnumerator Move(Vector3 moveDirection, float lifetime = 3, float speed = 2)
    {
        float timeRemaining = lifetime;

        while (timeRemaining > 0)
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);
            timeRemaining -= Time.deltaTime;
            yield return null;
        }
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            IDamageable hit = other.GetComponent<IDamageable>();
            if (hit != null)
            {
                hit.Damage();
                Destroy(gameObject);
            }
        }
    }
}
