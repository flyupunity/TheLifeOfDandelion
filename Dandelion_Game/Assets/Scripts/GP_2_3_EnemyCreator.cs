using System.Collections;
using UnityEngine;

[System.Serializable]
public struct EnemyVariables
{
    public GameObject _enemyPrefab;
    public float _maxTimerValue;
    public float _minTimerValue;
}
public class GP_2_3_EnemyCreator : MonoBehaviour
{
    [SerializeField] private EnemyVariables[] enemy;
    [SerializeField] private Transform[] spawnPoint = null;

    private void Start()
    {
        for (int i = 0; i < enemy.Length; i++)
        {
            StartCoroutine(CreateEnemy(enemy[i]._enemyPrefab, enemy[i]._maxTimerValue, enemy[i]._minTimerValue, i));
        }
    }
    private IEnumerator CreateEnemy(GameObject _enemyPrefab, float _maxTimerValue, float _minTimerValue, int enemyIndex)
    {
        float time = Random.Range(enemy[enemyIndex]._minTimerValue, enemy[enemyIndex]._maxTimerValue);
        yield return new WaitForSeconds(time);

		Transform point = spawnPoint[Random.Range(0, spawnPoint.Length)];
        GameObject newEnemy = Instantiate(enemy[enemyIndex]._enemyPrefab, point.position, point.rotation);

        StartCoroutine(CreateEnemy(enemy[enemyIndex]._enemyPrefab, enemy[enemyIndex]._maxTimerValue, enemy[enemyIndex]._minTimerValue, enemyIndex));
    }
}

