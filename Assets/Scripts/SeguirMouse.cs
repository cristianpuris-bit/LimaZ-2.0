using UnityEngine;

public class SeguirMouse : MonoBehaviour
{
    public Transform jugador; 
    public float distancia = 0.7f;

    private Camera CameraPrincipal;

    void Start()
    {
        CameraPrincipal = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 posicionMouse = CameraPrincipal.ScreenToWorldPoint(Input.mousePosition);
        posicionMouse.z = jugador.position.z;

        Vector3 direccion = (posicionMouse - jugador.position).normalized;

        transform.position = jugador.position + direccion * distancia;
    }
}
