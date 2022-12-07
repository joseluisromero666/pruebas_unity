using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    // private Rigidbody rb;
    //  public float speed;
    public Transform particulas;

    private ParticleSystem sistemaParticulas;

    private Vector3 posicion;

    public int recolector = 0;

    private AudioSource audioRecoleccion;

    public Text textoContador;

    public Text textoGanador;

    public GameObject CuboMovible;

    public GameObject[] cuboDesaparecer;

    // Start is called before the first frame update
    void Update()
    {
    }

    void Start()
    {
        // rb = GetComponent<Rigidbody>();
        sistemaParticulas = particulas.GetComponent<ParticleSystem>();
        sistemaParticulas.Stop();
        audioRecoleccion = GetComponent<AudioSource>();

        // textoContador.text = "Contador : " + recolector.ToString();
        StartCoroutine("Movimiento");
        cuboDesaparecer = GameObject.FindGameObjectsWithTag("Recolectable");
        StartCoroutine("Desaparecer");
        StartCoroutine("Nuevo");
    }

    private void FixedUpdate()
    {
        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");
        Vector3 movimiento = new Vector3(moveHorizontal, 0.0f, moveVertical);
        // rb.AddForce(movimiento * speed);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Recolectable"))
        {
            posicion = other.gameObject.transform.position;
            particulas.position = posicion;
            sistemaParticulas = particulas.GetComponent<ParticleSystem>();
            sistemaParticulas.Play();

            other.gameObject.SetActive(false);
            StartCoroutine(DetenerParticulas(sistemaParticulas));

            //  Destroy(other.gameObject);
            recolector += 1;
            if (recolector == 12)
            {
                textoGanador.text = "¡Nivel Completado!";
                SceneManager.LoadScene(1);
            }
            else
            {
                Debug.Log (recolector);
                audioRecoleccion.Play();
                textoContador.text = "Contador : " + recolector.ToString();
            }
        }
    }

    public IEnumerator DetenerParticulas(ParticleSystem part)
    {
        yield return new WaitForSecondsRealtime(5);
        part.Stop();
    }

    public IEnumerator Movimiento()
    {
        for (; ; )
        {
            if (
                Vector3
                    .Distance(transform.position,
                    CuboMovible.transform.position) <
                6f
            )
            {
                CuboMovible.transform.position =
                    Vector3
                        .Lerp(CuboMovible.transform.position,
                        new Vector3(Random.Range(-10.0f, 10.0f),
                            0.97f,
                            Random.Range(-10.0f, 10.0f)),
                        10f * Time.deltaTime);
            }
            yield return new WaitForSecondsRealtime(0.01f);
        }
    }

    public IEnumerator Desaparecer()
    {
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(10);
            cuboDesaparecer[12].gameObject.SetActive(false);
        }
    }

    public IEnumerator Nuevo()
    {
        int contador = 0;
        for (; ; )
        {
            yield return new WaitForSecondsRealtime(3);
            cuboDesaparecer[13].gameObject.SetActive(false);
            yield return new WaitForSecondsRealtime(5);
            cuboDesaparecer[13].gameObject.SetActive(true);
            if (contador == 0)
            {
                cuboDesaparecer[13].GetComponent<Renderer>().material.color =
                    Color.green;
            }
            if (contador == 1)
            {
                cuboDesaparecer[13].GetComponent<Renderer>().material.color =
                    Color.black;
            }
            if (contador == 2)
            {
                cuboDesaparecer[13].GetComponent<Renderer>().material.color =
                    Color.red;
            }
            if (contador == 3)
            {
                cuboDesaparecer[13].GetComponent<Renderer>().material.color =
                    Color.white;
            }
            if (contador == 4)
            {
                cuboDesaparecer[13].GetComponent<Renderer>().material.color =
                    Color.blue;
            }

            contador += 1;
            if (contador == 5)
            {
                contador = 0;
            }
        }
    }
}
