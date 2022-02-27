using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance()
    {
        return _singleton;
    }

    private static GameManager _singleton;
    
    
    /************************/
    public GameObject[] spawnablePoints;
    public GameObject targetPrefab;
    public GameObject targetInstance;
    public GameObject player;

    public TMP_Text nbCibleText;
    public TMP_Text timeText;
    public TMP_Text scoreText;

    public Menu menuScript;
    
    
    /************/
    private int nbCible = 3;
    private int nbCibleCurrent = 3;
    private float time = 60;
    private float timeStart;
    private int score = 0;
    
    
    
    // Start is called before the first frame update
    void Start()
    {
        _singleton = this;
        targetInstance = Instantiate(targetPrefab, Vector3.zero, Quaternion.Euler(0, 0, 0));
        nbCibleText.text = "Cibles restantes : " + nbCible;
        
        SpawnRandomTarget();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            NextTarget();
        }
        time = Time.time - timeStart;
        var intTime = (int) time;
        timeText.text = intTime.ToString();
        if (time < 0)
        {
            EndGame();
        }
    }

    public void StartGame()
    {
        timeStart = Time.time;
        score = 0;
    }

    public void SpawnRandomTarget()
    {
        targetInstance.SetActive(false);
        int rand = Random.Range(0, spawnablePoints.Length);
        targetInstance.transform.position = spawnablePoints[rand].transform.position;
        targetInstance.transform.LookAt(new Vector3(player.transform.position.x, targetInstance.transform.position.y, player.transform.position.z));
        targetInstance.SetActive(true);
    }

    public void NextTarget()
    {
        nbCibleCurrent--;
        score++;
        nbCibleText.text = "Cibles restantes : " + nbCibleCurrent;
        SpawnRandomTarget();
        if (nbCibleCurrent == 0)
        {
            EndRound();
        }
    }

    public void EndRound()
    {
        nbCible++;
        nbCibleCurrent = nbCible;
        time = 60;
        nbCibleText.text = "Cibles restantes : " + nbCible;
    }

    public void EndGame()
    {
        scoreText.text = "Votre score est de " + score;
        menuScript.EndGameUI();
    }
}
