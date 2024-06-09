using System.Collections;
using System.Linq;
using UnityEngine;

public class GP_3_BeeCreator : MonoBehaviour
{

	public GameObject Bee1;
	public Transform Point;

	[Space(15)]


    #region Time

	[Header("Time")][Space(10)]
    public float Timer = 0;
	public float MaxTimer = 30;
    [Range(0f, 15f)] public float Scatter = 5;

    #endregion

    private void Awake()
    {
		StartCoroutine(RandomTimerRange());
	}

    private void Update()
	{
		if(Timer > 0) Timer -= Time.deltaTime;
		if(Timer <= 0){
			GameObject newBee1 = Instantiate(Bee1, Point.position, transform.rotation);
            StartCoroutine(RandomTimerRange());
        }
	}
	IEnumerator RandomTimerRange()
	{
        Timer = MaxTimer + Random.Range(-Scatter, Scatter);
        yield return null;
	}
}
