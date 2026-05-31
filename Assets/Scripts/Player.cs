using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 20f;
    private float rotationSpeed = 50f;
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
            animator.SetBool("IdleToRunForward", true);
            animator.SetBool("IdleToRunBackward",false);
            animator.SetBool("RunForwardToIdle",false);
            animator.SetBool("RunBackwardToIdle",false);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        else if(verticalInput == -1f)
        {
            animator.SetBool("IdleToRunForward", false);
            animator.SetBool("IdleToRunBackward",true);
            animator.SetBool("RunForwardToIdle",false);
            animator.SetBool("RunBackwardToIdle",false);
            transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
        }
        else
        {
            animator.SetBool("IdleToRunBackward",false);
            animator.SetBool("IdleToRunForward", false);
            animator.SetBool("RunForwardToIdle", true);
            animator.SetBool("RunBackwardToIdle",true);
        }


        // animator.SetBool("IdleToRun",false);

        transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);
    }

    void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
    }
}
