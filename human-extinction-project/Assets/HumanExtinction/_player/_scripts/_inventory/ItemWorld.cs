using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;


namespace CS
{
    public class ItemWorld : MonoBehaviour
    {

        // STATIC FUNCTION TO SPAWN ITEMS IN WORLD
        public static ItemWorld SpawnItemWorld(Vector3 position, Item item)
        {
            Transform transform = Instantiate(ItemAssets.Instance.pfItemWorld, position, Quaternion.identity);

            ItemWorld itemWorld = transform.GetComponent<ItemWorld>();
            itemWorld.SetItem(item);

            return itemWorld;
        }

        public static ItemWorld DropItem(Transform dropPosition, Item item)
        {

            var dir = dropPosition.transform.TransformDirection(Vector3.forward);
            ItemWorld itemWorld = SpawnItemWorld(dropPosition.position, item);
            itemWorld.GetComponent<Rigidbody>().AddForce(dir*2f, ForceMode.Impulse);
            return itemWorld;
        }


        private Item item;



        // WE ASK ITEM TO RETURN THE ITEM TYPE AND SPRITE
        public void SetItem(Item item)
        {
            this.item = item;
            Instantiate(item.GetMesh(), this.transform);
        }

        public Item GetItem()
        {
            return item;
        }

        public void DestroySelf()
        {
            Destroy(gameObject);
        }
    }
            
}

