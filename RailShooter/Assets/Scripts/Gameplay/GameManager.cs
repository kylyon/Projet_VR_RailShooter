using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameManager Instance()
    {
        return _singleton;
    }

    private GameManager _singleton;
    
    
    /************************/
    public GameObject[] spawnablePoints;
    public GameObject targetPrefab;
    public GameObject targetInstance;
    public GameObject player;
    
    
    /************/
    private int nbCible = 3;
    private int nbCibleCurrent = 3;
    private float time = 60;
    
    
    // Start is called before the first frame update
    void Start()
    {
        _singleton = this;
        targetInstance = Instantiate(targetPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        
        SpawnRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        if (time < 0)
        {
            EndRound();
        }
    }

    void SpawnRandomTarget()
    {
        targetInstance.SetActive(false);
        int rand = Random.Range(0, spawnablePoints.Length);
        targetInstance.transform.position = spawnablePoints[rand].transform.position;
        targetInstance.transform.LookAt(new Vector3(player.transform.position.x, targetInstance.transform.position.y, player.transform.position.z));
        targetInstance.SetActive(true);
    }

    void NextTarget()
    {
        nbCibleCurrent--;
        SpawnRandomTarget();
        if (nbCibleCurrent == 0)
        {
            EndRound();
        }
    }

    void EndRound()
    {
        nbCible++;
        time = 60;
    }
}
