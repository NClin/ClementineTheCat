using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class velocityDisplay : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D cat;
    private Text text;
    void Start()
    {
        text = GetComponent<Text>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        text.text = cat.velocity.magnitude.ToString();
    }
}
