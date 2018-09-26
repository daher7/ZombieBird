using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pipeGenerator : MonoBehaviour {
    [SerializeField] Transform prefabTuberia;

	// Use this for initialization
	void Start () {
        InvokeRepeating("GeneratePipe", 0, 1);
	}
	
	// Vamos a crear el script para generar tuberias de forma aleatoria
    void GeneratePipe()
    {
        // Generamos la tuberia
        if (GameConfig.IsPlaying())
        {
            Instantiate(prefabTuberia, transform.position, Quaternion.identity);
        }
    }
}
