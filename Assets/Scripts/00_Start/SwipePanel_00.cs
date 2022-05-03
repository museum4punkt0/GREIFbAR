using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SwipePanel_00 : MonoBehaviour
{

    public Swipe_Control swipeControl;
    public GameObject panel1;
    public GameObject arContent;
    public TMP_Text header;
    private Vector3 desiredPosition;
    private Vector3 distanceButton;
    public int count = 0;
    private float speed = Screen.width * 2;
    private Color selColor = new Color(44.0f / 255.0f, 177.0f / 255.0f, 145.0f / 255.0f);
    private Color unselColor = new Color(1, 1, 1);
    public Image[] slides;

    void Start()
    {
        // Initialise the vector
        desiredPosition = panel1.transform.position; 
        distanceButton = new Vector3(Screen.width, 0.0f, 0.0f);
        panel1.transform.position = desiredPosition;

    }
    void Update()
    {
        //touch swipeControll
        if (swipeControl.SwipeL && count < slides.Length-1)
        {
            desiredPosition += Vector3.left * Screen.width;
            count++;
            for (int i = 0; i < slides.Length; i++)
            {
                if (i == count)
                {
                    slides[i].color = selColor;
                }
                else
                    slides[i].color = unselColor;
            }
        }
        if (swipeControl.SwipeR && count > 0)
        {
            desiredPosition += Vector3.right * Screen.width;
            count--;
            for (int i = 0; i < slides.Length; i++)
            {
                if (i == count)
                {
                    slides[i].color = selColor;
                }
                else
                    slides[i].color = unselColor;
            }
        }
        if(count == slides.Length-1){
            header.text = "Willkommen bei GREIFb<b>AR</b>";
            arContent.SetActive(true); 
        }
        else{
            header.text = "Was ist GREIFb<b>AR</b>?";
            arContent.SetActive(false); 
        }

        panel1.transform.position = Vector3.MoveTowards(panel1.transform.position, desiredPosition, speed * Time.deltaTime);
    }
}
