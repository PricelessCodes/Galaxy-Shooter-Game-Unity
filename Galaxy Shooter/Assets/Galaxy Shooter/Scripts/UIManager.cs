using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    public Sprite[] Lives;
    public Image LivesImageDisplay;
    public Text PlayerScoreText;
    public int PlayerScore;
    public GameObject GameTitle;

	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}

    public void UpdateLives(int CurrentLives)
    {
        LivesImageDisplay.sprite = Lives[CurrentLives];
    }

    public void UpdateScore(int ComingScore)
    {
        if ( ComingScore > 0 )
        {
            PlayerScore += ComingScore;
        }
        else
        {
            PlayerScore = 0;
        }
        PlayerScoreText.text = "Score: " + PlayerScore;
    }

    public void ShowGameTitle()
    {
        GameTitle.SetActive(true);
    }

    public void HideGameTitle()
    {
        GameTitle.SetActive(false);
    }
}
