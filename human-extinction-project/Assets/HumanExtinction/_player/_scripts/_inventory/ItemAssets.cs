using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class ItemAssets : MonoBehaviour
    {
        //SINGLETON
        public static ItemAssets Instance { get; private set; }

        private void Awake()
        {
            Instance = this;
        }

        public Transform pfItemWorld;

        public Sprite noteSprite;
        public Sprite keySprite;
        public Sprite glassSprite;
        public Sprite batterySprite;

        public GameObject noteMesh;
        public GameObject keyMesh;
        public GameObject glassMesh;
        public GameObject batteryMesh;




    }

}

