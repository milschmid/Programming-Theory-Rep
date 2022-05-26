using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataTransfer : MonoBehaviour
{
    //Static Class for save the current player data
    //Singleton pattern
    public static DataTransfer Instance;

    public string prefab1Num = "0";
    public string prefab2Num = "0";

   private void Awake() {
        if(Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
        DontDestroyOnLoad(gameObject);
    }
}

