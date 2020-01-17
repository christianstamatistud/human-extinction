using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ItemSpawner : MonoBehaviour
    {
        public Item item;

        private void Start()
        {
            ItemWorld.SpawnItemWorld(transform.position, item);
            Destroy(gameObject);
        }
    }
}
