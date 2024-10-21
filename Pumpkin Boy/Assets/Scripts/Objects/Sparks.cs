using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sparks : MonoBehaviour
{
    [SerializeField] private float sparkLife = 0.75f;
    
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SparkDeath());
    }

    IEnumerator SparkDeath()
    {
        yield return new WaitForSeconds(sparkLife);
        Destroy(this.gameObject);
    }
}
