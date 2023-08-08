using UnityEngine;
using UnityEngine.SceneManagement;

public class Replay : MonoBehaviour
{
	public void Game()
	{
		int IntScene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(IntScene);
	}
}
