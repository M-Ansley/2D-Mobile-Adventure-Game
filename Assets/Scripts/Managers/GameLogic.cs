using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameLogic : MonoBehaviour
{
    private static GameLogic _instance;
    public static GameLogic Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogWarning("GameLogic Instance is null");
                return null;
            }

            return _instance;
        }
    }

    public bool HasKeyToCastle { get; set; }

    private void Awake()
    {
        _instance = this;
    }

}
