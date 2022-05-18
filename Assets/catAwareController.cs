using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class catAwareController : MonoBehaviour
{

    GameObject[] cats;

    [SerializeField]
    private float yShiftStart = 0.6f;
    [SerializeField]
    private float yShiftEnd = 1.3f;
    [SerializeField]
    private float minSize = 1;
    [SerializeField]
    private float maxSize = 1.45f;

    void Start()
    {
        cats = GameObject.FindGameObjectsWithTag("cat");
    }

    // Update is called once per frame
    void Update()
    {

        float lowestY = float.MaxValue;
        foreach (var cat in cats)
        {
            if (cat.transform.position.y < lowestY)
            {
                lowestY = cat.transform.position.y;
            }
        }

        if (lowestY < yShiftStart)
        {
            Camera.main.orthographicSize *= 1 / ( lowestY - yShiftStart);
        }
    }
}
