using UnityEngine;
using System.Collections;

public class CheckPointManager : MonoBehaviour 
{
    void Start()
    {
        if(InventoryManager.position != Vector3.zero)
        {
            GameObject obj = GameObject.FindGameObjectWithTag("Player") as GameObject;
            obj.transform.position = InventoryManager.position;
            InventoryManager.instance.loadCheckPointsInventory();
        }
    }

    void OnTriggerEnter2D( Collider2D obj)
    {
        if(obj.name.Equals("CollisionsMove"))
        {
            InventoryManager.instance.startCheckPointsInventory();
            InventoryManager.position = obj.transform.parent.transform.position;
        }
    }

}
