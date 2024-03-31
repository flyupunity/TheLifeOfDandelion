using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyLevelsHelper : MonoBehaviour
{
    public void FixButtonNext()
    {
        print(GetPath(GameObject.Find("Next").transform));
        GameObject button = GameObject.Find(/*gameObject.scene.name+"/Canvas/Win/NexPanel/Button/*/"Next");
        button.GetComponent<Button>().onClick.AddListener(() =>  
                    GameObject.FindGameObjectWithTag("Manager").GetComponent<SceneMan>().
                    SceneName("Level" + (int.Parse(gameObject.scene.name.Substring(("Level").Length) + 1))));
    }
    public void DisableWinObjects()
    {
        //GameObject.Find("NextPanel").SetActive(false);
        GameObject.Find("Win").SetActive(false);
    }
    /*public void Update()
    {
        
    }*/
    public string GetPath(Transform transform)
    {
        string path = "/" + transform.name;
        while (transform.parent != null)
        {
            transform = transform.parent;
            path = "/" + transform.name + path;
        }
        return path;
    }
}
