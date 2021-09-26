using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvents;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _gemsText;
    private Player _player;

    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
        FindObjects();
    }

    private void SubscribeToEvents()
    {
        GameEvents.current.gemsCollected.AddListener(GemsCollected);
    }

    private void FindObjects()
    {
        _player = FindObjectOfType<Player>();
    }

   private void GemsCollected(int numberOfGems)
    {
        try
        {
            _gemsText.text = _player.Gems.ToString();
        }
        catch (System.Exception e)
        {
            Debug.LogError("An exception occurred in UIManager.GemsCollected: " + e.Message);
        }
    }
}
