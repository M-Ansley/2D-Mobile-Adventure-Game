using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class GameEvents : MonoBehaviour
{
    public static GameEvents current;

    private void Awake()
    {
        current = this;
    }

   [System.Serializable]
   public class MyIntEvent : UnityEvent<int>
    {

    }
        

    public MyIntEvent gemsCollected;

    public void GemsCollected(int numberOfGems)
    {
        if (gemsCollected != null)
        {
            gemsCollected.Invoke(numberOfGems);
        }
    }

}
