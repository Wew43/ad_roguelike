using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventorySortOrder : SortOrder
{
    public override void MoveChilds(int index)
    {
        for (int i = 1; i < transform.childCount; i++)
        {
            for (int j = 0; j < transform.GetChild(i).childCount; j++)
            {
                transform.GetChild(i).GetChild(j).GetComponent<SpriteRenderer>().sortingOrder = 1 + 100 * index;
            }
        }
    }
}
