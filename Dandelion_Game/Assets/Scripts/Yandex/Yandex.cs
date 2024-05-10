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

    private void Awake()
    {
        if (type == AdType.awake && type != AdType.script)
        {
            StartCoroutine(ShowFullScreenYandexAdCoroutine());
        }
    }
    private void Start()
    {
        if (type == AdType.start && type != AdType.script)
        {
            StartCoroutine(ShowFullScreenYandexAdCoroutine());
        }
    }
    public void ShowFullScreenAd()
    {
        StartCoroutine(ShowFullScreenYandexAdCoroutine());
    }
    private IEnumerator ShowFullScreenYandexAdCoroutine()
    {
        GameObject windowObj = Instantiate(VariableValuePasser.Instance.prefabAdWarnings);
        yield return new WaitForSeconds(5);
        Destroy(windowObj);
        ShowFullScreenYandexAd();
    }
}
