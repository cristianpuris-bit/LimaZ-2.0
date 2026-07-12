using UnityEngine;

public class Barricada : MonoBehaviour
{
    public float Health = 100f;
    public bool destruida = false;
    void Start()
    {
        
    }

    public void RecibirDaño(float damage)
    {
        if (destruida) return;

        Health -= damage;
        Debug.Log("Barricada recibió daño: " + damage + " | Vida restante: " + Health);


        if (Health <= 0)
        {
            DestruirBarricada();
        }

    }
    void DestruirBarricada()
    {
        destruida = true;


        Debug.Log("Barricada destruida");
        Destroy(gameObject); 
    }
}
