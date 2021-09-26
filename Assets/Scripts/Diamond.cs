using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Diamond : MonoBehaviour
{
    private int _diamondVal = 1;

    public void SetDiamondValue(int newDiamondVal)
    {
        _diamondVal = newDiamondVal;
        SetScale(newDiamondVal);
    }

    private void SetScale(int newDiamondVal)
    {
        Vector3 currentScale = gameObject.transform.localScale;

        if (newDiamondVal >= 3 && newDiamondVal < 5)
        {
            gameObject.transform.localScale = currentScale * 1.25f;
        }
        else if (newDiamondVal >= 5)
        {
            gameObject.transform.localScale = currentScale * 1.5f;
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Player player = other.GetComponent<Player>();
            if (player != null)
            {
                CollectDiamond(player);
            }
        }
    }


    private void CollectDiamond(Player player)
    {
        player.Gems += _diamondVal;
        Destroy(gameObject);
    }
}
