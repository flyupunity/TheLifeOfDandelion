using UnityEngine;

public class Pause : MonoBehaviour
{
	public void PauseScale(float Scale)
	{
		Time.timeScale = Scale;
	}
}
