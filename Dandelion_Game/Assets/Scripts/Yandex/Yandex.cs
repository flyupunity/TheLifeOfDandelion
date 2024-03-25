using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;

[System.Serializable]
public enum AdType
{
    [InspectorName("Call from script")] script,
    [InspectorName("On Start")] start,
    [InspectorName("On Awake")] awake,
}
public class Yandex : MonoBehaviour
{
    [SerializeField] private AdType type;
    //[SerializeField] private bool showInAwake = true;
    [DllImport("__Internal")]
    private static extern void Hello();

    [DllImport("__Internal")]
    private static extern void ShowFullScreenYandexAd();
    [DllImport("__Internal")]
    private static extern void ShowFullScreenYandexAd_unlock();

    private void Awake()
    {
        if (type == AdType.awake && type != AdType.script)
        {
            ShowFullScreenYandexAd();
        }
    }
    private void Start()
    {
        if (type == AdType.start && type != AdType.script)
        {
            ShowFullScreenYandexAd();
        }
    }
    public void ShowFullScreenAd()
    {
        ShowFullScreenYandexAd();
    }
    public void ShowFullScreenAd_unlock()
    {
        ShowFullScreenYandexAd_unlock();
    }
}
