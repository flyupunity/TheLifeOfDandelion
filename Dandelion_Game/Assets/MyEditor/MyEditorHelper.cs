using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyEditorHelper : MonoBehaviour
{
    public string levelNames = "Level";
    public Button[] levelButtons;
	void Start()
	{
		AssignFunction();
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if(Progress.Instance.PlayerInfo.maxLevelIndex[i] == true){
                levelButtons[i].gameObject.GetComponent<LevelButton_ObjValue>().AssignButtonActive();
            }else{
                levelButtons[i].gameObject.GetComponent<LevelButton_ObjValue>().AssignButtonLock();
            }
        }
	}

    public void AssignFunction()
    {
        for(int i = 0; i < levelButtons.Length; i++)
        {
            string name = levelNames + (i + 1).ToString();
            levelButtons[i].onClick.AddListener(() => GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneMan>().SceneName(name));
        }
    }
    public void AssignButtonActive(GameObject button)
    {
        button.GetComponent<LevelButton_ObjValue>().AssignButtonActive();
    }
    public void AssignButtonLock(GameObject button)
    {
        button.GetComponent<LevelButton_ObjValue>().AssignButtonLock();
    }
    public void AssignButtonComingSoon(GameObject button)
    {
        button.GetComponent<LevelButton_ObjValue>().AssignButtonComingSoon();
    }
}
