using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WinScreenPrep : MonoBehaviour
{
    public Text winnerText;
    public GameObject eggSad;
    public GameObject eggHappy;
    public GameObject appleSad;
    public GameObject appleHappy;
    string finalWin;
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }
    void Start()
    {
        finalWin = tran.getFinalWinner();
        winnerText.text = finalWin + " is the winner!";
        if(finalWin == "Appleman")
        {
            appleHappy.SetActive(true);
            eggSad.SetActive(true);
        }
        else
        {
            eggHappy.SetActive(true);
            appleSad.SetActive(true);
        }
    }

}
