using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ImageToggle : MonoBehaviour
{
    public Image image;
    public Image image2;
    private bool startAnim=true;
    float timer;
    public int stateToggle;
    public BTTN_Navigation nav;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Animation of the BackgroundImage
        if(stateToggle == nav.count)
        {
            Debug.Log(nav.count);
            timer += Time.deltaTime;
            if(timer>2 && startAnim){
                StartCoroutine(FadeImage(image, image2, false));
                startAnim=false;
            }
            if(timer >= 10){
                StartCoroutine(FadeImage(image, image2, true));
                startAnim=true;
                timer = 0;
            }
        }
        else
        {
            StopAllCoroutines();
        }

    }
    IEnumerator FadeImage(Image img,Image img2, bool fadeAway)
    {
        // fade from opaque to transparent
        if (fadeAway)
        {
            // loop over 1 second backwards
            for (float i = 1; i >= 0; i -= Time.deltaTime*3f)
            {
                // set color with i as alpha
                img2.color = new Color(1, 1, 1, i);
                yield return null;
            }
            // loop over 1 second
            for (float i = 1; i >= 0; i -= Time.deltaTime*3f)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
        // fade from transparent to opaque
        else
        {
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime)
            {
                // set color with i as alpha
                img.color = new Color(1, 1, 1, i);
                yield return null;
            }
            // loop over 1 second
            for (float i = 0; i <= 1; i += Time.deltaTime*0.5f)
            {
                // set color with i as alpha
                img2.color = new Color(1, 1, 1, i);
                yield return null;
            }
        }
    }
}
