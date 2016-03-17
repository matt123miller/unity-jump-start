using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class EnemyInventory : IInventory
{
    
    public KeyCard.KeyColour keyColour;

   
    // Use this for initialization
    void Start()
    {
        Keycards.Add(new KeyCard(keyColour));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
