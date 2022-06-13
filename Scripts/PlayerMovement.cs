using UnityEngine;
using UnityEngine.Events;

public class PlayerMovement : MonoBehaviour
{   
    [SerializeField] private float speed;
    private float movehorizontal; 
    private float movevertical; 
    private Rigidbody2D body;
    private bool movement;
    private bool efffected;
    
    private void Start() 
    {
        body = GetComponent<Rigidbody2D>();
        movement = true;
        FindObjectOfType<GameManager>().gameTime = 30;
    }
    
    public void move() 
    {
        body.AddForce(new Vector2(movehorizontal * speed * 15f, 0f), ForceMode2D.Impulse);
        body.AddForce(new Vector2(0f, movevertical * speed * 15f), ForceMode2D.Impulse);
        movement = false;
    }

    private void Update()
    {
        if (movement == true) {
            movehorizontal = Input.GetAxisRaw("Horizontal");
            movevertical = Input.GetAxisRaw("Vertical");
            if (Input.GetKey("d")) {
                transform.position = new Vector3(-5, 0, 0);
                move();
                FindObjectOfType<GameManager>().timeStop = true;
            }
            if (Input.GetKey("a")) {
                transform.position = new Vector3(5, 0, 0);
                move();
                FindObjectOfType<GameManager>().timeStop = true;
            }
            if (Input.GetKey("s")) {
                transform.position = new Vector3(0, 5, 0);
                move();
                FindObjectOfType<GameManager>().timeStop = true;
            }
            if (Input.GetKey("w")) {
                transform.position = new Vector3(0, -5, 0);
                move();
                FindObjectOfType<GameManager>().timeStop = true;
            }
            
        }
        if (Input.GetKey("p")) {
            movement = true;
        }
    }

    private void FixedUpdate()
    {
        float maxVelocity = 10f;
        body.velocity = Vector2.ClampMagnitude(body.velocity, maxVelocity);
    }

    private void OnTriggerStay2D(Collider2D collision) 
    {
        if(collision.gameObject.tag == "xField") 
        {
            Debug.Log("detected field");
            float velx = body.velocity.x;
            float vely = body.velocity.y;
            body.AddForce(new Vector2(0f,velx * speed * 0.1135f), ForceMode2D.Impulse);
            body.AddForce(new Vector2(vely * speed * -0.1135f,0f), ForceMode2D.Impulse);
            
        }

        if(collision.gameObject.tag == "oField") 
        {
            Debug.Log("detected field");
            float velx = body.velocity.x;
            float vely = body.velocity.y;
            body.AddForce(new Vector2(0f,velx * speed * -0.1135f), ForceMode2D.Impulse);
            body.AddForce(new Vector2(vely * speed * 0.1135f,0f), ForceMode2D.Impulse);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.gameObject.tag == "goal") {
            Debug.Log("detected goal");
            GameObject.Find("Score").GetComponent<ScoreScript>().Score();
            body.velocity = new Vector2(0f, 0f);
            transform.position = new Vector3(0, 11, 0);
            movement = true;  
            if (GameObject.Find("Score").GetComponent<ScoreScript>().score <= 1400) {
                FindObjectOfType<GameManager>().gameTime = 15 - GameObject.Find("Score").GetComponent<ScoreScript>().score/100;
            }
            else {
                FindObjectOfType<GameManager>().gameTime = 1;
            }
            FindObjectOfType<GameManager>().SetGameTime();
            FindObjectOfType<GameManager>().timeStop = false;
        }
        
        if(collision.gameObject.tag == "wall") {
            Debug.Log("detected wall");
            FindObjectOfType<GameManager>().EndGame();
        }
    }

}
