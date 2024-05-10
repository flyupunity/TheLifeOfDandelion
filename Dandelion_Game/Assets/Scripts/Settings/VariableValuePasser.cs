using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VariableValuePasser : MonoBehaviour
{
    public GameObject prefabAdWarnings = null;
    public static VariableValuePasser Instance;

    void Awake()
    {
        if(Instance == null){    
            transform.parent = null;
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }else{
            Destroy(gameObject);
        }
    }
}