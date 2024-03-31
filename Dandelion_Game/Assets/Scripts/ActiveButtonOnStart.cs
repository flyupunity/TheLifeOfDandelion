using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveButtonOnStart : MonoBehaviour
{
    [SerializeField] private Animator[] buttons = null;
    void Start()
    {
        for (int i = 0; i < buttons.Length; i++)
        {
            buttons[i].Play("Wait");
            //buttons[i].SetTrigger("Normal");
        }
    }
}
