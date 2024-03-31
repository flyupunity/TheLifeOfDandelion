/*      System       */
using System.Collections;
using System.Collections.Generic;
/*      Unity       */
using UnityEngine;
using UnityEngine.UI;

public class LevelButton_ObjValue : MonoBehaviour
{
    [SerializeField] private GameObject lockImage;
    [SerializeField] private GameObject[] mainText;
    [SerializeField] private GameObject[] textComingSoon;

    public void AssignButtonLock()
    {
        lockImage.SetActive(true);
        GetComponent<Button>().interactable = false;

        for(int i = 0; i < mainText.Length; i++){mainText[i].SetActive(false);}
        for(int i = 0; i < textComingSoon.Length; i++){textComingSoon[i].SetActive(false);}
    }
    public void AssignButtonComingSoon()
    {
        lockImage.SetActive(false);
        GetComponent<Button>().interactable = false;

        for(int i = 0; i < mainText.Length; i++){mainText[i].SetActive(false);}
        for(int i = 0; i < textComingSoon.Length; i++){
            if(textComingSoon[i].name.Contains("_Russia"))textComingSoon[i].SetActive(true);
        }
    }
    public void AssignButtonActive()
    {
        if(!textComingSoon[0].activeSelf){ // это временное решение, пока я не добавил перевод
            lockImage.SetActive(false);
            GetComponent<Button>().interactable = true;

            for(int i = 0; i < mainText.Length; i++){
                if(mainText[i].name.Contains("_Russia"))mainText[i].SetActive(true);
                //if(mainText[i].name.Contains("_English"))mainText[i].SetActive(true);
            }
            for(int i = 0; i < textComingSoon.Length; i++){
                textComingSoon[i].SetActive(false);
            }

            //if(/*Progress.Instance.PlayerInfo.language == "ru" && */buttonChild.name != standartNameText+"_Russia") buttonChild.SetActive(false);
            //if(/*Progress.Instance.PlayerInfo.language == "en" && */buttonChild.name != standartNameText+"_English")
        }
    }
}
