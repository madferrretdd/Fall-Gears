using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bobbingSpinning : MonoBehaviour
{
    public float power = 0.5f;
    public float frequency = 1f;
    public Vector3 rotationSpeed;

    Vector3 StartPos = new Vector3();
    Vector3 TempPos = new Vector3();

    // Start is called before the first frame update
    void Start()
    {
        StartPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        TempPos = StartPos;
        TempPos.y += Mathf.Sin(Time.fixedTime * Mathf.PI * frequency) * power;
        transform.position = TempPos;

        transform.Rotate(rotationSpeed * Time.deltaTime, Space.Self);
    }
}
