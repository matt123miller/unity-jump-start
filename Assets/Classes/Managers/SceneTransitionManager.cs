using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/*
    This class is designed to manage all scene transitions in an asynchronous way.
    It nicely wraps all of the complexity and accessed via the singleton instance SceneTransitionManager.Instance
    
    This class belongs on a canvas with an Image child. That image should just be a large plain black texture.
    This black texture is then faded up and down to ease UX of transitions.
    Async loading should start once the texture fades in, then the desired level will load.
    The screen will remain black until async is finished at which point the texutre will fade out.
    
    The methods for fading the screen to or from black have been left public if, for some reason, 
    you want to fade the screen without changing the level.
    
    There is a loading bar and flashing loading text included as well, this is optional.
    If you do not wish to use these then remove the all the code concerning loadingText and loadingSlider.
    To turn these off and on call the ToggleLoadingUI(bool) method, passing it a boolean for whether you want them on (true) or off (false).
*/

public class SceneTransitionManager : MonoBehaviour
{

    private static SceneTransitionManager _instance;

    // Singleton object, access this via SceneTransitionManager.Instance whenever you need to call a scene transition method.
    public static SceneTransitionManager Instance
    {
        get
        {
            return _instance;
        }
    }


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
        _instance = this;

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
    
    // Assumes that the class calling the method knows which scene it wants to go to.
    public void LoadTargetLevel(int targetScene)
    {
        if (targetScene > SceneManager.sceneCountInBuildSettings)
        {
            // Handle this error however you like.
        }
        else 
        {
            StartCoroutine(AsyncLoadLevel(targetScene));
        }
    }
    
    // Will begin loading the next level in the build settings, assuming there are levels left to load.
    public void LoadNextLevel()
    {
        int targetScene = SceneManager.GetActiveScene().buildIndex + 1;
        
        if (targetScene > SceneManager.sceneCountInBuildSettings)
        {
            // Handle this error however you like.
        }
        else 
        {
            StartCoroutine(AsyncLoadLevel(targetScene));
        }
    }

    private IEnumerator AsyncLoadLevel(int targetScene)
    {
        BeginFadeToBlack(false);

        while (fadeProgress < 0.95)
        {
            yield return null;
        }
                
        ToggleLoadingUI(true);
        
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync(targetScene);

        while (!asyncLoad.isDone)
        {
            // Here you put your loading screen code.
            loadingSlider.value = asyncLoad.progress;
            loadingText.color = new Color(loadingText.color.r, loadingText.color.g, loadingText.color.b, Mathf.PingPong(Time.time, 1));

            yield return null;
        }
        
        // You don't need to turn the text and slider back off or call BeginFadeToClear() here as the old scene will now be destroyed.
        // The new scene that was just loaded asynchonously will replace it and should have a SceneManager object in it to handle fading etc.
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

}
