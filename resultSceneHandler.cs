using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class resultSceneHandler : MonoBehaviour
{
    public Text AppSelectText;
    public Text EggSelectText;
    public GameObject sadApple;
    public GameObject sadEgg;
    public Text outcomeText;
    public Button proceed;
    public string rpsLoser;

    //Remember to add UI stuff, display selections, etc. 
    private Transition tran;
    void Awake()
    {
        tran = GameObject.FindObjectOfType<Transition>();
    }
    // Start is called before the first frame update
    void Start()
    {
        sadApple.SetActive(false);
        sadEgg.SetActive(false);
        rpsLoser = tran.getLoser();
        rpsLoser = char.ToUpper(rpsLoser[0]) + rpsLoser.Substring(1);
        Debug.Log(rpsLoser);
        if(rpsLoser == "Apple")
        {
            sadApple.SetActive(true);
        }
        else
        {
            sadEgg.SetActive(true);
        }
        AppSelectText.text = "Appleman selected: " + tran.getAppleChoice();
        EggSelectText.text = "Eggman selected: " + tran.getEggChoice();
        outcomeText.text = rpsLoser + "man lost the battle! Please pass the controls to: " + 
            rpsLoser + "man! It is time for them to face the wrath of their foe. When ready click proceed!";
        proceed.onClick.AddListener(dodgeSwitch);

    }

    // Update is called once per frame
    void dodgeSwitch()
    {
        SceneManager.LoadScene("Dodge", LoadSceneMode.Single);
    }

}
