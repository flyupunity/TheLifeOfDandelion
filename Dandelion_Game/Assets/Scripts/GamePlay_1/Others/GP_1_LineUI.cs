using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GP_1_LineUI : MonoBehaviour
{
    public LineRenderer lr;
    public Vector2 Point1;
    public Vector2 Point2;
    //public GP_1_Player_Windy Player;
    public GP_1_Player_Force Player;

    void Awake() {
        lr = GetComponent<LineRenderer>();
    }

    void LateUpdate() {

	if(Input.GetMouseButtonDown(0)){
            lr.positionCount = 1;
            //Point1 = Player.Point[1];
            Point1 = Player.Point1;
            lr.SetPosition(0, Point1);
        }
        if(Input.GetMouseButton(0)){
            //Point2 = Player.Point[2];
            Point2 = Player.Point2;
            lr.positionCount = 2;
            lr.SetPosition(1, Point2);
        }
	if(Input.GetMouseButtonUp(0)){
            lr.positionCount = 0;
        }
    }
}
/*
if(Input.GetMouseButtonDown(1))
lr.positionCount = 0;
*/