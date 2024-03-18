using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// 인벤토리 : 아이템 추가 및 제거
public class Inventory : MonoBehaviour
{
    public event EventHandler OnItemListChanged;

    private List<Item> itemList;

    public Inventory()
    {
        itemList = new List<Item>();
        AddItem(new Item { itemType = Item.ItemType.PlayerItem, amount = 1 });
        AddItem(new Item { itemType = Item.ItemType.PlayerItem, amount = 1 });
        //AddItem(new Item { itemType = Item.ItemType.PlayerPlum, amount = 1 });
    }


    // 아이템 추가 함수
    public void AddItem(Item item)
    {
        // 아이템이 IsStackable이면
        if(item.IsStackable())
        {
            bool itemAlreadyInInventory = false; // 아이템이 이미 인벤토리에 있는지 체크
            // itemList 안에 있는 아이템 확인
            foreach(Item inventoryItem in itemList)
            {
                // 추가하려는 아이템이 인벤토리 내에 있으면
                if (inventoryItem.itemType == item.itemType) 
                {
                    inventoryItem.amount += item.amount;
                    itemAlreadyInInventory = true; 
                }
            }
            if(!itemAlreadyInInventory)
            {
                itemList.Add(item);
            }
        }
        else
        {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }


    // 아이템 제거 함수
    public void RemoveItem(Item item)
    {
        if (item.IsStackable())
        {
            Item itemInInventory = null;
            foreach (Item inventoryItem in itemList)
            {
                if (inventoryItem.itemType == item.itemType)
                {
                    inventoryItem.amount -= item.amount;
                    itemInInventory = inventoryItem;
                }
            }
            if (itemInInventory != null && itemInInventory.amount <= 0)
            {
                itemList.Remove(itemInInventory);
            }
        }
        else
        {
            itemList.Add(item);
        }

        OnItemListChanged?.Invoke(this, EventArgs.Empty);
    }
    
    
    //ItemList 반환
    public List<Item> GetItemList()
    {
        return itemList;
    }

    // PlayerPlum 아이템 존재하는지 확인 함수
    public bool IsPlayerItemExist()
    {
        int cnt = 0;
        foreach(Item item in itemList)
        {
            if (item.itemType == Item.ItemType.PlayerItem)
                cnt++;
        }
        if (cnt > 0)
            return true;
        else
            return false;
    }
}
