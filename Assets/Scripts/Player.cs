using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private float rotationSpeed = 10f;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        transform.Translate(Vector3.forward*Time.deltaTime*speed*verticalInput);
        transform.Rotate(Vector3.up*Time.deltaTime*speed*horizontalInput);
    }
}
