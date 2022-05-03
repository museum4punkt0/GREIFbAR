using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class NextBTTN_02 : MonoBehaviour
{
    public Image imgRight;
    public Image imgLeft;
    public TMP_Text textBottom;
    public GameObject Panel;
    public GameObject backBTTN;

    private int count = 0;

    [SerializeField]
    private string[] textsBottom;
    [SerializeField]
    private Sprite[] imgsRight;
    [SerializeField]
    private Sprite[] imgsLeft;

    // Update is called once per frame
    public void NextBTTN()
    {
        count++;
        if(count<textsBottom.Length){
            imgLeft.sprite =imgsLeft[count];
            imgRight.sprite =imgsRight[count];
            textBottom.text = textsBottom[count];
            backBTTN.SetActive(true);
        }
        else{
            Panel.SetActive(true);
            //GameObject.FindGameObjectWithTag("MainCanvas").GetComponent<SceneManger>().ChangeScene(3);
        }
    }
    public void BackBTTN(){
        
        if(count>0){
            count--;
            if(count==textsBottom.Length-1){
            Panel.SetActive(false);
            }
            else{
                imgLeft.sprite =imgsLeft[count];
                imgRight.sprite =imgsRight[count];
                textBottom.text = textsBottom[count];
                }
            if (count==0){
            backBTTN.SetActive(false);}
        }
    }
}
