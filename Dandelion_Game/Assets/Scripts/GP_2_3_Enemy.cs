using UnityEngine;
using UnityEngine.UI;

public class GP_2_3_Enemy : MonoBehaviour
{
	public float Speed;
	public Transform PlayerT;
	public GameObject I;

	public float HP;
	public float MaxHP;
	public Slider HPSlider;

	public int Types = 1;
	private Rigidbody2D m_Rigidbody2D;

	private void Awake()
	{
                HP = MaxHP;
		m_Rigidbody2D = GetComponent<Rigidbody2D>();
	}

	void FixedUpdate (){
		HPSlider.maxValue = MaxHP;
		HPSlider.value = HP;
		PlayerT = GameObject.FindGameObjectWithTag("Player").transform;
		if (HP <= 0)if(I != null) Destroy(I);

		//m_Rigidbody2D.AddRelativeForce(new Vector2(Speed, 0f));
		m_Rigidbody2D.AddRelativeForce((PlayerT.transform.position - transform.position * 0.1f) * Speed);
	}
        void OnMouseDown(){
            HP -= 1;
        }
}
