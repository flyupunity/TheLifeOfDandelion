using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Canvas))]
public class SetCanvasValume : MonoBehaviour
{
    [SerializeField] private Canvas canvas;

    private void OnValidate()
    {
        canvas = GetComponent<Canvas>();
        //if (canvas.renderMode == RenderMode.ScreenSpaceCamera)
        //{
            canvas.worldCamera = Camera.main/*GameObject.FindGameObjectWithTag("Camera for UI").GetComponent<Camera>()*/;
        //}
    }
}
