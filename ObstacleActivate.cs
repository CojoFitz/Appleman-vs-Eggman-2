using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class ObstacleActivate : MonoBehaviour
{
    Renderer rend;
    public bool active = false;
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }
    void Start()
    {
        rend = GetComponent<Renderer>();
        StartCoroutine(activate());
        Destroy(gameObject, 2);
    }

    void triggerEvent()
    {
        if (active)
        {
            if (tran.getLoser() == "apple")
            {
                tran.updateAppleHealth(10);
            }

            if (tran.getLoser() == "egg")
            {
                tran.updateEggHealth(10);
            }
            SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        triggerEvent();
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        triggerEvent();
    }



    IEnumerator activate()
    {

        yield return new WaitForSeconds(1);
        rend.material.color = Color.green;
        active = true;
    }


}
