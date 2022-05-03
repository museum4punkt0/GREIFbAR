using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManger : MonoBehaviour
{
    // Start is called before the first frame update
    public void ChangeScene(int i)
    {
        SceneManager.LoadScene(i);
    }

}
