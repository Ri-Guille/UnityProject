using System;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Rendering;

public class PlayerControler : MonoBehaviour
{
    Rigidbody2D rb2d;

    [SerializeField]
    private GameObject explosion;

    [SerializeField]
    private int minVelocity = 1;

    [SerializeField]
    private float maxVelocity = 3;

    private int force = 20;

    private int score;
    private float timer = 0;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        explosion.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        timer = Time.deltaTime + timer;
        Debug.Log("El tiempo que a pasado es " + timer);

        if (Mouse.current.leftButton.isPressed)
        {
            //Posicion actual del jugador
            Vector3 position = transform.position;
            //Posicion actual del puntero
            Vector3 mousePosition = Mouse.current.position.value;
            // Hacemos una conversion de coordenadas
            Vector3 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            //Este calculo se quita la tecera componente z
            Vector2 direction = mouseWorldPosition - position;
            transform.up = direction;
            rb2d.AddForce(direction * force);
            limitVelocity();
            Debug.Log(Mouse.current.position.value);
        }

    }

    private void limitVelocity()
    {
        //Si la velocidad es mayor que
        //maxVelocity, 
        if (rb2d.linearVelocity.magnitude > maxVelocity) ;
        {
            //Si la velocidad actual es mayor que ",maxvelocity". la limitamos al maximo
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * maxVelocity;
        }
        if (rb2d.linearVelocity.magnitude < minVelocity) ;
        {
            //Si la velocidad actual es menor que "minvelocity". La limitamos al minimo
            rb2d.linearVelocity = rb2d.linearVelocity.normalized * minVelocity;

        }
        

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Cambiamos la posicion del objeto de la explosion a la del jugador
        explosion.transform.position = transform.position;
        explosion.SetActive(true);
        Destroy(gameObject);
    }
}
