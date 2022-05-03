using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PrefabImage : MonoBehaviour
{
    // Start is called before the first frame update
    public SpriteRenderer image;
    public Sprite[] sprites;

    public TMP_Text textBottom;
    [SerializeField]
    private string[] textsBottom;
    private int count=0;
    void Start()
    {
    
    }
    public void NextBTTN()
    {
        count++;
        image.sprite = sprites[count];
        textBottom.text = textsBottom[count];

    }
    public void SetIMG(int i)
    {
        count=i;
        image.sprite = sprites[count];
    }
}
