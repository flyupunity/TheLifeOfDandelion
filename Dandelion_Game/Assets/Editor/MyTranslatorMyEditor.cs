# if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[CustomEditor(typeof(MyTranslator))]
public class MyTranslatorMyEditor : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
        MyTranslator script = (MyTranslator)target;

		if(GUILayout.Button("Translate to Russian"))
		{
        	script.TranslateToRussian();
			/*foreach (GameObject russianText in GameObject.FindGameObjectsWithTag("Text_Russia"))
			{
				russianText.SetActive(true);
			}
			foreach (GameObject englishText in GameObject.FindGameObjectsWithTag("Text_English"))
			{
				englishText.SetActive(false);
			}*/

		}
		if(GUILayout.Button("Translate to English"))
		{
        	script.TranslateToEnglish();
			/*foreach (GameObject russianText in GameObject.FindGameObjectsWithTag("Text_Russia"))
			{
				russianText.SetActive(false);
			}
			foreach (GameObject englishText in GameObject.FindGameObjectsWithTag("Text_English"))
			{
				englishText.SetActive(true);
			}*/
		}
	}
}
//GUILayout.BeginHorizontal();
//GUILayout.EndHorizontal();
#endif