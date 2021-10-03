using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableContainer 
{
    [System.Serializable]
    public struct Purchase_Option
    {
        public int shopId;
        public ItemType itemType;
        public int price;
        public string name;

        public Purchase_Option(int myShopId, ItemType myItemType, int myPrice, string myName)
        {
            shopId = myShopId;
            itemType = myItemType;
            price = myPrice;
            name = myName;
        }
    }

    public struct Item
    {
        public ItemType itemType;
        public int value;
        public string name;

        public Item(ItemType myItemType, int myValue, string myName)
        {
            itemType = myItemType;
            value = myValue;
            name = myName;
        }
    }


    public enum ItemType
    {
        FlameSword = 10,
        BootsOfFlight = 11,
        KeyToCastle = 12
    }
  
}
