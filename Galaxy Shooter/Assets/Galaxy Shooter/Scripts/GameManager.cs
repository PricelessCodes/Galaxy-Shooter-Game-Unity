using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public bool IsGameOver = true;
    public GameObject PlayerPrefab;

    private UIManager ManageUI;
	// Use this for initialization
	void Start ()
    {
        ManageUI = GameObject.Find("Canvas").GetComponent<UIManager>();
	}
	
	// Update is called once per frame
	void Update ()
    {
		if ( IsGameOver == true )
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                Instantiate(PlayerPrefab, Vector3.zero, Quaternion.identity);
                IsGameOver = false;
                if ( ManageUI != null )
                {
                    ManageUI.HideGameTitle();
                }
            }
        }
	}
}
