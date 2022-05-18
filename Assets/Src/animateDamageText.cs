using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class animateDamageText : MonoBehaviour
{
    [SerializeField]
    private float frequency;
    [SerializeField]
    private float width;
    [SerializeField]
    public float lifeSpan = 3;
    [SerializeField]
    private float riseRate = 0.1f;

    private float _secondsUntilExpiry;
    public float secondsUntilExpiry
    {
        set { _secondsUntilExpiry = value; }
    }
    private float SecondsSinceBirth;
    private float birthTime;

    void Start()
    {
        birthTime = Time.time;
        SecondsSinceBirth = 0;
    }

    // Update is called once per frame
    void Update()
    {
        SecondsSinceBirth += Time.deltaTime;
        Debug.Log(SecondsSinceBirth);
        if (SecondsSinceBirth > lifeSpan)
        {
            Debug.Log(SecondsSinceBirth + " greater than lifespan: " + lifeSpan);
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        Wiggle();
    }

    void Wiggle()
    {
        transform.Translate(Mathf.Sin(SecondsSinceBirth * frequency) * Vector2.right * width *  0.001f);
        transform.Translate(Vector2.up * riseRate);
    }
}
