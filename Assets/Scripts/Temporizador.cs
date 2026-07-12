using UnityEngine;
using TMPro;

public class Temporizador : MonoBehaviour
{
    public TextMeshProUGUI textoTiempo;
    public float TiempoLimite = 300f;
    public float tiempoTranscurrido = 0f;
    public bool Aumentando = true;

    void Start()
    {
        
    }

   
    void Update()
    {

        if (!Aumentando) return;

        tiempoTranscurrido += Time.deltaTime;

        if (tiempoTranscurrido >= TiempoLimite)
        {
            tiempoTranscurrido = TiempoLimite;
            Aumentando = false;
            Debug.Log("Has ganado");
        }

        ActualizarTexto();
    }

    public void ActualizarTexto()
    {
        int minutos = Mathf.FloorToInt(tiempoTranscurrido / 60f);
        int segundos = Mathf.FloorToInt(tiempoTranscurrido % 60f);
        textoTiempo.text = string.Format("{0:00}:{1:00}", minutos, segundos);
    }

}
