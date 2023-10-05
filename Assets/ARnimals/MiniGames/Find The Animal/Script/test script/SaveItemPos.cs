using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveItemPos : MonoBehaviour
{
    [System.Serializable]
    public class ItemList
    {
        public List<Vector3> itemPos;
    }

    public List<ItemList> saveItemPos;

    [Space]
    [Header("Item")]
    public GameObject itemParent;
    public int saveNumber;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void savePos()
    {
        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            if (saveItemPos[saveNumber].itemPos.Count < itemParent.transform.childCount)
            {
               saveItemPos[saveNumber].itemPos.Add(itemParent.transform.GetChild(i).transform.localPosition);
            }
            else
            {
               saveItemPos[saveNumber].itemPos[i] = itemParent.transform.GetChild(i).transform.localPosition;
            }
        }
    }
}
