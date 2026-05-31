using UnityEngine;

public class Player : MonoBehaviour
{
    private float speed = 20f;
    private float rotationSpeed = 50f;
    private Animator animator;
    private int health = 100;
    // public int Health
    // {
    //     get{return health;}
    //     set{health = value;}
    // }

    public int GetHealth()
    {
        return health;
    }
    public void TakeDamage(int damage)
    {
        if (health > damage)
        {
            health = health - damage;
        }
        else
        {
            health = 0;
        }
    }

    public void Heal(int amount)
    {
        if (health + amount > 100)
        {
            health = 100;
        }
        else
        {
            health = health + amount;
        }
    }
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health != 0)
        {
            Vector3 pos = transform.position;
            if (pos.x < -9)
            {
                pos.x = -9;
            }
            if(pos.x > 9)
            {
                pos.x = 9;
            }
            transform.position = pos;
            float horizontalInput = Input.GetAxis("Horizontal");
            float verticalInput = Input.GetAxis("Vertical");
            // animator.SetBool("ClearUpper",true);
            if (verticalInput == 1f)
            {
                animator.SetBool("IdleToRunForward", true);
                animator.SetBool("IdleToRunBackward", false);
                animator.SetBool("RunForwardToIdle", false);
                animator.SetBool("RunBackwardToIdle", false);
                transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            }
            else if (verticalInput == -1f)
            {
                animator.SetBool("IdleToRunForward", false);
                animator.SetBool("IdleToRunBackward", true);
                animator.SetBool("RunForwardToIdle", false);
                animator.SetBool("RunBackwardToIdle", false);
                transform.Translate(Vector3.forward * Time.deltaTime * speed * verticalInput);
            }
            else
            {
                animator.SetBool("IdleToRunBackward", false);
                animator.SetBool("IdleToRunForward", false);
                animator.SetBool("RunForwardToIdle", true);
                animator.SetBool("RunBackwardToIdle", true);
            }
            transform.Rotate(Vector3.up * Time.deltaTime * rotationSpeed * horizontalInput);

        }

        if (health == 0)
        {
            Destroy(gameObject);
        }
        // animator.SetBool("IdleToRun",false);

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Damage1"))
        {
            TakeDamage(10);
        }
        if (other.gameObject.CompareTag("Damage2"))
        {
            TakeDamage(8);
        }
        if (other.gameObject.CompareTag("Damage3"))
        {
            TakeDamage(14);
        }
        if (other.gameObject.CompareTag("Damage4"))
        {
            TakeDamage(12);
        }
        if (other.gameObject.CompareTag("Damage5"))
        {
            TakeDamage(6);
        }
        if (other.gameObject.CompareTag("Heal"))
        {
            Heal(10);
        }
        Destroy(other.gameObject);
    }
}
