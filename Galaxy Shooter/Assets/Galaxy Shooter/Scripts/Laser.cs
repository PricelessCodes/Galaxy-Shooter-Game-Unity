using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    [SerializeField]    
    public float SpeedUp = 10.0f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        
        transform.Translate(Vector3.up * SpeedUp * Time.deltaTime);

        if (transform.position.y >= 6.0f)
        {
            if (transform.parent != null)
            {
                Destroy(transform.parent.gameObject);
            }
            Destroy(this.gameObject);
        }
    }

    public void DestroyLaser()
    {
        //Ask doctor ahmed
        if ( transform.parent != null && transform.parent.childCount == 1 )
        {
            Destroy(transform.parent);
        }
        Destroy(this.gameObject);  
    }
}
