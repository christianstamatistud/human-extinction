using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using CodeMonkey.Utils;
using DG.Tweening;


namespace CS
{
    public class UI_Inventory : MonoBehaviour
    {
        private Inventory inventory;
        private Transform itemSlotContainer;
        private Transform itemSlotTemplate;

        public ItemDrop itemHolder;

        private void Awake()
        {
            itemSlotContainer = transform.Find("ItemSlotContainer");
            itemSlotTemplate = itemSlotContainer.Find("ItemSlotTemplate");

        }

        public void SetPlayer (ItemDrop player)
        {
            this.itemHolder = player;
        }

        //FUNCTION TO RECIEVE THE INVENTORY
        public void SetInventory (Inventory inventory)
        {
            this.inventory = inventory;

            inventory.OnItemListChanged += Inventory_OnItemListChanged;
            RefreshInventoryItems();
        }

        private void Inventory_OnItemListChanged(object sender, System.EventArgs e)
        {
            RefreshInventoryItems();
        }

        // CYCLE THROUGH ALL THE ITEMS SO WE NEED TO GO TO INVENTORY AND EXPOSE ITEMS
        private void RefreshInventoryItems()
        {
            //CLEAR INVENTORY BEFORE REFRESH
            foreach (Transform child in itemSlotContainer)
            {
                if (child == itemSlotTemplate) continue;
                Destroy(child.gameObject);
            }

            int x = 0;
            int y = 0;
            float itemSlotCellSize = 110f;

            foreach(Item item in inventory.GetItemList())
            {
                //INSTANTIATE SLOT TEMPLATE
                RectTransform itemSlotRectTransform = Instantiate(itemSlotTemplate, itemSlotContainer).GetComponent<RectTransform>();
                itemSlotRectTransform.gameObject.SetActive(true);

                itemSlotRectTransform.GetComponent<Button_UI>().ClickFunc = () =>
                {
                    // USE ITEM
                };

                itemSlotRectTransform.GetComponent<Button_UI>().MouseRightClickFunc = () =>
                {
                    // DROP ITEM
                    inventory.RemoveItem(item);
                    ItemWorld.DropItem(itemHolder.GetPosition(), item);
                };

                //LOCATE ITEM IN GRID ARRAY
                itemSlotRectTransform.anchoredPosition = new Vector2(x * itemSlotCellSize, y * itemSlotCellSize);
                //ASSIGN SPRITE
                Image image = itemSlotRectTransform.Find("image").GetComponent<Image>();
                image.sprite = item.GetSprite();
                TextMeshProUGUI uiText = itemSlotRectTransform.Find("text").GetComponent<TextMeshProUGUI>();
                if(item.amount > 1)
                {
                    uiText.SetText(item.amount.ToString());
                }
                else
                {
                    uiText.SetText("");
                }

                x++;
                if (x > 8)
                {
                    x = 0;
                    y--;
                }
            }

        }


        public void ToggleInventoryUi(Vector3 position)
        {
            transform.DOLocalMove(position, 0.3f);

        }

    }
}

