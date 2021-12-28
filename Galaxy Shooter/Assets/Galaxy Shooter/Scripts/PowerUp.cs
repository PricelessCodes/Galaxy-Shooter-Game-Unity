using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    [SerializeField]
    private float PowerUpSpeed = 3.0f;
    [SerializeField]
    private int PowerUpID; // 0 -> TripleShot --- 1 -> SpeedUp --- 2 -> Shield

    [SerializeField]
    private AudioClip PowerUpsAudioSource;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        transform.Translate(Vector3.down * PowerUpSpeed * Time.deltaTime);

        if (transform.position.y < -7.0f)
        {
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if ( other.tag == "Player" )
        {
            //access to player
            Player P = other.GetComponent<Player>();

            //Check if it is the right player and not equal null
            if ( P != null )
            {
                //Enable TripleShot
                if (PowerUpID == 0)
                {
                    P.TripleShotPowerUpOn();
                }
                //Enable SpeedUp
                else if (PowerUpID == 1)
                {
                    P.SpeedUpPowerUpOn();
                }
                //Enable Shield
                else if (PowerUpID == 2)
                {
                    P.PutShieldOn();
                }
            }
            AudioSource.PlayClipAtPoint(PowerUpsAudioSource, Camera.main.transform.position);
            //Destroy The TripleShot PowerUp GameObject
            Destroy(this.gameObject);
        }
    }
}
