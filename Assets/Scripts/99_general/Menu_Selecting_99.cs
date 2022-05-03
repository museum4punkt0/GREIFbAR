using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Menu_Selecting_99 : MonoBehaviour
{
    [SerializeField]
    private GameObject[] descripts;
    [SerializeField]
    private GameObject descriptEmpty;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    public void SelectBTTN(int bttnSelected)
    {
        for(int i =0; i<descripts.Length;i++)
        {
            if(i==bttnSelected)
            descripts[i].SetActive(true);
            else
            descripts[i].SetActive(false);
        }
        descriptEmpty.SetActive(false);
    }
    public void  DeselectBTTN(GameObject description)
    {
        descriptEmpty.SetActive(true);
        description.SetActive(false);
    }
}
