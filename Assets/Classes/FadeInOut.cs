using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public  class FadeInOut : MonoBehaviour
{

    public static Image image;
    public float fadeOverTime;
    
    void Awake()
    {
        image = GetComponent<Image>();
        image.enabled = true;
    }
    
    void Start() {
        
        StartCoroutine(FadeToClear(fadeOverTime));
    }
    

    public static IEnumerator FadeToClear(float fadeOverTime)
    {
        for (float f = fadeOverTime; f >= 0; f -= 0.01f) {
            
            Color c = image.color;
            c.a = f;
            image.color = c;
            yield return null;
        }
    }   
    
    public static IEnumerator FadeToBlack(float fadeOverTime)
    {
        for (float f = 0f; f <= fadeOverTime; f += 0.01f) {
            
            Color c = image.color;
            c.a = f;
            image.color = c;
            yield return null;
        }
    }   
}
