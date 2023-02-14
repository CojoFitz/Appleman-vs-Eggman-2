using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class NewBehaviourScript : MonoBehaviour
{
    public AudioSource funnySound;
    public Button yourButton;

    // Start is called before the first frame update
    void Start()
    {
      
        Button btn = yourButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);

    }

    // Update is called once per frame
    void TaskOnClick()
    {
        funnySound.Play();
        SceneManager.LoadScene("BattleScene", LoadSceneMode.Single);
    }
}
