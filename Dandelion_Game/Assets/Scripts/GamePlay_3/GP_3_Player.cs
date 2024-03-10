using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GP_3_Player : MonoBehaviour
{
    public Slider ProgressSlider;
    public Slider HealthSlider;
    public Slider FlowerSlider;

    public float MProgress = 10f;
    public float MHealth = 10f;
    public float MFlower = 10f;

    public float Progress;
    public float Health;
    public float Flower;
    public bool IsFlower;

    public float RainTimer;
    public float MaxRainTimer = 100f;
    public float MinRainTimer = 0f;

    public float RainDuration;
    public float MaxRainDuration = 100f;
    public float MinRainDuration = 0f;

    public bool IsRain;
    public GameObject RainObject;
    public GameObject GameOverPanel;

	public string AnimNameOpen;
	private Animator Anim;

    void Awake()
    {
        Anim = GetComponentInParent<Animator>();
        Progress = 0f;
        Health = MHealth;
        Flower = MFlower;

        RainTimer = Random.Range(MinRainTimer,MaxRainTimer);
        IsRain = false;
        RainObject.SetActive(false);

        HealthSlider.maxValue = MHealth;
        FlowerSlider.maxValue = MFlower;
    }
    void Update()
    {
        if(Progress >= MProgress) Win();
        if(Health <= 0f && Progress <= 0f) GameOver();

        if(Progress > MProgress) Progress = MProgress;
        if(Health <= 0f && Progress > 0f) Progress -= 0.075f * Time.deltaTime;

        if(Health > MHealth) Health = MHealth;
        if(Health < 0f) Health = 0f;
        if(Health < MHealth) Health += 0.3f * Time.deltaTime;

        if(Flower > MFlower) Flower = MFlower;
        if(Flower < MFlower && !IsRain) Flower += 1f * Time.deltaTime;
        if(Flower >= 0f && IsRain && IsFlower) Flower -= 2f * Time.deltaTime;

        if(RainTimer > 0f) RainTimer -= 1f * Time.deltaTime;
        if(RainTimer <= 0f && !IsRain){
            It_is_Rain();
            RainDuration = Random.Range(MinRainDuration,MaxRainDuration);
        }
        if(RainDuration > 0f) RainDuration -= 1f * Time.deltaTime;
        if(RainDuration <= 0 && IsRain){
            It_is_not_Rain();
            RainTimer = Random.Range(MinRainTimer,MaxRainTimer);
        }
        if(RainTimer <= 2f) RainObject.SetActive(true);

        ProgressSlider.value = Progress;
        HealthSlider.value = Health;
        FlowerSlider.value = Flower;        
    }
    public void It_is_Rain(){
        IsRain = true;
    }
    public void It_is_not_Rain(){
        IsRain = false;
        RainObject.SetActive(false);
    }
    void OnMouseDown(){
        if(Health > 0f && Flower > 0f) IsFlower = true;
	Anim.SetBool(AnimNameOpen, true);
    }
    void OnMouseUp(){
        IsFlower = false;
	Anim.SetBool(AnimNameOpen, false);
    }
    public void PollenCollected(float q){
        if(Health > 0f && Flower > 0f && Progress < MProgress) Progress += q;
    }
    public void Win(){
	SceneManager.LoadScene("Cut-Scene_4");
    }
    public void GameOver(){
	Time.timeScale = 0f;
	GameOverPanel.SetActive(true);
    }
	void OnColliderEnter2D(Collision2D other){
		if (other.gameObject.GetComponent<GP_2_3_Enemy>()){ 
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 1){ 
				Health -= 1f;
			}
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 2){ 
				Health -= 2f;
			}
		}
	}
	void OnColliderStay2D(Collision2D other){
		if (other.gameObject.GetComponent<GP_2_3_Enemy>()){ 
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 1){ 
				Health -= 0.1f * Time.deltaTime;
			}
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 2){ 
				Health -= 0.2f * Time.deltaTime;
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other){
		if (other.gameObject.GetComponent<GP_2_3_Enemy>()){ 
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 1){ 
				Health -= 1f;
			}
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 2){ 
				Health -= 2f;
			}
		}
	}
	void OnTriggerStay2D(Collider2D other){
		if (other.gameObject.GetComponent<GP_2_3_Enemy>()){ 
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 1){ 
				Health -= 0.1f * Time.deltaTime;
			}
			if (other.gameObject.GetComponent<GP_2_3_Enemy>().Types == 2){ 
				Health -= 0.2f * Time.deltaTime;
			}
		}
	}
}
