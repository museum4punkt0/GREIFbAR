using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuBottom_00 : MonoBehaviour
{

    [SerializeField]
    private GameObject middlePanel;
    [SerializeField]
    private Button[] menuBTTNs;
    private Vector3 desiredPosition;
    private Vector3 distanceButton;
    private float speed = Screen.width * 5;
    static int countMenu;
    static int countVisit;
    // Start is called before the first frame update
    void Start()
    {
        //Sets menuposition at the start of the home scene
        desiredPosition = middlePanel.transform.position; 
        desiredPosition += Vector3.left * Screen.width*(countMenu);
        middlePanel.transform.position = desiredPosition; 
        menuBTTNs[countMenu].Select();
        PlayerPrefs.SetInt("CountVisit",1);
    }

    // Update is called once per frame
    void Update()
    {
        // swipe scene
        if(middlePanel.transform.position!=desiredPosition)
        {
            middlePanel.transform.position = Vector3.MoveTowards(middlePanel.transform.position, desiredPosition, speed * Time.deltaTime);
        }
    }
    public void SelectSection(int i)
    {
            desiredPosition += Vector3.left * Screen.width*(i-countMenu);
            countMenu=i;
    }
}
