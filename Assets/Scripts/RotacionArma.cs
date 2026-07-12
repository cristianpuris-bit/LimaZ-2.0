
using UnityEngine;


public class RotacionArma : MonoBehaviour
{
    public Camera CamaraPrincipal;
    public Transform Cuy;
    public float Radio;

    void Start()
    {
        CamaraPrincipal = Camera.main;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Cuy == null)
        {
            return;
        }
        Apuntado();
        Giro();

    }
    public void Apuntado()
    {

        
        Vector3 posicionMouse = CamaraPrincipal.ScreenToWorldPoint(Input.mousePosition);
        posicionMouse.z = Cuy.position.z;

       
        Vector3 direccion = (posicionMouse - Cuy.position).normalized;

       
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;

        
        Vector3 nuevaPosicion = Cuy.position + direccion * Radio;
        transform.position = nuevaPosicion;

        
        transform.rotation = Quaternion.Euler(0, 0, angulo);
    }
    public void Giro()
    {
        Vector3 posicionMouse = CamaraPrincipal.ScreenToWorldPoint(Input.mousePosition);
        posicionMouse.z = transform.position.z;

        Vector3 direccion = posicionMouse - transform.position;
        float angulo = Mathf.Atan2(direccion.y, direccion.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(new Vector3(0, 0, angulo));

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (angulo > 90 || angulo < -90)
            sr.flipY = true;
        else
            sr.flipY = false;
    }
}
