using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GP_1_Player_Windy : MonoBehaviour
{
    public GameObject AreaEffector;
    public Vector2 Vector;

    public float Force;
    public float Distance;
    //public Vector2[] Point;
    public Vector2 Point1;
    public Vector2 Point2;

    void Awake()
    {
        
    }

    void FixedUpdate()
    {
        if(Input.GetMouseButtonDown(0)){
            //Point = new Vector2[1];
            Vector2 ScreenPos1 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
            Point1 = Camera.main.ScreenToWorldPoint(ScreenPos1);
            print("Down" + ScreenPos1);
        }
        print("Down" + new Vector2(Input.mousePosition.x,  Input.mousePosition.y));
	if(Input.GetMouseButton(0)){
            //Point = new Vector2[2];
            Vector2 ScreenPos2 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
            Point2 = Camera.main.ScreenToWorldPoint(ScreenPos2);
        }
	if(Input.GetMouseButtonUp(0)){
            GameObject _areaEffectorObj = Instantiate(AreaEffector, Point1, Quaternion.identity) as GameObject;
 
            var dir = Input.mousePosition - Camera.main.ScreenToWorldPoint(_areaEffectorObj.transform.position);
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            _areaEffectorObj.transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
            //Destroy(_areaEffectorObj);
            //Point = null;
        }
    }
}
/*
Array.Clear(Array, int, int)
 = new Vector2[].
*/