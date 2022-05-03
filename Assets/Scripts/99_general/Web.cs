  using UnityEngine;
  using System.Collections;
  
  public class Web : MonoBehaviour
  {
      public string url;
      public void OpenURL()
      {
          Application.OpenURL(url);
          Debug.Log("is this working?");
      }
  
  }