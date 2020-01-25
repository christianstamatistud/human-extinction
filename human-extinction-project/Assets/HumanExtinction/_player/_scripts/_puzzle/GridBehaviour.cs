using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace CS
{
    public class GridBehaviour : MonoBehaviour
    {
        public int rows = 10;
        public int columns = 10;
        public int scale = 1;
        public GameObject gridPrefab;
        public Vector3 leftoBottomLocation = new Vector3(0, 0, 0);



        private void Awake()
        {

            if (gridPrefab)
                GenerateGrid();
            else print("missing grid prefab");
        }

        // Update is called once per frame
        void Update()
        {

        }

        void GenerateGrid()
        {
            for (int i = 0; i < columns; i++)
            {
                for (int j = 0; j < rows; j++)
                {
                    GameObject obj = Instantiate(gridPrefab, new Vector3(leftoBottomLocation.x + scale * i, leftoBottomLocation.y, leftoBottomLocation.z + scale * j), Quaternion.Euler(new Vector3(0,-90,0)));
                    obj.transform.SetParent(gameObject.transform);
                    obj.GetComponent<GridStat>().x = i;
                    obj.GetComponent<GridStat>().y = j;
                }
            }
        }

   
    
    }

        
    }


