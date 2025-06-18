using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    [SerializeField] float speed;
    Rigidbody2D rb;
    Animator anim;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxisRaw("Horizontal");
        float y = Input.GetAxisRaw("Vertical");

        rb.linearVelocity = new Vector2(x, y) * speed * Time.deltaTime;
        if (x == 0 && y == 0)
        {
            anim.SetBool("IsMove", false);
        }
        else
        {
            anim.SetBool("IsMove", true);
        }
        anim.SetFloat("xDir", x);
        anim.SetFloat("yDir", y);
    }
}
