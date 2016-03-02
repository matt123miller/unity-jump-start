using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class FadeInOut : MonoBehaviour
{

    [SerializeField]
    [TooltipAttribute("To begin immediately use 0")]
    private float fadeStartTime = 0, fadeMultiplier = 5, fadeProgress = 0;
    //public float ;
    //public float ;
    private Image image;
    private Text loadingText;
    private Slider loadingSlider;

    void Awake()
    {
        var temp = transform.GetChild(0);
        temp.gameObject.SetActive(true);

        image = temp.GetComponentInChildren<Image>();
        loadingText = transform.GetComponentInChildren<Text>();
        loadingSlider = transform.GetComponentInChildren<Slider>();

        ToggleLoadingUI(false);
    }


    void Start()
    {
        BeginFadeToClear();
    }

    private void ToggleLoadingUI(bool enabler)
    {
        loadingText.enabled = enabler;
        loadingSlider.gameObject.SetActive(enabler);
    }

    public void BeginFadeToBlack(bool fadeToClearFlag)
    {
        StartCoroutine(FadeToBlack(fadeStartTime + 1, fadeToClearFlag));
    }

    public void BeginFadeToClear()
    {
        StartCoroutine(FadeToClear(fadeStartTime + 1));
    }

    private IEnumerator FadeToClear(float fadeStartTime)
    {
        image.enabled = true;

        for (float f = fadeStartTime; f >= 0; f -= ((0.1f * fadeMultiplier) * Time.deltaTime))
        {

            fadeProgress = f;
            Color c = image.color;
            c.a = f;
            image.color = c;
            yield return null;
        }

        image.enabled = false;
    }

    private IEnumerator FadeToBlack(float fadeStartTime, bool fadeToClearFlag)
    {
        image.enabled = true;

        for (float f = 0f; f <= fadeStartTime; f += ((0.1f * fadeMultiplier) * Time.deltaTime))
        {
            fadeProgress = f;
            Color c = image.color;
            c.a = f;
            image.color = c;
            yield return null;
        }
        // Included in the unlikely event that scenes will fade to black only. 
        if (fadeToClearFlag)
        {
            BeginFadeToClear();
        }
        else
        {

        }
    }
    //void Start() {

    //    StartCoroutine(FadeToClear(fadeOverTime));
    //}


    //public static IEnumerator FadeToClear(float fadeOverTime)
    //{
    //    for (float f = fadeOverTime; f >= 0; f -= 0.01f) {

    //        Color c = image.color;
    //        c.a = f;
    //        image.color = c;
    //        yield return null;
    //    }
    //}   

    //public static IEnumerator FadeToBlack(float fadeOverTime)
    //{
    //    for (float f = 0f; f <= fadeOverTime; f += 0.01f) {

    //        Color c = image.color;
    //        c.a = f;
    //        image.color = c;
    //        yield return null;
    //    }
    //}   
}
