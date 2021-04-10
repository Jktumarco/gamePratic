   
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Main : MonoBehaviour

{
    static public Main S;

    [Header("Set in Inspector")]
    public GameObject[] prefabEnemies;
    public float enemySpawnPerSecond = 0.5f;
    public float enemyDefaultPadding = 1.5f;
    public WeaponDefinition[] weaponDefinitions;

    private BoundsCheck bndCheck;

    private void Awake()
    {
        S = this;
        bndCheck = GetComponent<BoundsCheck>();
        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    public void SpawnEnemy()
    {
        int ndx = Random.Range(0, prefabEnemies.Length);
        GameObject go = Instantiate<GameObject>(prefabEnemies[ndx]);

        float enemyPadiing = enemyDefaultPadding;
        if (go.GetComponent<BoundsCheck>() != null)
        {
            enemyPadiing = Mathf.Abs(go.GetComponent<BoundsCheck>().radius);
        }

        Vector3 pos = Vector3.zero;
        float xMin = -bndCheck.camWidth + enemyPadiing;
        float xMax = bndCheck.camWidth - enemyPadiing;
        pos.x = Random.Range(xMin, xMax);
        pos.y = bndCheck.camHeigth + enemyPadiing;
        go.transform.position = pos;


        Invoke("SpawnEnemy", 1f / enemySpawnPerSecond);
    }
    public void DelayedRestart(float delay){
        Invoke("Restart", delay);
    }
    public void Restart(){
        SceneManager.LoadScene("_Scene_0");
    }

  
}
