using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GP_2_Player : MonoBehaviour
{
    public Slider ProgressSlider;
    public Slider HealthSlider;
    public Slider SunSlider;
    public Slider RainSlider;

    public float MProgress = 10f;
    public float MHealth = 10f;
    public float MSun = 5f;
    public float MRain = 5f;

    public float Progress;
    public float Health;
    public float Sun;
    public float Rain;

    public bool IsRain;
    
    public GameObject GameOverPanel;

    /*private SpriteRenderer MySprite;
    public BoxCollider2D MyCollider;
    public BoxCollider2D MyTrigger;*/

    public Sprite[] Sprite;

    void Awake()
    {
        //MySprite = GetComponent<SpriteRenderer>();
        //MyCollider = GetComponent<BoxCollider2D>();

        Progress = 0f;
        Health = MHealth;
        Sun = MSun;
        Rain = MRain;
        IsRain = false;

    }
    void Update()
    {
        if(Progress >= MProgress) Win();
        if(Health <= 0f && Progress <= 0f) GameOver();

        /*int i = Mathf.RoundToInt(Progress);
        //print(i);
        MySprite.sprite = Sprite[i];
        MyCollider.size = new Vector2(0.645f, 0.645f * ((float)i + 1) );
        MyCollider.offset = new Vector2(0, 0.322f * ((float)i + 1) );

        MyTrigger.size = new Vector2(1f, 0.645f * ((float)i + 1) );
        MyTrigger.offset = new Vector2(0, 0.322f * ((float)i + 1) );*/

        if(Progress > MProgress) Progress = MProgress;
        if(Health > 0f && Sun > 0f && Rain > 0f && Progress < MProgress) Progress += 0.1f * Time.deltaTime;
        if(Health <= 0f && Progress >= 0f) Progress -= 0.075f * Time.deltaTime;

        if(Health > MHealth) Health = MHealth;
        if(Health < MHealth && Sun > 0f && Rain > 0f) Health += 0.1f * Time.deltaTime;
        if(Health >= 0f){
            if(Rain <= 0f) Health -= 0.5f * Time.deltaTime;
            if(Sun <= 0f) Health -= 0.25f * Time.deltaTime;
        }else Health = 0f;

        if(Sun > MSun) Sun = MSun;
        if(Sun < MSun && !IsRain) Sun += 1f * Time.deltaTime;
        if(Sun >= 0f && IsRain) Sun -= 1f * Time.deltaTime;

        if(Rain > MRain) Rain = 10f;
        if(Rain < MRain && IsRain) Rain += 1f * Time.deltaTime;
        if(Rain >=  0f && !IsRain) Rain -= 1f * Time.deltaTime;

        //ProgressSlider.maxValue = MProgress;
        HealthSlider.maxValue = MHealth;
        SunSlider.maxValue = MSun;
        RainSlider.maxValue = MRain;

        ProgressSlider.value = Progress;
        HealthSlider.value = Health;
        SunSlider.value = Sun;
        RainSlider.value = Rain;
        
    }
    public void It_is_Rain(){
        IsRain = true;
    }
    public void It_is_not_Rain(){
        IsRain = false;
    }
    public void Win(){
	SceneManager.LoadScene("GamePlay_3");
    }
    public void GameOver(){
	Time.timeScale = 0f;
	GameOverPanel.SetActive(true);
    }
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 1){ 
			Health -= 1;
		}
		if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 2){ 
			Health -= 2;
		}
	}
    void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 1){ 
			Health -= 0.05f * Time.deltaTime;
		}
		if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 2){ 
			Health -= 0.1f * Time.deltaTime;
		}
	}
    /*public void Health(float Health, float Max, float PlysInSecond, bool True)
    {
        if(Health >= Max) Health = Max;
        else if(True) Health += PlysInSecond * 50;
    }*/
}