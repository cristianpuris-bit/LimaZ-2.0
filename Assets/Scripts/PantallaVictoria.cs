using UnityEngine;
using UnityEngine.SceneManagement;


public class PantallaVictoria : MonoBehaviour
{
    public GameObject panelVictoria;
    public string nombreEscenaMenu = "Menu";

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void MostrarPantallaVictoria()
    {
        panelVictoria.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Reintentar()
    {
        Time.timeScale = 1f;
        Scene escenaActual = SceneManager.GetActiveScene();
        SceneManager.LoadScene(escenaActual.name);
    }

    public void IrAlMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(nombreEscenaMenu);
    }
}
