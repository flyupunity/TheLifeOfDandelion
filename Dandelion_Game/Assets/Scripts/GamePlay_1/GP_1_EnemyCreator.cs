using System.Collections;
using UnityEngine;

public class GP_1_EnemyCreator : MonoBehaviour
{
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private float _maxTimerValue = 7f;
    [SerializeField] private float _minTimerValue = 2;

    [SerializeField] private Transform[] spawnPoint = null;


	void Awake()
	{
        StartCoroutine(CreateEnemy());
	}
    private IEnumerator CreateEnemy()
    {
        float yPos = spawnPoint[Random.Range(0, spawnPoint.Length)].position.y;

        GameObject newEnemy = Instantiate(_enemyPrefab, new Vector2(spawnPoint[0].position.x, yPos), transform.rotation);
        newEnemy.GetComponent<GP_1_Enemy>().SetRandomSprite();

        float time = Random.Range(_minTimerValue, _maxTimerValue);
        yield return new WaitForSecondsRealtime(time);
        StartCoroutine(CreateEnemy());
    }
}
