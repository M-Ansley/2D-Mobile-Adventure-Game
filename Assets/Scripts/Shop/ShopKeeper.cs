using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static VariableContainer;

public class ShopKeeper : MonoBehaviour
{
    private Player _player;

    private Item selectedItem; 

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

    public void SelectItem(Item item, int shopID)
    {
        selectedItem = item;
        // Debug.Log("You've selected: " + item.name);

        switch(shopID)
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
        if (_player.Gems >= selectedItem.value)
        {
            _player.Gems -= selectedItem.value;
            UpdatePlayerInventory(selectedItem);
            
            UIManager.Instance.UpdateGemsDisplay();
           // Debug.Log(string.Format("Purchased {0} for {1}G", selectedItem.name, selectedItem.price));
            UIManager.Instance.CloseShop();
        }
        else
        {
           // Debug.Log("Insufficient funds");
            UIManager.Instance.CloseShop();
        }
    }

    private void UpdatePlayerInventory(Item item)
    {
        if (_player._playerInventory.TryGetValue(item, out int quanitity))
        {
            _player._playerInventory[item] = ++quanitity; // needs a "pre-increment unary operator", not a post-increment one
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
