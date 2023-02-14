using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleMaker : MonoBehaviour
{
    public GameObject circle;
    public GameObject scissors;
    public GameObject paper;
    private Renderer rend;

    private float respawnTime;
    public float rockFight = 0.05f;
    public float scissorsFight = 3;

    public float paperFight = 0.19f;
    private Vector2 screenBounds;
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }
    void Start()
    {
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        if(tran.getWinningChoice() == "rock")
        {
            respawnTime = rockFight;
        }
        if (tran.getWinningChoice() == "paper")
        {
            respawnTime = paperFight;
        }
        if (tran.getWinningChoice() == "scissors")
        {
            respawnTime = 0.1702f;
        }
        StartCoroutine(bulletSummon());
    }
    private void spawnEnemy()
    {
        if (tran.getWinningChoice() == "rock")
        {
            GameObject a = Instantiate(circle) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
            a.GetComponent<Renderer>().material.color = Color.grey;
        }

        if (tran.getWinningChoice() == "scissors")
        {

            GameObject a = Instantiate(scissors) as GameObject;
            Vector3 euler = transform.eulerAngles;
            euler.z = Random.Range(0f, 360f);
            a.transform.eulerAngles = euler;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x), Random.Range(-screenBounds.y, screenBounds.y));
            a.GetComponent<Renderer>().material.color = Color.grey;
        }

        if (tran.getWinningChoice() == "paper")
        {
            GameObject a = Instantiate(paper) as GameObject;
            a.transform.position = new Vector2(Random.Range(-screenBounds.x, screenBounds.x),  screenBounds.y);
        }
    }
    IEnumerator bulletSummon()
    {
        while (true)
        {
            yield return new WaitForSeconds(respawnTime);
            spawnEnemy();
        }
    }





}
