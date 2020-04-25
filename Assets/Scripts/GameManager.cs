using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private static GameManager instance;

    [SerializeField] private Text txt;
    [SerializeField] private GameObject game1, game2;
    private int score = 0;
    private bool isOpen = false;

    public static GameManager Instance {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<GameManager>(); 
            }
            return instance;
        }
    }

    public int Score 
    {
        set
        {
            txt.text = value.ToString();
            score = value;
        }
        get
        {
            return score;
        }
    }

    public bool IsOpen
    {
        get
        {
            return isOpen;
        }
        set
        {
            if (value == true)
            {
                game1.SetActive(false);
                game2.SetActive(true);
            }
            isOpen = value;
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
    }
}
