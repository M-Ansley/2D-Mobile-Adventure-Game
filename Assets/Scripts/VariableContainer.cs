using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableContainer 
{
    [System.Serializable]
    public struct Purchase_Option
    {
        public int shopId;
        public int itemID;
        public int price;
        public string name;

        public Purchase_Option(int myShopId, int myItemId, int myPrice, string myName)
        {
            shopId = myShopId;
            itemID = myItemId;
            price = myPrice;
            name = myName;
        }
    }

    public struct Item
    {
        public int id;
        public int value;
        public string name;

        public Item(int myID, int myValue, string myName)
        {
            id = myID;
            value = myValue;
            name = myName;
        }
    }
  
}
