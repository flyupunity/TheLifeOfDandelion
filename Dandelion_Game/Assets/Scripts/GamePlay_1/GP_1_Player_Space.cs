using UnityEngine;
using UnityEngine.SceneManagement;

public class GP_1_Player_Space : MonoBehaviour
{
    private Rigidbody2D Rid;

    public float Force;
    public float GlobalForce;

    public KeyCode Space;
    public KeyCode Mouse;

    public Transform I;
    public GameObject GameOverPanel;
    public Sprite Sprite;
    public SpriteRenderer MySprite;

    void Awake()
    {
        Rid = GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        //Rid.AddForce(new Vector2(GlobalForce,0f));
        if(Input.GetKeyDown(Space) || Input.GetKeyDown(Mouse)){
            Rid.AddForce(new Vector2(0f,Force));
        }
    }
    void FixedUpdate()
    {
         if(Time.timeScale != 0f) transform.position = Vector2.MoveTowards(transform.position, I.position, 1f * GlobalForce);
    }

    public void Win(){
	SceneManager.LoadScene(3);
    }
    public void GameOver(){
	Time.timeScale = 0f;
	GameOverPanel.SetActive(true);
        MySprite.sprite = Sprite;
    }
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<GP_1_Enemy>()){ 
			GameOver();
		}
		if (other.gameObject.GetComponent<Win>()){ 
			Win();
		}
		if (other.gameObject.GetComponent<DanderZone>()){ 
			GameOver();
		}
	}
}