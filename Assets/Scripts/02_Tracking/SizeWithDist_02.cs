using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SizeWithDist_02 : MonoBehaviour
{
    public OwnLocation ownLoc;
    public IsVisible isVis;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ownLoc.dist > 150) 
        {
            transform.localScale = new Vector3(ownLoc.dist / 150, ownLoc.dist / 150, ownLoc.dist / 150);
        }
        if (ownLoc.dist < 10)
        {
            isVis.enabled = false;
        }
        else
        {
            isVis.enabled = true;
        }
    }
}
