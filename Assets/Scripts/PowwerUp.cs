using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowwerUp : MonoBehaviour
{
    private void Start()
    {
        RandomizePosition();
    }
    private void RandomizePosition()
    {
        float x = Random.Range(Mathf.Round(-12), Mathf.Round(12));
        transform.position = new Vector3(x, -8, 0);
    }
}
