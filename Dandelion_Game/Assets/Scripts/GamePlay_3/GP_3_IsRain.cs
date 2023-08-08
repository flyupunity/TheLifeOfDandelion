using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class GP_3_IsRain : MonoBehaviour,IBeginDragHandler, IDragHandler, IEndDragHandler
{
    public GP_2_Player Player;
    public GameObject Rain;

    void Awake() 
    {
        Rain.SetActive(false);
        Rain.GetComponent<ParticleSystem>().Pause(true);
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        Rain.transform.localPosition = Vector2.zero;
        Player.It_is_not_Rain();
        Rain.SetActive(false);
        Rain.GetComponent<ParticleSystem>().Play(true);
    }
    public void OnDrag(PointerEventData eventData)
    {
        Vector2 ScreenPos1 = new Vector2(Input.mousePosition.x,  Input.mousePosition.y);
        Rain.transform.position = Camera.main.ScreenToWorldPoint(ScreenPos1);

        transform.position = Input.mousePosition;
        Player.It_is_Rain();
        Rain.SetActive(true);
        Rain.GetComponent<ParticleSystem>().Play(true);
    }
    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
        Rain.transform.localPosition = Vector2.zero; 
        Player.It_is_not_Rain();
        Rain.SetActive(false);
        Rain.GetComponent<ParticleSystem>().Pause(true);
    }
}
