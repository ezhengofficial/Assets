using UnityEngine;
using UnityEngine.Events;

public class MoveField : MonoBehaviour
{
    private Rigidbody2D body;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey("d")) {
            transform.position = new Vector3(-3, 0, 0);
        }
        if (Input.GetKey("a")) {
            transform.position = new Vector3(3, 0, 0);
        }
        if (Input.GetKey("s")) {
            transform.position = new Vector3(0, 3, 0);
        }
        if (Input.GetKey("w")) {
            transform.position = new Vector3(0, -3, 0);
        }
    }
}
