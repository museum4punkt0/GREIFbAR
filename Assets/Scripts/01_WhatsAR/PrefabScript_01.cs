using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PrefabScript_01 : MonoBehaviour
{
    public GameObject[] setPrefabs; 
    public Text textARType;
    private string[] textsARType = new string[5];

    void Start(){
        textsARType[0] = "Reality";
        textsARType[1] = "Augmented Reality";
        textsARType[2] = "mehr Augmented Reality";
        textsARType[3] = "Augmented Virtuality";
        textsARType[4] = "Virtual Reality";
    }
    public void Slider(float arInteger){

        //Sets different prefabs
        for(int i=0;i<setPrefabs.Length;i++){
            if(i<arInteger)
            setPrefabs[i].SetActive(true);
            else
            setPrefabs[i].SetActive(false);
        }
        textARType.text = textsARType[(int)arInteger];
        Debug.Log(textsARType[(int)arInteger]);
    }

}
