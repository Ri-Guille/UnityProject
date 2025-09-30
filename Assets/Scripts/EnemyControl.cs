using UnityEngine;

public class EnemyControl : MonoBehaviour
{

    Rigidbody2D rb2d;
    private int minVelocity = 2;
    private int maxVelocity = 15;


    [SerializeField]
    private int MinForce = 50;
    [SerializeField]    private int MaxForce = 500;
    public int force = 45;

    [SerializeField]
    private int MinTorque = 50;
    [SerializeField]
    private int MaxTorque = 500;
    public int Torque = 45;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //nuevo vector
        int scale = Random.Range(1, 4);
        Transform tf = GetComponent<Transform>();

        //Rigidbody sirve para la simulacion fisica

        transform.localScale = new Vector3(scale, scale, 1);
        //Generamos una direccion random/aleatoria en el plano 2d.
        Vector2 direction = Random.insideUnitCircle;
        force = Random.Range(MinForce, MaxForce);

        Rigidbody2D rb2d = GetComponent<Rigidbody2D>();
        rb2d.AddForce(direction * force);

        Torque = Random.Range(MinTorque, MaxTorque);
        rb2d.AddTorque(Torque);

        limitVelocity();

    }


    // Update is called once per frame
    void Update()
    {

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
        throw new System.NotImplementedException();
    }
}
