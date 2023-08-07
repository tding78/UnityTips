using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    [SerializeField]
    private float speed = 7f;
    [SerializeField]
    private float jumpForce = 7f;
    [SerializeField]
    private GameObject bulletPrefab;
    [SerializeField]
    private Transform launchOffset;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // 水平移动
        float dirX = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(dirX * speed, rb.velocity.y);

        // 选装人物方向
        if (!Mathf.Approximately(0, dirX))
        {
            transform.rotation = dirX < 0 ? Quaternion.Euler(0, 180, 0) : Quaternion.identity;
        }

        // 跳跃
        if (Input.GetButtonDown("Jump") && Mathf.Abs(rb.velocity.y) < 0.001f)
        {
            rb.AddForce(new Vector2(0, jumpForce), ForceMode2D.Impulse);
        }

        if (Input.GetButtonDown("Fire1"))
        {
            Instantiate(bulletPrefab, launchOffset.position, transform.rotation);
        }
    }
}
