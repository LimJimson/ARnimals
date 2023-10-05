using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlHiddenObject : MonoBehaviour
{
    public GameObject itemParent;
    public SaveItemPos saveItemPos;

    void Start()
    {
        RandomItemPos();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void RandomItemPos()
    {
        int randomSave = Random.Range(0, saveItemPos.saveItemPos.Count);

        for (int i = 0; i < itemParent.transform.childCount; i++)
        {
            itemParent.transform.GetChild(i).transform.localPosition = saveItemPos.saveItemPos[randomSave].itemPos[i];
        }
    }
}
