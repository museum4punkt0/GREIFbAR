using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

#if UNITY_EDITOR
using UnityEditor;
#endif

public class BTTN_Navigation : MonoBehaviour
{
    /* THIS SCRIPT IS USED FOR THE APP NAVIGATION
    It is used especially on the "NextBTTN" and "BackBTTN"
    It contains various navigation tools (change text, image, scene, etc.).
    The variable COUNT indicates at which position the action should be done.
    The SetNavigation array can contain multiple tasks: setNavigaiton[1] = 12  =>  change to Image[1] and Text[1]
    ----------------------------------------
    setNavigation[COUNT]: 1 = changeImage, 2 = changeText, 3 = changeScene, 4 = setGameobject, 5 = hideGameobject, 6 = SetCount
    ----------------------------------------

    */
    public int count = 0;
    
    public Image img;
    [SerializeField]
    private Sprite[] imgs = new Sprite[1];
    public TMP_Text text;
    [SerializeField]
    private string[] texts = new string[1];
    public int nextScene;
    public static int setCount;
    public GameObject[] setGameobj = new GameObject[1];
    public GameObject nextBTTN;
    public GameObject backBTTN;
    [SerializeField] int numStates=1;

    #region Editvars

    [SerializeField]
    bool bttnDisabled = false;

    [SerializeField]    
    bool[] imgBool = new bool[1] {false};
    
    [SerializeField]
    bool[] txtBool = new bool[1] {false};
    
    [SerializeField]
    bool[] objBool = new bool[1] {false};
    
    [SerializeField]
    bool[] scnBool = new bool[1] {false};
    #endregion
    
    // Start is called before the first frame update
    void Start(){
        if(setCount<=numStates-1&&setCount!=0){
            count = setCount;
            setCount=0;
            if(backBTTN!=null)
            backBTTN.SetActive(true);
            if(nextBTTN!=null)
            {
                if(count==numStates-1)
                nextBTTN.SetActive(false);
            }
        }
        SetNavigation();
    }

    public void SetNavigation()
    {
        if(imgBool[count]==true)
        {
            ChangeImg();
        }
        if(txtBool[count]==true)
        {
            ChangeTxt();
        }
        if(objBool[count]==true)
        {
            SetGamobject();
        }
        if(scnBool[count]==true)
        {
            ChangeScn();
        }
    }
    void ChangeImg()
    {
        img.sprite =imgs[count];
    }
    void ChangeTxt()
    {
        text.text = texts[count];
    }
    void SetGamobject() 
    {
        for(int i =0; i<numStates;i++){
            if(i!=count){
                if(setGameobj[i]!=null)
                {
                    setGameobj[i].SetActive(false);
                }
            }
        }
        if(setGameobj[count]!=null)
        {
            setGameobj[count].SetActive(true);
        }

    }
    void ChangeScn()  
    {
        SceneManager.LoadScene(nextScene);
    }
    // Sets the count for a different scene
    public void CloseScene(int i)
    {
        setCount = i;
    }
    public void MenuBTTN(int i)
    {
        count=i;
        SetNavigation();
    }
    public void NextBTTN()
    {
        count++;
        SetNavigation();
        if(backBTTN!=null)
            backBTTN.SetActive(true);
        if(count>=numStates-1){
            nextBTTN.SetActive(false);
        }
    }
    public void BackBTTN()
    {
        count--;
        SetNavigation();
        if(nextBTTN!=null)
            nextBTTN.SetActive(true);
        if(count<=0){
            backBTTN.SetActive(false);
        }
    }

#region EDITOR
#if UNITY_EDITOR
[CustomEditor(typeof(BTTN_Navigation))] 
    public class BTTN_NavigationEditor : Editor
{

    public override void OnInspectorGUI()
    {
        //base.OnInspectorGUI();
        

        BTTN_Navigation nav = (BTTN_Navigation)target;

        
        GUILayout.BeginHorizontal();
        GUILayout.Label("Current State: "+ nav.count);
        GUILayout.Label("Highest State: "+ (nav.numStates-1));
        GUILayout.EndHorizontal();

        GUILayout.Space(25);
        GUILayout.BeginHorizontal();
        GUILayout.Label("Bild");
        nav.img = (Image)EditorGUILayout.ObjectField(nav.img, typeof(Image), true);
        GUILayout.Label("Text");
        nav.text = (TMP_Text)EditorGUILayout.ObjectField(nav.text, typeof(TMP_Text), true);
        GUILayout.EndHorizontal();
        GUILayout.Space(25);
        GUILayout.BeginHorizontal();
        GUILayout.Label("NextButton");
        nav.nextBTTN = (GameObject)EditorGUILayout.ObjectField(nav.nextBTTN, typeof(GameObject), true);

        GUILayout.Label("BackButton");
        nav.backBTTN = (GameObject)EditorGUILayout.ObjectField(nav.backBTTN, typeof(GameObject), true);
        GUILayout.EndHorizontal();
        GUILayout.Space(25);

        GUILayout.BeginHorizontal();
        EditorGUI.BeginDisabledGroup(nav.bttnDisabled); 
        if(GUILayout.Button("+ scene state"))
        {
            if(nav.numStates<20)
            {
                nav.numStates++;
                Array.Resize(ref nav.imgBool, nav.imgBool.Length + 1);
                Array.Resize(ref nav.txtBool, nav.txtBool.Length + 1);
                Array.Resize(ref nav.objBool, nav.objBool.Length + 1);
                Array.Resize(ref nav.scnBool, nav.scnBool.Length + 1);

                Array.Resize(ref nav.imgs, nav.imgs.Length + 1);
                Array.Resize(ref nav.texts, nav.texts.Length + 1);
                Array.Resize(ref nav.setGameobj, nav.setGameobj.Length + 1);
            }
        }
        EditorGUI.EndDisabledGroup(); 
        if(GUILayout.Button("- scene state"))
        {
            if(nav.numStates-1>0){
            nav.numStates--;
            nav.txtBool[nav.numStates] = nav.imgBool[nav.numStates] = nav.scnBool[nav.numStates] = nav.objBool[nav.numStates] = false;
            Array.Resize(ref nav.imgBool, nav.imgBool.Length - 1);
            Array.Resize(ref nav.txtBool, nav.txtBool.Length - 1);
            Array.Resize(ref nav.objBool, nav.objBool.Length - 1);
            Array.Resize(ref nav.scnBool, nav.scnBool.Length - 1);


            Array.Resize(ref nav.imgs, nav.imgs.Length - 1);
            Array.Resize(ref nav.texts, nav.texts.Length - 1);
            Array.Resize(ref nav.setGameobj, nav.setGameobj.Length - 1);
            }
        }
        GUILayout.EndHorizontal();
        for(int i = 0; i<nav.numStates;i++){
            GUILayout.Label("State: "+i);
            GUILayout.BeginHorizontal();
            GUILayout.Label("Image "+i);
            nav.imgBool[i] = EditorGUILayout.Toggle(nav.imgBool[i],GUILayout.Width(10));
            GUILayout.Space(15);
            GUILayout.Label("Text "+i);
            nav.txtBool[i] = EditorGUILayout.Toggle(nav.txtBool[i],GUILayout.Width(10));
            GUILayout.Space(15);
            GUILayout.Label("Object "+i);
            nav.objBool[i] = EditorGUILayout.Toggle(nav.objBool[i],GUILayout.Width(10));
            GUILayout.Space(15);
            if(i==nav.numStates-1)
            {
                GUILayout.Label("Change Scene");
                nav.scnBool[i] = EditorGUILayout.Toggle(nav.scnBool[i],GUILayout.Width(10));
            }
            GUILayout.Space(15);
            GUILayout.EndHorizontal();
            
            GUILayout.BeginHorizontal();
            if(nav.scnBool[i]){
                nav.txtBool[i]=nav.objBool[i]=nav.imgBool[i] = false;
                nav.nextScene = EditorGUILayout.IntField(nav.nextScene);
                nav.bttnDisabled=true;
            }
            else{
                nav.bttnDisabled=false;
                }
            if(nav.imgBool[i]){
                nav.scnBool[i] = false;
                nav.imgs[i] = (Sprite)EditorGUILayout.ObjectField(nav.imgs[i], typeof(Sprite), true);
                GUILayout.Space(15);
                if(nav.imgBool[0])
                nav.img.sprite = nav.imgs[0];
            }
            
            if(nav.txtBool[i]){
                nav.scnBool[i] = false;
                nav.texts[i] = EditorGUILayout.TextField(nav.texts[i]);
                
                if(nav.txtBool[0])
                nav.text.text = nav.texts[0];

                GUILayout.Space(15);
            }
            if(nav.objBool[i]){
                nav.scnBool[i] = false;
                nav.setGameobj[i] = (GameObject)EditorGUILayout.ObjectField(nav.setGameobj[i], typeof(GameObject), true);
                GUILayout.Space(15);

            }
            GUILayout.Space(35);
            GUILayout.EndHorizontal();
            GUILayout.Space(20);
        }
        EditorUtility.SetDirty (nav);
    }
}
#endif
#endregion
}

