using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class NextBTTN_01 : MonoBehaviour
{
    public TMP_Text textBottom;
    [SerializeField]
    private string[] textsBottom;

    private int count = 0;
    public void NextBTTN()
    {
        count++;
        // HARD CODED
        textBottom.text = textsBottom[count];
        // IF LOCALIZED IS USED!!
        /*
        mylocalizedstringevent = textBottom.GetComponent<LocalizeStringEvent>();
        Debug.Log(mylocalizedstringevent);
        mylocalizedstringevent.StringReference.TableEntryReference = textsBottom[count];*/
    }
}