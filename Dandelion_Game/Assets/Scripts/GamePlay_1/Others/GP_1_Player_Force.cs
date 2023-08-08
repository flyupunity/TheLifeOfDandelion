using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_1_Player_Force : MonoBehaviour
{
    private Rigidbody2D Rid;
    public Vector2 Vector;

    public float Force;
    public float Distance;

    public Vector2 Point1;
    public Vector2 Point2;

    public Vector2 ScreenPos1;
    public Vector2 ScreenPos2;

    void Awake()
    {
        Rid = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate(){
        if(Input.GetMouseButtonDown(0)){
            ButtonDown();
        }
	if(Input.GetMouseButton(0)){
            MouseButton();
        }
	if(Input.GetMouseButtonUp(0)){
            ButtonUp();
        }
    }
    public void ButtonDown(){
        ScreenPos1 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
        Point1 = Camera.main.ScreenToWorldPoint(ScreenPos1);
        //Point1 = ScreenPos1;
    }
    public void MouseButton(){
            ScreenPos2 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
            Point2 = Camera.main.ScreenToWorldPoint(ScreenPos2);
            //Point2 = ScreenPos2;
    }
    public void ButtonUp(){
            Vector = Point2 - Point1;
            Distance = Vector2.Distance(Point1, Point2);
            Rid.AddForce(Vector * Distance * Force);
            Point1 = new Vector2(0,0);
            Point2 = new Vector2(0,0);
    }
}











/*
float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * k_MouseSensitivityMultiplier;
float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * k_MouseSensitivityMultiplier;
Distance = new Vector2.Distantce(Point1 , Point2);
*/