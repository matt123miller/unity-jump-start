using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class IInventory : MonoBehaviour
{
    /* I need to fix this so that players have a generic inventory and enemies only have keycards. Something like this:
    
    [SerializeField]
    private List<IItem> inventoryItems = new List<IItem>();

    public List<IItem> InventoryItems
    {
        get { return inventoryItems; }
        set { inventoryItems = value; }
    }

    Then validate in the enemy implementation to ensure only keycards can enter their inventory list.
    Or maybe change the collision handling, add it to IItem and call abstract methods implemented in children.
    */
    [SerializeField]
    private List<KeyCard> keycards = new List<KeyCard>();

    public List<KeyCard> Keycards
    {
        get { return keycards; }
        set { keycards = value; }
    }

    // Use this for initialization
    void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
