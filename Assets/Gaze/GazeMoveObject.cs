using UnityEngine;
using System.Collections;

public class GazeMoveObject : GazeBase {


    [Header("GazeMoveObject variables")]
    public GameObject objectToMove;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	public override void Gaze(RaycastHit hit) {
        
        objectToMove.transform.position = hit.point;
        Debug.Log("hit.transform.position is " + hit.point);
    }
   
}
