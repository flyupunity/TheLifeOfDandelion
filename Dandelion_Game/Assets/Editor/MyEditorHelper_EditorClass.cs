#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;
 
[CustomEditor(typeof(MyEditorHelper))]
public class MyEditorHelper_EditorClass : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
        MyEditorHelper script = (MyEditorHelper)target;

		if(GUILayout.Button("Assign a level buttons"))
		{
			script.levelButtons = new Button[script.gameObject.transform.childCount];
			for(int i = 0; i < script.gameObject.transform.childCount; i++)
			{
				script.levelButtons[i] = script.gameObject.transform.GetChild(i).gameObject.GetComponent<Button>();
			}
		}
		if(GUILayout.Button("Edit a text on level buttons"))
		{
			for(int i = 0; i < script.levelButtons.Length; i++)
			{
				string text = (i + 1).ToString();
				script.levelButtons[i].gameObject.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>().text = text;
			}
		}
		GUILayout.BeginHorizontal();
		if(GUILayout.Button("All active"))
		{
			for(int i = 0; i < script.levelButtons.Length; i++)
			{
				script.AssignButtonActive(script.levelButtons[i].gameObject);
			}
		}
		if(GUILayout.Button("All lock"))
		{
			for(int i = 0; i < script.levelButtons.Length; i++)
			{
				script.AssignButtonLock(script.levelButtons[i].gameObject);
			}
		}
		if(GUILayout.Button("All coming soon"))
		{
			for(int i = 0; i < script.levelButtons.Length; i++)
			{
				script.AssignButtonComingSoon(script.levelButtons[i].gameObject);
			}
		}
		GUILayout.EndHorizontal();



		GUILayout.BeginHorizontal();
		if(GUILayout.Button("Selection active"))
		{
        	foreach (GameObject button in Selection.gameObjects)
			{
				script.AssignButtonActive(button);
        	}
		}
		if(GUILayout.Button("Selection lock"))
		{
        	foreach (GameObject button in Selection.gameObjects)
			{
				script.AssignButtonLock(button);
        	}
		}
		if(GUILayout.Button("Selection coming soon"))
		{
        	foreach (GameObject button in Selection.gameObjects)
			{
				script.AssignButtonComingSoon(button);
        	}
		}
		GUILayout.EndHorizontal();

		/*if(GUILayout.Button("Assign a function in level buttons"))
		{
			script.AssignFunction();
        		for(int i = 0; i < script.levelButtons.Length; i++)
        		{
            			string name = script.levelNames + (i + 1).ToString();
            			script.levelButtons[i].onClick.AddListener(() => GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneMan>().SceneName(name));
        		}
		}*/
	}
}
#endif