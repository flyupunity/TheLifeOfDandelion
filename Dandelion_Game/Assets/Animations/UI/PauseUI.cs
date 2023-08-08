using UnityEngine;

public class PauseUI : MonoBehaviour
{
	public float Scale;
	void Start()
	{
		Time.timeScale = 0f;
	}
	public void PauseScale()
	{
		Time.timeScale = Scale;
	}
}
