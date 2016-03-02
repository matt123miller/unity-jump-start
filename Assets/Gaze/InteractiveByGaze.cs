using UnityEngine;
using System.Collections;

public class InteractiveByGaze : MonoBehaviour
{

    [Header("InteractiveByGaze variables")]
    public bool observed = false;
    private Material shaderMaterial;

    
    public float lineGlowMax = 0.03f, lineGlowMin = 0;
    // Use this for initialization
    void Start()
    {
        shaderMaterial = GetComponent<MeshRenderer>().material;
    }


    public void Interact(RaycastHit hit)
    {
	    Debug.Log("interacted with"); 
        if (!observed)
        {
            observed = true;
            shaderMaterial.SetFloat("_Outline", lineGlowMax);
        }

        InteractiveBehaviour(hit);
    }


    protected virtual void InteractiveBehaviour(RaycastHit hit)
    {
        Debug.Log("Interacted with");
    }

    public virtual void Reset()
    {
        Debug.Log("Reset");
        observed = false;
        shaderMaterial.SetFloat("_Outline", lineGlowMin);
    }
}
