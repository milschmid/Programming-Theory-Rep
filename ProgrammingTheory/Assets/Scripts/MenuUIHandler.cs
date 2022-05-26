using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
#if UNITY_EDITOR
using UnityEditor;
#endif

// Sets the script to be executed later than all default scripts
// This is helpful for UI, since other things may need to be initialized before setting the UI
[DefaultExecutionOrder(1000)]

public class MenuUIHandler : MonoBehaviour
{
    //This is the handler of the main menu scene

    [SerializeField] Text prefab1Number;
    [SerializeField] Text prefab2Number;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    
    public void StartGame() {
        SetPrefabNumbers();
        SceneManager.LoadScene(1);
    }

    public void SetPrefabNumbers() {
        DataTransfer.Instance.prefab1Num = prefab1Number.text;
        DataTransfer.Instance.prefab2Num = prefab2Number.text;
    }

    public void ExitGame() {
#if UNITY_EDITOR
        EditorApplication.ExitPlaymode();
#else
        Application.Quit();
#endif
    } 
}
