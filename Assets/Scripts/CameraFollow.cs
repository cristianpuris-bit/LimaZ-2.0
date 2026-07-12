using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject target;
    public float CameraSpeed;
    public float CameraDistance;
    public float LimiteInferior;
    public float LimiteSuperior;
    public float LimiteIzquierdo;
    public float LimiteDerecho;
    public float Suavizado = 0.15f; 
    private Vector3 velocidadCamara = Vector3.zero;

    void Start()
    {
     
    }

    
    void Update()
    {
        CameraMovement();
    }
    public void CameraMovement()
    {
        if (target == null)
        {
            return;
        }

        Vector3 destino = new Vector3(target.transform.position.x, target.transform.position.y, transform.position.z);

        transform.position = Vector3.SmoothDamp(transform.position, destino, ref velocidadCamara, Suavizado);

        if   (transform.position.y < LimiteInferior)
        {
            transform.position = new Vector3 (transform.position.x, LimiteInferior, transform.position.z);
        }
        if (transform.position.y > LimiteSuperior )
        {
            transform.position = new Vector3(transform.position.x, LimiteSuperior, transform.position.z);
        }
        if (transform.position.x > LimiteDerecho)
        {
            transform.position = new Vector3(LimiteDerecho, transform.position.y, transform.position.z);
        }
        if (transform.position.x < LimiteIzquierdo)
        {
            transform.position = new Vector3(LimiteIzquierdo, transform.position.y, transform.position.z);
        }
    }





}
