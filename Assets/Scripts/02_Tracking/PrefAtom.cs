using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrefAtom : MonoBehaviour
{
    public GameObject electron01;
    public GameObject electron02;
    public GameObject electron03;
    public GameObject atom;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Animation Atom
        electron01.transform.Rotate(new Vector3(0f,0f,200f)*Time.deltaTime);
        electron02.transform.Rotate(new Vector3(0f,0f,200f)*Time.deltaTime);
        electron03.transform.Rotate(new Vector3(0f,0f,200f)*Time.deltaTime);
        atom.transform.Rotate(new Vector3(0f,0f,20f)*Time.deltaTime);
    }
}
