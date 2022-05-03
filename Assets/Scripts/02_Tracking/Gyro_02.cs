using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Gyro_02 : MonoBehaviour
{
    public Image img;
    private Quaternion rot;
    private Quaternion rot1;
    private Quaternion rotNew;
    private Vector3 pos1;
    
    private float roll;
    // Start is called before the first frame update
    void Start()
    {
        if (SystemInfo.supportsGyroscope)
        {
            // init gyro
            Input.gyro.enabled = true;
            transform.rotation = Quaternion.Euler(90f, 90f, 0);
            rot = new Quaternion(0, 0, 1, 0);
            rot1= GyroToUnity(Input.gyro.attitude);
            pos1 = img.transform.position;          
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        if (SystemInfo.supportsGyroscope)
        {
            // just a vage animation with the gyro
            rotNew = GyroToUnity(Input.gyro.attitude);
            img.transform.rotation = Quaternion.Euler(0f,0f,(rot1.eulerAngles.z- rotNew.eulerAngles.z));
            img.transform.position = new Vector3(pos1.x-(rotNew.eulerAngles.y-rot1.eulerAngles.y)*2f,pos1.y+(rotNew.eulerAngles.x-rot1.eulerAngles.x)*3f,pos1.z);
        }
        else
        {
            
            img.transform.rotation = Quaternion.Euler(0f,0f,Camera.main.transform.rotation.y*150);
        }
        
    }
    
    private Quaternion GyroToUnity(Quaternion q)
    {
        //return new Quaternion(q.x, q.y, -q.z, -q.w);
        return new Quaternion(0.5f,0.5f,-0.5f,0.5f)*q*rot;
    }
}
