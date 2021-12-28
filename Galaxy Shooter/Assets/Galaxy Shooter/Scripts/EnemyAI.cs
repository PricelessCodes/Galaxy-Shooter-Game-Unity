using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //[SerializeField]
    //private float HorizontalSpeed =3.0f ;
    [SerializeField]
    private float VerticalSpeed = 3.0f;
    [SerializeField]
    private float HorizontalPosition;
    [SerializeField]
    private GameObject EnemyExplosionPrefab;

    private UIManager ManageUI;

    private int EnemyScore = 10;

    [SerializeField]
    private AudioClip EnemyExplosionAudioSource;

    // Use this for initialization
    void Start ()
    {
        HorizontalPosition = Random.Range(-7.5f, 7.5f);
        transform.position = new Vector3(HorizontalPosition, 7.0f, 0);

        ManageUI = GameObject.Find("Canvas").GetComponent<UIManager>();
    }
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * VerticalSpeed * Time.deltaTime);

        if (transform.position.y < -7.0f)
        {
            HorizontalPosition = Random.Range(-7.5f, 7.5f);
            transform.position = new Vector3(HorizontalPosition, 7.0f, 0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            //access to player
            Player P = other.GetComponent<Player>();
            //Check if it is the right player and not equal null
            if (P != null)
            {
                P.DestroyPlayer();
                Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(EnemyExplosionAudioSource, Camera.main.transform.position);
                if (ManageUI != null)
                {
                    ManageUI.UpdateScore(EnemyScore);
                }
                Destroy(this.gameObject);
            }
        }

        if (other.tag == "laser")
        {
            //access to laser
            Laser L = other.GetComponent<Laser>();
            //Check if it is the right laser and not equal null
            if (L != null)
            {
                L.DestroyLaser();
                Instantiate(EnemyExplosionPrefab, transform.position, Quaternion.identity);
                AudioSource.PlayClipAtPoint(EnemyExplosionAudioSource, Camera.main.transform.position);
                if (ManageUI != null)
                {
                    ManageUI.UpdateScore(EnemyScore);
                }
                Destroy(this.gameObject);
            }
        }
    }
}
