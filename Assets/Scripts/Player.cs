using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 10f;
    private float rotationSpeed = 10f;
    private Animator animator;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
        // animator.SetBool("ClearUpper",true);
        if (verticalInput == 1f)
        {
            animator.SetBool("IdleToRun", true);
            animator.SetBool("RunToIdle",false);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        else
        {
            animator.SetBool("IdleToRun", false);
            animator.SetBool("RunToIdle", true);
        }

        // animator.SetBool("IdleToRun",false);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
    }
}
