using UnityEngine;
using System.Collections;

public class GazeBase : MonoBehaviour {

    [Header("GazeBase variables")]

    public float rayDistance;
    public int frameCounter, frameTarget;
    public GameObject[] crosshairs; 
    protected Transform crosshairOriginalTransform; // Might be useful later, might move into another relevant class if needs be.
    
	// Use this for initialization
	void Start () {

        crosshairOriginalTransform = transform;
	}
	
	// Update is called once per frame
	void LateUpdate () {
        
        if (frameCounter++ >= frameTarget){
            
            frameCounter = 0;
	        RaycastHit hit;
        
            if (Physics.Raycast (transform.position, transform.forward, out hit, rayDistance)) {
            
                Gaze(hit);
            }
        }
        
        CrosshairBehaviour();
	}
    
    public void ResetCrosshairs(){
        
        crosshairs[0].SetActive(false);
        crosshairs[1].SetActive(false);
        // crosshairGO = crosshairOriginalTransform;
    }
    
        public virtual void Gaze(RaycastHit hit) {}
        
        public virtual void CrosshairBehaviour(){}
        
        
}
