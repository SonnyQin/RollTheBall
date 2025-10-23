using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMoveControl : MonoBehaviour
{
    Rigidbody rb;
    private int count;
    Vector2 movementVector;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
    }

    void OnMove(InputValue movementValue)
    {
        movementVector = movementValue.Get<Vector2>();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            count++;
        }
    }

    // Update is called once per frame
    // void Update()
    // {
    //     Debug.Log();
    // }

    void FixedUpdate()
    {
        float xforce = movementVector.x;
        float yforce = movementVector.y;
        Vector3 xzforce = new Vector3(xforce, 0, yforce);
        rb.AddForce(xzforce);
    }
}
