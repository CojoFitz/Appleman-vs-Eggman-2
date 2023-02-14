using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour
{
    public int dodgeTime;
    public Text timerText;
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }
    void Start()
    {
        StartCoroutine(timerDodge());
    }

    IEnumerator timerDodge()
    {
        while(dodgeTime > 0)
        {
            timerText.text = dodgeTime.ToString();
            yield return new WaitForSeconds(1f);
            dodgeTime--;
        }
        if(dodgeTime <= 0)
        {
            winCondition();

        }

    }

    // Update is called once per frame
    void winCondition()
    {
        if(tran.getLoser() == "apple")
        {
            tran.updateEggHealth(10);
        }
        if (tran.getLoser() == "egg")
        {
            tran.updateAppleHealth(10);
        }
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
}
