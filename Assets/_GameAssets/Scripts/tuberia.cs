using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuberia : MonoBehaviour {

    [SerializeField] int speed = 3;
    [SerializeField] float limiteInferior = -2f;
    [SerializeField] float limiteSuperior = 2f;
    [SerializeField] float distanciaDestruccion = 13f;

    void Start () {
        float factorPosicion = Random.Range(limiteInferior, limiteSuperior);
        this.transform.position = new Vector3(transform.position.x, 
            transform.position.y + factorPosicion, 
            transform.position.z);
	}
	
	void Update () {
        if (GameConfig.IsPlaying())
        {
            transform.Translate(Vector3.right * Time.deltaTime * speed);
            if (transform.position.x > distanciaDestruccion)
            {
                Destroy(this.gameObject);
            }
        } 
	}
}
