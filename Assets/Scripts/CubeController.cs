using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; // Required when Using UI elements.

public class CubeController : MonoBehaviour
{
    Material material;

    public Slider mainSliderX;

    public Slider mainSliderY;

    public Slider mainSliderZ;

    public Slider mainSliderT;

    // Start is called before the first frame update
    void Start()
    {
        material = GetComponent<Renderer>().material;
        material.color = Color.green;
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void RotarCubo()
    {
        transform.Rotate(new Vector3(45, 45, 45));
    }

    public void EscalarCubo(float value)
    {
        transform.localScale = new Vector3(value, value, value);
    }

    public void CambiarColor(int opcion)
    {
        Debug.Log("Paramentro " + opcion);
        switch (opcion)
        {
            case 0:
                Debug.Log("Opcion 1");
                material.color = Color.green;
                break;
            case 1:
                Debug.Log("Opcion 2");
                material.color = Color.red;
                break;
            case 2:
                Debug.Log("Opcion 3");
                material.color = Color.yellow;
                break;
        }
    }

    public void CambiarX(float x)
    {
        transform.position =
            new Vector3(x, transform.position.y, transform.position.z);
    }

    public void CambiarY(float y)
    {
        transform.position =
            new Vector3(transform.position.x, y, transform.position.z);
    }

    public void CambiarZ(float z)
    {
        transform.position =
            new Vector3(transform.position.x, transform.position.y, z);
    }

    public void Reset()
    {
      //  Debug.Log(transform.rotation.x);
        transform.rotation = Quaternion.Euler(0, 0, 0);
        transform.position = new Vector3(0, 0, 0);
        transform.localScale = new Vector3(1, 1, 1);
        mainSliderX.value = 0;
        mainSliderY.value = 0;
        mainSliderZ.value = 0;
        mainSliderT.value = 1;
    }
    public void SalirAplicacion(){
        Debug.Log("Saliendo de La app");
        #if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying=false;
        #else
        Application.Quit();
        #endif
    }
}
