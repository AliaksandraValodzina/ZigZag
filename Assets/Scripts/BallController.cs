using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    public GameObject particle;

    [SerializeField]
    private float speed;
    bool isStarted;
    bool gameOver;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
        gameOver = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!isStarted)
        {
            if (Input.GetMouseButtonDown(0))
            {
                rigidbody.velocity = new Vector3(speed, 0, 0);
                isStarted = true;
                GameManager.instance.StartGame();
            }
        }

        Debug.DrawRay(transform.position, Vector3.down, Color.red);

        if (!Physics.Raycast(transform.position, Vector3.down, 1f))
        {
            gameOver = true;
            rigidbody.velocity = new Vector3(0, -25f, 0);

            Camera.main.GetComponent<CameraFollow>().gameOver = true;

            GameManager.instance.GameOver();
        }

        if (Input.GetMouseButtonDown(0) && !gameOver)
        {
            SwitchDirection();
        }
    }

    void SwitchDirection()
    {
        if(rigidbody.velocity.z > 0)
        {
            rigidbody.velocity = new Vector3(speed, 0, 0);
        } else if (rigidbody.velocity.x > 0)
        {
            rigidbody.velocity = new Vector3(0, 0, speed);
        }
    }

    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Diamond")
        {
            var part = Instantiate(particle, col.gameObject.transform.position, Quaternion.identity) as GameObject;
            Destroy(col.gameObject);
            Destroy(part, 1f);
        }
    }
}
