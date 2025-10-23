using UnityEngine;
using UnityEngine.InputSystem;
using TMPro;

public class PlayerMoveControl : MonoBehaviour
{
    private Rigidbody rb;
    private int count;
    private Vector2 movementVector;

    public TextMeshProUGUI countText;
    public GameObject winTextObject;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        count = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }

    void SetCountText() 
    {
        countText.text = "Count: " + count.ToString();

        if (count >= 12)
        {
            winTextObject.SetActive(true);
        }
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
            SetCountText();
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
