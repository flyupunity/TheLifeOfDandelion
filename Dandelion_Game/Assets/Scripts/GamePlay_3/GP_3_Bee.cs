using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GP_3_Bee : MonoBehaviour
{
	public float Speed;
	public GameObject I_am;
	public int i;

	public GP_3_Player PlayerSpript;
	public Transform PlayerTransform;
	public Transform[] Points;

	public bool Rain = false;
	public bool IsW;

	public float w;
	public Slider WSlider;
	public TextMeshProUGUI Text;

	private void Awake()
	{
                PlayerSpript = GameObject.FindGameObjectWithTag("Player").GetComponent<GP_3_Player>();
		Rain = false;
		IsW = false;
	}

	void Update ()
        {
		WSlider.value = -w;
		if (i >= Points.Length) Destroy(I_am);
		PlayerTransform = GameObject.FindGameObjectWithTag("FlowerPoint").transform;

		if(PlayerSpript.IsRain) {
			Rain = true;
			Text.text = "It's raining...";
		}
		if(Rain){
			transform.position = Vector2.MoveTowards(transform.position, Points[Points.Length - 1].position, Time.deltaTime * Speed);
			i = Points.Length - 1;
		}else if(PlayerSpript.IsFlower && !PlayerSpript.IsRain&& i < Points.Length) transform.position = Vector2.MoveTowards(transform.position, PlayerTransform.position, Time.deltaTime * Speed);
		else if(!PlayerSpript.IsFlower && !PlayerSpript.IsRain && i < Points.Length){
			transform.position = Vector2.MoveTowards(transform.position, Points[i].position, Time.deltaTime * Speed);
			if(transform.position == Points[i].position) i ++;
		}
                if(w < 0f) w = 0;
	}

    void OnTriggerEnter2D(Collider2D other){
        if (other.gameObject.GetComponent<GP_3_Player>()){
            w = 3f;
        }
    }
    void OnTriggerStay2D(Collider2D other){
        if (other.gameObject.GetComponent<GP_3_Player>()){
            if(w > 0f){
                w -= 1f * Time.deltaTime;
            }
            if(w <= 0f){
                 Rain = true;
	    }
        }
    }
    void OnTriggerExit2D(Collider2D other){
        if (other.gameObject.GetComponent<GP_3_Player>()){
            if(w <= 0f){
                 PlayerSpript.PollenCollected(0.5f);
                 Rain = true;
	    }
            else if(w > 0f && w < 3f){
                 PlayerSpript.PollenCollected((3 - w) / 6);
                 Rain = true;
	    }
        }
    }
}














			/*for(int y = 0; Points.Length > y; y ++)
			{
				int t = Points[];
                                if(new Vector2.Distance(transform.position, Point2);)
			}*/
