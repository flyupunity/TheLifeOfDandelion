#if UNITY_EDITOR
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;
using UnityEngine.SceneManagement;
using TMPro;

[CustomEditor(typeof(MyLevelsHelper))]
public class MyLevelsHelper_EditorClass : Editor
{
	public override void OnInspectorGUI()
	{
		base.OnInspectorGUI();
        MyLevelsHelper script = (MyLevelsHelper)target;
		
		if(GUILayout.Button("Fix button next"))
		{
			script.FixButtonNext();
		}
		if(GUILayout.Button("Disable Win objects"))
		{
			script.DisableWinObjects();
		}
		/*GUILayout.BeginHorizontal();
		GUILayout.EndHorizontal();*/
        //script.levelButtons[i].onClick.AddListener(() => GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneMan>().SceneName(name));
	}
}
#endif