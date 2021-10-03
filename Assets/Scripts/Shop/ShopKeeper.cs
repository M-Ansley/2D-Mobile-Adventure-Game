using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VariableContainer;

public class ShopKeeper : MonoBehaviour
{
    private Player _player;

    private Purchase_Option selectedItem; 

    private void Start()
    {
        UIManager.Instance.CloseShop();
        _player = FindObjectOfType<Player>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.OpenShop(_player.Gems);
            UIManager.Instance.UpdateShopSelection(-29);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            UIManager.Instance.CloseShop();
        }
    }

    public void SelectItem(Purchase_Option item)
    {
        selectedItem = item;
        Debug.Log("You've selected: " + item.name);

        switch(selectedItem.shopId)
        {
            case 0: // top-most item
                UIManager.Instance.UpdateShopSelection(-29);
                break;
            case 1: // second item down
                UIManager.Instance.UpdateShopSelection(-64);
                break;
            case 2: // third item down
                UIManager.Instance.UpdateShopSelection(-97);
                break;
            default:
                Debug.LogWarning("Case not recognised. Are you sure an ID's been set for this item?");
                break;
        }
    }

    /// <summary>
    /// Buys the selected item when the player presses the purchase/buy button.
    /// </summary>
    public void AttemptPurchase()
    {
        if (_player.Gems >= selectedItem.price)
        {
            _player.Gems -= selectedItem.price;
            UpdatePlayerInventory(new Item(selectedItem.itemType, selectedItem.price, selectedItem.name));
            
            UIManager.Instance.UpdateGemsDisplay();
            Debug.Log(string.Format("Purchased {0} for {1}G", selectedItem.name, selectedItem.price));
            UIManager.Instance.CloseShop();
        }
        else
        {
            Debug.Log("Insufficient funds");
            UIManager.Instance.CloseShop();
        }
    }

    private void UpdatePlayerInventory(Item item)
    {
        int quanitity;
        if (_player._playerInventory.TryGetValue(item, out quanitity))
        {
            _player._playerInventory[item] = quanitity + 1;
        }
        else
        {
            _player._playerInventory.Add(item, 1);
        }


        if (item.itemType == ItemType.KeyToCastle) 
        {
            GameLogic.Instance.HasKeyToCastle = true;
        }
    }


}
