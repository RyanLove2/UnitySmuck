using System.Collections;
using System.Collections.Generic;
using UnityEngine.UIElements;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;
using System.Runtime.CompilerServices;


public class menu : MonoBehaviour
{
    // Start is called before the first frame update
    private Button start,exit;
    [SerializeField]
    private AssetBundle asset;
    private string[] pathnames;

    void Start()
    {
        
      
        var ui = GetComponent<UIDocument>();
        var rt = ui.rootVisualElement;
        
        start = rt.Q<Button>("btn_start");
        exit = rt.Q<Button>("btn_exit");

        start.clicked += OnStart;
        exit.clicked += OnExit;
      
      
    }

    void OnExit(){
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #else
            Application.Quit();
        #endif

    }

    void OnStart(){
       // Debug.Log("Start the Game Man!");
        SceneManager.LoadScene(1); // load from bundle index start button starts teh game
    
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
