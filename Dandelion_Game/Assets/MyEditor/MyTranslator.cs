using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MyTranslator : MonoBehaviour
{
	public string russiaTag = "Text_Russia";
	public string englishTag = "Text_English";

	public List<GameObject> objectsRussian = new List<GameObject>();
	public List<GameObject> objectsEnglish = new List<GameObject>();

	public void TranslateToRussian()
	{
		ActivateRussiaText(true);
		ActivateEnglishText(false);
	}
	public void TranslateToEnglish()
	{
		ActivateRussiaText(false);
		ActivateEnglishText(true);
	}
	public void ActivateRussiaText(bool value)
	{
		ListToGameObjectArray(russiaTag, objectsRussian);
		foreach (GameObject russianText in objectsRussian)//GameObject.FindGameObjectsWithTag("Text_Russia")
		{
			russianText.SetActive(value);
		}
	}
	public void ActivateEnglishText(bool value)
	{
		ListToGameObjectArray(englishTag, objectsEnglish);
		foreach (GameObject englishText in objectsEnglish)//GameObject.FindGameObjectsWithTag("Text_English")
		{
			englishText.SetActive(value);
		}
	}
	public void ListToGameObjectArray(string tag, List<GameObject> objectsWithTag)
	{
		//objectsWithTag = new List<GameObject>();
	    GameObject[] allObjects = GameObject.FindGameObjectsWithTag(tag);
        objectsWithTag.AddRange(allObjects);
	}
}
