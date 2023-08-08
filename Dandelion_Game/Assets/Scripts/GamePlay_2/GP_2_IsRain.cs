using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GP_2_IsRain : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GP_2_Player Player;
    public GameObject Rain;
    private GameObject newRain;

    void Start() 
    {
        //Rain.SetActive(false);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Vector2 ScreenPos1 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
        Vector2 position = Camera.main.ScreenToWorldPoint(ScreenPos1);
        newRain = Instantiate(Rain, position, transform.rotation);

        transform.localPosition = Vector2.zero;
        //Rain.transform.localPosition = Vector2.zero;
        Player.It_is_not_Rain();
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 ScreenPos1 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
        Vector2 Screen = Camera.main.ScreenToWorldPoint(ScreenPos1);
        newRain.transform.position = new Vector3(Screen.x, Screen.y, 1f);

        transform.position = Input.mousePosition;
        Player.It_is_Rain();

    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        //Rain.transform.localPosition = new Vector2(0,0); 
        Player.It_is_not_Rain();
        if(newRain != null)
            Destroy(newRain);
    }
}
