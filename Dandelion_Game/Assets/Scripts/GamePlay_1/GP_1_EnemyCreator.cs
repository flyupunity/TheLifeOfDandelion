using UnityEngine;

public class GP_1_EnemyCreator : MonoBehaviour
{
	public GameObject Enemy1;
	public float Timer1;
	public float MaxTimer1;

	private int i;
	private float f;
	public Sprite[] Sprite;

	public Transform[] Point;
	public GameObject[] Obj;
	[SerializeField] private BoxCollider2D[] _allColliders;

	void Awake()
	{
		//MySprite = GetComponent<SpriteRenderer>();
	}
	void Update()
	{
		if(Timer1 > 0) Timer1 -= 1f * Time.deltaTime;

		if(Timer1 <= 0){
			f = Random.Range(Point[0].position.y,Point[1].position.y);
			GameObject newEnemy1 = Instantiate(Enemy1,new Vector2(Point[0].position.x, f), transform.rotation);

			float o = Random.Range(0.01f,(float)Sprite.Length - 0.01f);
			i = (int)o;

			newEnemy1.GetComponent<SpriteRenderer>().sprite = Sprite[i];
			Timer1 = MaxTimer1;
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
