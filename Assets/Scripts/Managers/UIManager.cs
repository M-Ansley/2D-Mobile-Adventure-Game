using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameEvents;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    [Header("Variable Declarations")]
    [SerializeField] private GameObject _shopUIGameObject;
    [SerializeField] private Image _shopSelectionImage;
    [SerializeField] private TextMeshProUGUI _playerGemsText;

    [SerializeField] private TextMeshProUGUI _gemsText;
    private Player _player;

    [SerializeField] private List<GameObject> _healthUnits;

    private static UIManager _instance;
    public static UIManager Instance
    {
        get
        {
            if (_instance == null)
            {
                Debug.LogError("UIManager is null");
                return null;
            }
            return _instance;
        }
    }

    private void Awake()
    {
        _instance = this;
    }

    // Start is called before the first frame update
    void Start()
    {
        SubscribeToEvents();
        FindObjects();
        GemsCollected(_player.Gems);
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
            if (numberOfGems > 0)
            {
                _gemsText.text = Mathf.Clamp(_player.Gems, 0, 999).ToString();
            }
            else
            {
                _gemsText.text = "";
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("An exception occurred in UIManager.GemsCollected: " + e.Message);
        }
    }


    public void OpenShop(int playerGems = 0)
    {
        if (_shopUIGameObject != null)
        {
            _shopUIGameObject.SetActive(true);
            _playerGemsText.text = Mathf.Clamp(_player.Gems, 0, 999) + "G";

            Debug.Log(string.Format("Player has {0} gems", playerGems));
        }
    }

    public void CloseShop()
    {
        if (_shopUIGameObject != null)
        {
            _shopUIGameObject.SetActive(false);
        }
    }


    public void UpdateShopSelection(float yPos)
    {
        _shopSelectionImage.rectTransform.anchoredPosition = new Vector2(_shopSelectionImage.rectTransform.anchoredPosition.x, yPos);

    }

    public void UpdateGemsDisplay()
    {
        if (_player.Gems > 0)
        {
            _gemsText.text = Mathf.Clamp(_player.Gems, 0, 999).ToString();
        }
        else
        {
            _gemsText.text = string.Empty;
        }

        _playerGemsText.text = Mathf.Clamp(_player.Gems, 0, 999) + "G";
    }


    public void UpdateHealthDisplay()
    {
        try
        {
            RemoveNullUnits();
            while (_healthUnits.Count < _player.Health)
            {
                GameObject previousUnit = _healthUnits[_healthUnits.Count - 1];
                GameObject newUnit = Instantiate(previousUnit, previousUnit.transform.parent);
                _healthUnits.Add(newUnit);
            }

            for (int i = 0; i < _healthUnits.Count; i++)
            {
                if (i < _player.Health)
                {
                    _healthUnits[i].SetActive(true);
                }
                else
                {
                    _healthUnits[i].SetActive(false);
                }
            }
        }
        catch (System.Exception e)
        {
            Debug.LogError("Exception in UIManager.UpdateHealthDisplay: " + e.Message);

        }

    }

    private void RemoveNullUnits()
    {
        try
        {
            bool nullUnitsRemoved = false;
            int index = 0;
            while (!nullUnitsRemoved)
            {
                if (_healthUnits[index] != null) // if it's fine, proceed.
                {
                    index++;
                }
                else // if it's null remove it and stay on the same index
                {
                    _healthUnits.Remove(_healthUnits[index]);
                }

                if (index == _healthUnits.Count) // if 
                {
                    nullUnitsRemoved = true;
                }
            }
        }
        catch
        {

        }
    }


}
