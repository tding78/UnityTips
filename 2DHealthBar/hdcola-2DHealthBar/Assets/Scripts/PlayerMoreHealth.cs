using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoreHealth : MonoBehaviour
{
    private FloatingHealthBar healthBar;
    private float currentValue = 0f;

    // Start is called before the first frame update
    void Start()
    {
        healthBar = GetComponentInChildren<FloatingHealthBar>();
        healthBar.UpdateHealthBar(0, 100f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            currentValue += 5f;
            healthBar.UpdateHealthBar(currentValue, 100f);
            if (currentValue == 100) currentValue = -5f;
        }
    }
}
