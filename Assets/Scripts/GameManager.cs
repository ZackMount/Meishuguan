using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject player;
    void Start()
    {
        BrushManager.ShowDrawTools(false);
        DontDestroyOnLoad(this);
    }
    void Update()
    {
        
    }
    public static void ChangeScene(string name)
    {
        VRControllerListener.SceneChanged(name);
        SceneManager.LoadScene(name);
    }
}
