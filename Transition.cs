using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Transition : MonoBehaviour
{
    //This entire class is responsible for handling transitions between scenes
    public static int appleHealth = 100;
    public static int eggHealth = 100;
    public static string theWinner;
    public static string loser;
    public static string appleChoice;
    public static string eggChoice;
    public static string winningChoice;
    public static string finalWinner;



    void Start()
    {

    }


    public void setLoser(string whoWon)
    {
        theWinner = whoWon;
        if(whoWon == "egg")
        {
            winningChoice = eggChoice;
            loser = "apple";
        }else if(whoWon == "apple")
        {
            winningChoice = appleChoice;
            loser = "egg";
        }
    }
    public string getWinningChoice()
    {
        return winningChoice;
    }
    public string getRpsWinner()
    {
        return theWinner;
    }
    public string getLoser()
    {
        return loser;
    }

    public void setAppleChoice(string choice)
    {
        appleChoice = choice;
    }
    public void setEggChoice(string choice)
    {
        eggChoice = choice;
    }

    public string getAppleChoice()
    {
        return appleChoice;
    }
    public string getEggChoice()
    {
        return eggChoice;
    }

    public void updateAppleHealth(int amount)
    {
        appleHealth -= amount;
        if(appleHealth <= 0)
        {
            finalWinner = "Eggman";
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }

    public void updateEggHealth(int amount)
    {
        eggHealth -= amount;
        if (eggHealth <= 0)
        {
            finalWinner = "Appleman";
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }
    }
    public string getFinalWinner()
    {
        return finalWinner;
    }
    public int getAppleHealth()
    {
        return appleHealth;
    }

    public int getEggHealth()
    {
        return eggHealth;
    }



}
