
using UnityEngine;
using System.Collections;

public class BaseInventItem : IItem {


    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
        {
            coll.GetComponent<PlayerInventory>().InventoryItems.Add(this); //add own object name to player inventory
            Destroy(gameObject);
        }
    }
}
