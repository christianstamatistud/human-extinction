using System;
using UnityEngine;

namespace CS
{
    [Serializable]
    public class Item 
    {
        //define all the item types
        public enum ItemType
        {
            Note,
            Key,
            Light,
            Battery,
        }

        public ItemType itemType;
        public int amount;


        //-SET ITEM SPRITE
        public Sprite GetSprite()
        {
            switch (itemType)
            {
                default:
                case ItemType.Note: return ItemAssets.Instance.noteSprite;
                case ItemType.Key: return ItemAssets.Instance.keySprite;
                case ItemType.Light: return ItemAssets.Instance.glassSprite;
                case ItemType.Battery: return ItemAssets.Instance.batterySprite;

            }
        }


        public GameObject GetMesh()
        {
            switch (itemType)
            {
                default:
                case ItemType.Note: return ItemAssets.Instance.noteMesh;
                case ItemType.Key: return ItemAssets.Instance.keyMesh;
                case ItemType.Light: return ItemAssets.Instance.glassMesh;
                case ItemType.Battery: return ItemAssets.Instance.batteryMesh;

            }
        }

        public bool IsStackable()
        {
            switch (itemType)
            {
                default:
                case ItemType.Note:
                case ItemType.Key:
                case ItemType.Battery:
                    return true;
                case ItemType.Light:
                    return false;

            }
        }

    }

}
