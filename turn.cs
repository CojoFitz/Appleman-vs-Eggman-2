using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class turn : MonoBehaviour
{
    int appHp;
    int eggHp;
    public AudioSource selectNoise;
    public Button rock;
    public Button paper;
    bool pressed = false;
    public Button scissors;
    public Text textBox;
    public Text appleHealthBox;
    public Text eggHealthBox;
    string curTurn = "Apple";
    public GameObject appleSprite;
    public GameObject eggSprite;
    string appleSelection;
    string eggSelection;
    string selection = "empty";
    string victor = "none";
    public Button confirm;
    private Transition tran;
    // Start is called before the first frame update
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }
    // Start is called before the first frame update
    void Start()
    {
        
        appHp = tran.getAppleHealth();
        eggHp = tran.getEggHealth();
        checkIfAlive();
        victor = "none";
        textBox.text = "It is now Appleman/Player One's turn to select a move. Please look away from the screen if you are Eggman (player two).";
        eggHealthBox.text = "Eggman Health: " + eggHp +"/100";
        appleHealthBox.text = "Appleman Health: " + appHp + "/100";
        selection = "empty";
        appleSprite.SetActive(true);
        eggSprite.SetActive(false);
        curTurn = "Apple";
    }

    void checkIfAlive()
    {
        if(appHp <= 0)
        {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }

        if (eggHp <= 0)
        {
            SceneManager.LoadScene("WinScreen", LoadSceneMode.Single);
        }

    }


    // Update is called once per frame
    void Update()
    {

        rock.onClick.AddListener(delegate { buttonPress(rock); });
        paper.onClick.AddListener(delegate { buttonPress(paper); });
        scissors.onClick.AddListener(delegate { buttonPress(scissors); });
        confirm.onClick.AddListener(confirmButton);



    }


    IEnumerator Delay()
    {
        yield return new WaitForSeconds(1);
        victor = "none";
        textBox.text = "It is now Appleman/Player One's turn to select a move. Please look away from the screen if you are Eggman (player two).";
        selection = "empty";
        appleSprite.SetActive(true);
        eggSprite.SetActive(false);
        curTurn = "Apple";
    }

    void greyOut()
    {
        rock.GetComponent<Image>().color = Color.grey;
        paper.GetComponent<Image>().color = Color.grey;
        scissors.GetComponent<Image>().color = Color.grey;
    }
    void buttonPress(Button clicked)
    {
        selectNoise.Play();
        greyOut();
        clicked.GetComponent<Image>().color = Color.green;
        selection = clicked.ToString();
        

    }
    
    void confirmButton()
    {
        if(selection == "chungus")
        {
            if (curTurn == "TIE")
            {
                victor = "none";
                textBox.text = "It is now Appleman/Player One's turn to select a move.";
                selection = "empty";
                appleSprite.SetActive(true);
                eggSprite.SetActive(false);
                curTurn = "Apple";

            }
        }
        if (selection != "empty")
        {
            pressed = true;

            if (curTurn == "Apple")
            {
                appleSelection = selection;
                tran.setAppleChoice(appleSelection);
                greyOut();
                selection = "empty";
                curTurn = "Egg";
                appleSprite.SetActive(false);
                eggSprite.SetActive(true);
                textBox.text = "It is now Eggman/Player Two's turn to select a move. Please look away from the screen if you are appleman(Player 1).";

            }
            else if(curTurn == "Egg")
            {
                eggSelection = selection;
                selection = "empty";
                greyOut();
                winner();

            }


        }
    }
    public string getWinner()
    {
        return victor;
    }



    void winner()
    {

        if (eggSelection == appleSelection)
        {
            eggSprite.SetActive(false);
            appleSelection = "empty";
            eggSelection = "empty";
            selection = "chungus"; //this is a really stupid placeholder that makes my code work LOL
            textBox.text = "There was a tie! Will now proceed with the next round";
            StartCoroutine(Delay());


        }
        else if (appleSelection == rock.ToString())
        {
            tran.setAppleChoice("rock");
            // Checks what happens if apple picks ROCK
            if (eggSelection == scissors.ToString())
            {
                victor = "apple";
                tran.setEggChoice("scissors");
                tran.setLoser(victor);
                SceneManager.LoadScene("result", LoadSceneMode.Single);
                // Apple win
            }
            else if(eggSelection == paper.ToString())
            {
                victor = "egg";
                tran.setEggChoice("paper");
                tran.setLoser(victor);
                SceneManager.LoadScene("result", LoadSceneMode.Single);
            }
        } else if(appleSelection == scissors.ToString())
        {
            tran.setAppleChoice("scissors");

            if (eggSelection == paper.ToString())
            {
                //APPLE WIN
                victor = "apple";
                tran.setEggChoice("paper");
                tran.setLoser(victor);
                SceneManager.LoadScene("result", LoadSceneMode.Single);

            }
            else if(eggSelection == rock.ToString())
            {
                //egg win
                victor = "egg";
                tran.setEggChoice("rock");
                tran.setLoser(victor);
                SceneManager.LoadScene("result", LoadSceneMode.Single);

            }
        }
        else if(appleSelection == paper.ToString())
        {
            tran.setAppleChoice("paper");

            if (eggSelection == rock.ToString())
            {
                //apple win
                victor = "apple";
                tran.setEggChoice("rock");
                tran.setLoser(victor);
                SceneManager.LoadScene("result", LoadSceneMode.Single);

            }
            else if(eggSelection == scissors.ToString())
            {
                //eggwin
                victor = "egg";
                tran.setEggChoice("scissors");
                tran.setLoser(victor);
                SceneManager.LoadScene("result", LoadSceneMode.Single);


            }
        }
    if(victor != "none")
        {
            tran.setLoser(victor);
            SceneManager.LoadScene("result", LoadSceneMode.Single);

        }


    }
    
}
