using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBob : MonoBehaviour
{
    [SerializeField] float frequency;
    [SerializeField] float bopStrength;
    // Start is called before the first frame update
    float startBob;

    void Start()
    {
        startBob = Random.Range(0f, 10f);
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(-90 + Mathf.Sin((Time.time) * frequency) * bopStrength * Time.deltaTime, 90, 90);
    }
}
