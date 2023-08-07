using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMovement : MonoBehaviour
{
    public float speed = 10f;
    public float maxDistance = 10f;
    private Vector3 initialPosition;

    private void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
        CheckMaxDistance();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }

    private void CheckMaxDistance()
    {
        float currentDistance = Vector3.Distance(initialPosition, transform.position);
        if (currentDistance > maxDistance)
        {
            Destroy(gameObject);
        }
    }
}
