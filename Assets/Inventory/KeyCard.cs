using UnityEngine;
using System.Collections;

public class KeyCard : IItem
{

    public enum KeyColour
    {
        Default,
        Blue,
        Green,
        Red,
        Yellow
    };

    public KeyColour keycolour;


    public KeyCard(KeyColour colourCode)
    {
        keycolour = colourCode;
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player")) {

            coll.GetComponent<PlayerInventory>().Keycards.Add(this);
            gameObject.GetComponent<MeshRenderer>().enabled = false;
            gameObject.GetComponent<BoxCollider>().enabled = false;
            gameObject.transform.position = coll.transform.position;
            gameObject.transform.parent = coll.transform;
            gameObject.GetComponent<MeshRenderer>().enabled = false;
        }

    }
}
