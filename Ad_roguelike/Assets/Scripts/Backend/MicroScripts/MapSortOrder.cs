using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapSortOrder : SortOrder
{
    public override void MoveChilds(int index) 
    {
        var Map = transform.GetChild(1);

        for (int i = 0; i < Map.childCount; i++)
        {
            if (Map.transform.GetChild(i).gameObject.CompareTag("Room"))
            {
                for (int k = 0; k < Map.transform.GetChild(i).childCount - 1; k++)
                {
                    Map.transform.GetChild(i).GetChild(k).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 1 + 100 * index;
                }
                Map.transform.GetChild(i).GetChild(Map.transform.GetChild(i).childCount - 1).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 3 + 100 * index;
            }
            else if (Map.transform.GetChild(i).gameObject.CompareTag("Corridor"))
            {
                for (int k = 0; k < Map.transform.GetChild(i).childCount; k++)
                {
                    Map.transform.GetChild(i).GetChild(k).gameObject.GetComponent<SpriteRenderer>().sortingOrder = 2 + 100 * index;
                }
            }
        }

        transform.GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = 4 + 100 * index;
        transform.GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = 5 + 100 * index;
        transform.GetChild(4).GetChild(0).GetComponent<SpriteRenderer>().sortingOrder = 6 + 100 * index;
        transform.GetChild(4).GetChild(1).GetComponent<SpriteRenderer>().sortingOrder = 6 + 100 * index;
        transform.GetChild(4).GetChild(2).GetComponent<SpriteRenderer>().sortingOrder = 6 + 100 * index;
        transform.GetChild(4).GetChild(3).GetComponent<SpriteRenderer>().sortingOrder = 6 + 100 * index;
    }
}
