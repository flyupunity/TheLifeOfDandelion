using UnityEngine;

public class GP_2_3_EnemyCreator : MonoBehaviour
{
	public Transform PlayerT;
	public Transform[] Point;

	public GameObject Enemy1;
	public GameObject Enemy2;

	public float Timer1;
	public float Timer2;

	public float MaxTimer1;
	public float MaxTimer2;

	private int i;
	private int y;

	private float f;
	private float u;

	public GameObject[] Obj;
	[SerializeField] private BoxCollider2D[] _allColliders;

	void Update()
	{
		if(Timer1 > 0) Timer1 -= 1f * Time.deltaTime;
		if(Timer2 > 0) Timer2 -= 1f * Time.deltaTime;

		if(Timer1 <= 0){
			f = Random.Range(0.01f,1.99f);
			i = (int)f;

			float o = Random.Range(2.01f,4.99f);
			int p = (int)o;
			for (int h = 0; h < p; h++) {
				GameObject newEnemy1 = Instantiate(Enemy1,Point[i].position, Point[i].rotation);
			}
			Timer1 = MaxTimer1;
		}
		if(Timer2 <= 0){
			u = Random.Range(0.01f,1.99f);
			y = (int)u;

			float l = Random.Range(1.01f,2.99f);
			int k = (int)l;
			for (int j = 0; j < k; j++) {
				GameObject newEnemy2 = Instantiate(Enemy2, Point[y].position, Point[y].rotation);
			}
			Timer2 = MaxTimer2;
		}
		/*Obj = GameObject.FindGameObjectsWithTag("Enemy");
		_allColliders = new BoxCollider2D[Obj.Length];
                for (int w = 0; w < Obj.Length; w++) {
			_allColliders[w] = Obj[w].GetComponent<BoxCollider2D>();
		}
                if(_allColliders.Length >= 2){
			for (int a = 0; a < _allColliders.Length; a++) {
				for (int b = 0; b < _allColliders.Length; b++) {
					Physics2D.IgnoreCollision(_allColliders[a], _allColliders[b], true);
				}
			}
		}*/
	}
}
