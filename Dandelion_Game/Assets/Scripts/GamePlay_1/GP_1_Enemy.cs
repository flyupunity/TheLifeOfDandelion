using UnityEngine;
using UnityEngine.UI;

public class GP_1_Enemy : MonoBehaviour
{
	public float Speed;
	public float Force;
	public GameObject I;

	//private Rigidbody2D m_Rigidbody2D;

	private void Awake()
	{
		//m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}
	void FixedUpdate (){
		//m_Rigidbody2D.AddForce(new Vector2(1f * Speed, 0f));
		transform.position = Vector2.MoveTowards(transform.position, new Vector2(-25f, transform.position.y), Time.deltaTime * Speed);
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.tag == "Destroy"){ 
			Destroy(I);
		}
	}
}
