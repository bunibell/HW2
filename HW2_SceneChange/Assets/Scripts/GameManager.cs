using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    //Variables 
    //Make it a singleton!
    public static GameManager instance;

    public TextMeshProUGUI score;

    public TextMeshProUGUI p3score;

    public int p3sc_num;

    public int sc_num;

    private bool canstart = true;

    //Awake is called on spawn of this script before start
    private void Awake()
    {
        //A singleton must only have one instance check to make sure this is the only instance 
        //if it is make sure it is not destroyed, if its not destroy this instance.
        if (instance == null)
        {
            DontDestroyOnLoad(gameObject);
            instance = this;
        }
        else
        {
            Destroy(gameObject);

        }
    }
    // Start is called before the first frame update
    void Start()
    {
        //Make the score 0
        sc_num = 0;
        p3sc_num = 0;
        //score.text = "score: " + sc_num;
    }

    // Update is called once per frame
    void Update()
    {
        //Make the score text say Score: and a number 
        score.text = "score: " + sc_num;

        p3score.text = "score: " + p3sc_num;
        if (Input.GetKey(KeyCode.P))
        {
            SceneManager.LoadScene(1);
            sc_num = 0;
            p3sc_num = 0;
            canstart = true;
        }
    }

    public void StartGame()
    {
        if (canstart)
        {
            SceneManager.LoadScene("GameScene");
            canstart = false;
        }
    }
}