using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; // Para poder reiniciar el juego cuando muere el pajaro.
using UnityEngine.UI; // Para poder usar la UI (User Interface)

public class pajaroZombie : MonoBehaviour {

    [SerializeField] ParticleSystem prefabExplosion;
    [SerializeField] Text marcadorPuntos;
    [SerializeField] float fuerza = 3f;
    private Rigidbody rb;
    private int puntos = 0;

	void Start ()
    {
        GameConfig.ArrancaJuego();
        // Asignamos el Rigibody al principio.
        rb = GetComponent<Rigidbody>();
        ActualizarMarcador();
    }

    void Update () {
        if (Input.GetKeyDown("space") || Input.GetKeyDown("up"))
        {
            Debug.Log("Has pulsado espacio");
            rb.AddForce(Vector3.up * fuerza);
        }
	}
    private void OnTriggerEnter(Collider other) // Detecta cuando el pajaro "colisiona" con el collider invisible.
    {
        puntos++;
        ActualizarMarcador();
    }

    // Colision del pajaro contra una tubería
    private void OnCollisionEnter(Collision collision)
    {
        // DETENER EL JUEGO
        GameConfig.ParaJuego();

        // CREAR EL SISTEMA DE PARTICULAS
        Instantiate(prefabExplosion, transform.position, Quaternion.identity);

        // DESACTIVAR EL RENDER
        gameObject.SetActive(false);

        // LLAMAR A FINALIZAR PARTIDA
        Invoke("FinalizarPartida", 3);
    }

    private void FinalizarPartida()
    {
        Destroy(this.gameObject);
        SceneManager.LoadScene(0);
    }

    private void ActualizarMarcador()
    {
        marcadorPuntos.text ="Score: " + puntos.ToString();
    }
}
