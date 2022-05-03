using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using TMPro;

public class BTTN_Selected : MonoBehaviour, ISelectHandler, IDeselectHandler
{

       [SerializeField]
       private Image bttnImage;
       [SerializeField]
       private TMP_Text bttnText;

       // Updates Color of Buttons

       void Start()
       {
              GetComponent<Button>().onClick.AddListener(TaskOnClick);

              if(GetComponent<Button>().interactable==false)
              {
                     if(bttnImage!=null)
                            bttnImage.color  = new Color32(11,64,101,50);
                     if(bttnText!=null)
                            bttnText.color = new Color32(11,64,101,50);
              }
       }
       public void OnSelect(BaseEventData eventData)
       {
              if(bttnImage!=null)
                     bttnImage.color = new Color32(255,255,255,255);
              if(bttnText!=null)
                     bttnText.color = new Color32(255,255,255,255);

       }
       public void OnDeselect(BaseEventData eventData)
       {
              if(bttnImage!=null)
                     bttnImage.color  = new Color32(11,64,101,255);
              if(bttnText!=null)
                     bttnText.color = new Color32(11,64,101,255);
       }
       
	void TaskOnClick(){
              if(bttnImage!=null)
                     bttnImage.color  = new Color32(11,64,101,255);
              if(bttnText!=null)
                     bttnText.color = new Color32(11,64,101,255);
	}
}
