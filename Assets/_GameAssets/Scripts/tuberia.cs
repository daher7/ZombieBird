using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberia : MonoBehaviour {

    [SerializeField] int speed = 3;

    void Start () {
        float factorPosicion = Random.Range(-2, 2);
        this.transform.position = new Vector3(transform.position.x, 
            transform.position.y + factorPosicion, 
            transform.position.z);
	}
	
	void Update () {
        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x > 13)
            {
                Destroy(this.gameObject);
            }
        } 
	}
}
