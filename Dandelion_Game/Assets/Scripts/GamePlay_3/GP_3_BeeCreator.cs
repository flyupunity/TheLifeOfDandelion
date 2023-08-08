using UnityEngine;

public class GP_3_BeeCreator : MonoBehaviour
{
	public Transform PlayerT;
	public GameObject Bee1;
	public Transform Point;

	public int i = 1;
	public float Timer1;
	public float MaxTimer1;

	void FixedUpdate()
	{
		if(Timer1 > 0) Timer1 --;
		if(Timer1 <= 0){
			GameObject newBee1 = Instantiate(Bee1, Point.position, transform.rotation);
			Timer1 = MaxTimer1 * 50;
		}
	}
}
