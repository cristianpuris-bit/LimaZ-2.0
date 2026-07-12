using UnityEngine;

public class ColocarBarricada : MonoBehaviour
{
    public GameObject barricadaPrefab;
    public float distanciaColocacion = 1.5f;
    public int cantidadMaxima = 5;
    public float cooldown = 1f;

    private int barricadasActivas = 0;
    private float tiempoUltimaColocacion = -999f;

    private Player Movimiento; 
    void Start()
    {
        Movimiento = GetComponent<Player>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            SpawnBarricada();
        }
    }
    void SpawnBarricada()
    {
        if (Time.time - tiempoUltimaColocacion < cooldown)
        {
            Debug.Log("Barricada en cooldown");
            return;
        }

        if (barricadasActivas >= cantidadMaxima)
        {
            Debug.Log("Límite de barricadas alcanzado");
            return;
        }


        Vector3 direccion = new Vector3(Movimiento.direccionMirando.x, Movimiento.direccionMirando.y, 0);
        Vector3 posicion = transform.position + direccion * distanciaColocacion;

        GameObject nuevaBarricada = Instantiate(barricadaPrefab, posicion, Quaternion.identity);
        barricadasActivas++;
        tiempoUltimaColocacion = Time.time;

        
    }
}
