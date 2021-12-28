  using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    private GameObject LaserPrefab;
    [SerializeField]
    private GameObject TripleShotsLaserPrefab;
    [SerializeField]
    private float FireRate = 0.25f;
    [SerializeField]
    private GameObject PlayerExplosionPrefab;
    [SerializeField]
    private GameObject PlayerShieldChild;
    [SerializeField]
    private GameObject PlayerRightEngineHurt;
    [SerializeField]
    private GameObject PlayerLeftEngineHurt;

    private GameObject PnnPlayerShield;

    private float CanFire = 0.0f;

    [SerializeField]
    private float SpeedHorizontal = 5.0f;
    [SerializeField]
    private float SpeedVertical = 5.0f;

    //private float OldHorizontal = 0.0f;
    //private float OldVertical = 0.0f;

    public bool CanTripleShot = false;
    public bool IsShieldOn = false;

    [SerializeField]
    private int PlayerLives = 3;
    
    public int PlayerScore = 0;

    private UIManager ManageUI;

    private GameManager ManageGame;

    private SpawnManager ManageSpwan;

    private AudioSource LaserShotAudioSource;

    [SerializeField]
    private AudioClip PlayerExplosionAudioSource;

    // Use this for initialization
    void Start ()
    {
        transform.position = new Vector3(0, -4.2f, 0);
        //Debug.Log("Screen Width : " + Screen.width);
        //Debug.Log("Screen Height : " + Screen.height);

        ManageUI = GameObject.Find("Canvas").GetComponent<UIManager>();
        if ( ManageUI != null )
        {
            ManageUI.UpdateLives(PlayerLives);
            ManageUI.UpdateScore(PlayerScore);
        }

        ManageGame = GameObject.Find("Game Manager").GetComponent<GameManager>();

        ManageSpwan = GameObject.Find("Spawn Manager").GetComponent<SpawnManager>();
        if ( ManageSpwan != null )
        {
            ManageSpwan.StartSpwanRoutiness();
        }

        LaserShotAudioSource = GetComponent<AudioSource>();
    }
    
	// Update is called once per frame
	void Update ()
    {
        PlayerMovement();
        PlayerShoots();
    }

    private void PlayerMovement()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");

        float VerticalInput = Input.GetAxis("Vertical");

        transform.Translate(Vector3.right * SpeedHorizontal * HorizontalInput * Time.deltaTime);

        transform.Translate(Vector3.up * SpeedVertical * VerticalInput * Time.deltaTime);

        if (transform.position.y > 0)
        {
            transform.position = new Vector3(transform.position.x, 0, 0);
        }
        else if (transform.position.y < -4.2f)
        {
            transform.position = new Vector3(transform.position.x, -4.2f, 0);
        }

        /* // Bounds in X-axis
         if (transform.position.x > 8.2f)
        {
            transform.position = new Vector3(8.2f, transform.position.y, 0);
        }
        else if (transform.position.x < -8.2f)
        {
            transform.position = new Vector3(-8.2f, transform.position.y, 0);
        }*/

        //Raped move in X-axis
        if (transform.position.x > 9.5f)
        {
            transform.position = new Vector3(-9.5f, transform.position.y, 0);
        }
        else if (transform.position.x < -9.5f)
        {
            transform.position = new Vector3(9.5f, transform.position.y, 0);
        }
    }

    private void PlayerShoots()
    {
        if (Input.GetKey(KeyCode.Space) && Time.time > CanFire)
        {
            LaserShotAudioSource.Play();
            if (CanTripleShot == true)
            {
                Instantiate(TripleShotsLaserPrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(LaserPrefab, transform.position + new Vector3(0, 0.7f, 0), Quaternion.identity);
            }
            CanFire = Time.time + FireRate;
        }
    }

    public void TripleShotPowerUpOn()
    {
        CanTripleShot = true;
        StartCoroutine(TripleShotPowerDownRoutine());
    }

    public IEnumerator TripleShotPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        CanTripleShot = false;
    }

    public void SpeedUpPowerUpOn()
    {
        SpeedHorizontal *= 2;
        SpeedVertical *= 2;
        StartCoroutine(SpeedUpPowerDownRoutine());
    }

    public IEnumerator SpeedUpPowerDownRoutine()
    {
        yield return new WaitForSeconds(5.0f);
        SpeedHorizontal /= 2;
        SpeedVertical /= 2;
    }

    public void DestroyPlayer()
    {
        if (IsShieldOn == true)
        {
            IsShieldOn = false;
            PlayerShieldChild.SetActive(false);
            //Destroy(PnnPlayerShield.gameObject);
        }
        else
        { 
            PlayerLives--;
            ManageUI.UpdateLives(PlayerLives);
            if (PlayerLives == 0)
            {
                Instantiate(PlayerExplosionPrefab, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(PlayerExplosionAudioSource, Camera.main.transform.position);
                if ( ManageGame != null )
                {
                    ManageGame.IsGameOver = true;
                    ManageUI.ShowGameTitle();
                }
                Destroy(this.gameObject);
            }
            else
            {
                if ( PlayerLives % 2 == 0 )
                {
                    PlayerRightEngineHurt.SetActive(true);
                }
                else
                {
                    PlayerLeftEngineHurt.SetActive(true);
                }
            }
        }
    }

    public void PutShieldOn()
    {
        IsShieldOn = true;
        //PnnPlayerShield = Instantiate(PlayerShieldPrefab, transform.position, Quaternion.identity);
        PlayerShieldChild.SetActive(true);
    }
}