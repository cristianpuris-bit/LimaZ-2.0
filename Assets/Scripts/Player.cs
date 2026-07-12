using UnityEngine;

public class Player : MonoBehaviour
{
    public float HorizontalMovement;
    public float VerticalMovement;
    public float Speed;
    public float Health;
    public float VidaMaxima;
    public Armas currentWeapon;
    public bool estaMuerto = false;
    public Vector2 direccionMirando = Vector2.down;

    public Animator anim;
    public bool moving;
    public PantallaMuerte pantallaMuerte;



    void Start()
    {
        anim.SetBool("Morir", false);

    }


    void Update()
    {
        MovementPlayer();
        Morir();
   




    }
    public void MovementPlayer()
    {
        Debug.Log("player try to move");


        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        if (estaMuerto) return;

        Vector3 dir = new Vector3(x, y, 0);
        dir.Normalize();
        if (dir.magnitude > 0.1f)
        {
            direccionMirando = new Vector2(x, y).normalized;
        }
        float i = transform.position.y;
        float e = transform.position.x;

        transform.position += dir * Speed * Time.deltaTime;

        if (dir.magnitude > 0.1f || dir.magnitude < -0.1f)
        {
            moving = true;
        }
        else
        {
            moving = false;
        }
        if (moving)
        {
            anim.SetFloat("X", x);
            anim.SetFloat("Y", y);

        }

        anim.SetBool("Moving", moving);
       
        if (currentWeapon.Hand == Armas.TiposDeArma.Melee)
        {
            if(Input.GetMouseButtonDown(0))
            {
                Vector3 posicionMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);
                float direccionX = (posicionMouse.x > transform.position.x) ? 1f : -1f;

                Debug.Log("Direccion X calculada: " + direccionX);

                anim.SetFloat("X", direccionX); // asegura que el Blend Tree tenga el valor correcto
                anim.SetTrigger("Atacar");
            }
        }
    }

    public void Morir()
    {    
        Debug.Log ("Player Health: " + Health);
        if (Health <= 0 && !estaMuerto)
        {
            estaMuerto = true;
            anim.SetTrigger("Morir");
            Debug.Log("Player is dead");


            Invoke(nameof(MostrarPantallaConDelay), 1.5f);

        }
    }
    void MostrarPantallaConDelay()
    {
        pantallaMuerte.MostrarPantallaMuerte();
        Time.timeScale = 0f; // pausar el juego
    }
}