using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class PaperScript : MonoBehaviour
{
    bool active;
    public float speed = 10.0f;
    private Rigidbody2D ridge;
    private Vector2 screenBounds;
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }

    void Start()
    {
        active = true;
        ridge = this.GetComponent<Rigidbody2D>();
        ridge.velocity = new Vector2(0, speed);
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
        Destroy(gameObject, 6);

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
}
