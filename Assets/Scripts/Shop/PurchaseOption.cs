using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VariableContainer;
using TMPro;

public class PurchaseOption : MonoBehaviour
{
    public Purchase_Option item;
    private ShopKeeper _shopkeeper;

    [SerializeField] private TextMeshProUGUI _itemText_Name;
    [SerializeField] private TextMeshProUGUI _itemText_Price;

    private void Start()
    {
        if (_shopkeeper == null)
        {
            _shopkeeper = FindObjectOfType<ShopKeeper>();
        }

        _itemText_Name.text = item.name;
        _itemText_Price.text = item.price + "G";
    }


    public void SelectItem()
    {
        _shopkeeper.SelectItem(item);
    }

}
