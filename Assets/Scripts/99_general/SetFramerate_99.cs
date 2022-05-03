    using UnityEngine;
    public class SetFramerate_99 : MonoBehaviour
    {
         //Locks framerate at 30 fps
         private void Awake()
         {
              Application.targetFrameRate = 30;
         }
    }