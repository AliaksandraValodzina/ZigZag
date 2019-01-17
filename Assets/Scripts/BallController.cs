using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallController : MonoBehaviour
{
    [SerializeField]
    private float speed;
    bool isStarted;
    Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }

    // Start is called before the first frame update
    void Start()
    {
        isStarted = false;
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
            }
        }

        if (Input.GetMouseButtonDown(0))
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
}
