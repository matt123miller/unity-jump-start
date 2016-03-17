
using System.Linq;
using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerInventory : IInventory
{
    [SerializeField]
    private List<IItem> inventoryItems = new List<IItem>();

    public List<IItem> InventoryItems
    {
        get { return inventoryItems; }
        set { inventoryItems = value; }
    }

    

    //public bool HasRequiredKeycard()
    //{
    //    for (int i = 0; i < keycards.Count - 1; i++)
    //    {
    //        var keycard = keycards[i];
    //        if (keycard.passcode == this.passcode)
    //        {
    //             = false;
    //        }
    //        return true;
    //    }
    //    return false;
    //}
}

