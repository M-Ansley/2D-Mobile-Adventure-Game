using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class VariableContainer 
{
    [System.Serializable]
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
