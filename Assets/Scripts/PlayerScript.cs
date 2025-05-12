using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public Rigidbody myrigidbody;
    public float moveSpeed = 5f;
    public float flapStrength = 7f;
    public int target = 10;
    public logicscript logic; // Reference to the logic script

    void Start()
    {
        // Find and assign the logic script if not set in Inspector
        if (logic == null)
        {
            GameObject logicObject = GameObject.FindGameObjectWithTag("Logic");
            if (logicObject != null)
            {
                logic = logicObject.GetComponent<logicscript>();
            }
            else
            {
                Debug.LogWarning("No Logic object found with 'Logic' tag. Please assign the logicscript manually.");
            }
        }
    }

    void Update()
    {
        HandleMovement();
        HandleFlap();

        if (logic.playerscore >= 10)
        {
            logic.nextlevel();
        }
    }

    void HandleMovement()
    {
        float moveX = Input.GetAxis("Horizontal"); // A/D or Left/Right
        float moveZ = Input.GetAxis("Vertical");   // W/S or Up/Down

        Vector3 currentVelocity = myrigidbody.velocity;
        Vector3 moveVector = new Vector3(moveX, 0f, moveZ) * moveSpeed;

        myrigidbody.velocity = new Vector3(moveVector.x, currentVelocity.y, moveVector.z);
    }

    void HandleFlap()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Vector3 velocity = myrigidbody.velocity;
            velocity.y = flapStrength;
            myrigidbody.velocity = velocity;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Apple") || other.CompareTag("Banana"))
        {
            logic.addscore(1);
            logic.pointplay();
            Destroy(other.gameObject);
            Debug.Log(other.gameObject.name + " collected!");
        }
    }
}
