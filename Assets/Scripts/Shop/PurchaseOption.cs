﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VariableContainer;
using TMPro;

public class PurchaseOption : MonoBehaviour
{
    [SerializeField] private ShopKeeper _shopkeeper;

    [SerializeField] private TextMeshProUGUI _itemText_Name;
    [SerializeField] private TextMeshProUGUI _itemText_Price;

    [Tooltip("If true, sends this item to the shop keeper as the default item to purchase")]
    [SerializeField] private bool _defaultItem = false;

    [SerializeField] private int _shopID = 0;

    [Header("Item Setup")]
    public Item item;

    private void Start()
    {
        if (_shopkeeper == null)
        {
            _shopkeeper = FindObjectOfType<ShopKeeper>();

        }

        _itemText_Name.text = item.name;
        _itemText_Price.text = item.value + "G";

        if (_defaultItem)
        {
            SelectItem();
        }
    }

    public void SelectItem()
    {
        _shopkeeper.SelectItem(item, _shopID);
    }
}