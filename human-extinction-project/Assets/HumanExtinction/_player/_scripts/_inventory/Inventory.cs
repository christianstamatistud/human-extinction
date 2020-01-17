using System;
using System.Collections.Generic;
using UnityEngine;
namespace CS
{
    public class Inventory
    {
        //ADD ITEM TO LIST
        public event EventHandler OnItemListChanged;
        //DEFINE ITEM TYPE
        public List<Item> itemList;


        //CONSTRUCTOR
        public Inventory()
        {
            //INITIALIZE THE LIST
            itemList = new List<Item>();

            Debug.Log(itemList.Count);
        }


        //FUNCTION FOR ADDING ITEMS
        public void AddItem(Item item)
        {
            //CHECK IF WE HAVE THE SAME ITEM TYPE
            if (item.IsStackable())
            {
                bool itemAlreadyInInventory = false;
                foreach (Item inventoryItem in itemList)
                {
                    if(inventoryItem.itemType == item.itemType)
                    {
                        inventoryItem.amount += item.amount;
                        itemAlreadyInInventory = true;
                    }
                }

                if (!itemAlreadyInInventory)
                {
                    itemList.Add(item);
                }
            }
            else
            {
                itemList.Add(item);
            }
            OnItemListChanged?.Invoke(this,EventArgs.Empty);
        }


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
                itemList.Remove(item);
            }
            OnItemListChanged?.Invoke(this, EventArgs.Empty);

        }

        //EXPOSE ALL ITEMS
        public List<Item> GetItemList()
        {
            return itemList;
        }

    }

}

