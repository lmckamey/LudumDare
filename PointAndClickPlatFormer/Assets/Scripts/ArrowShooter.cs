using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowShooter : MonoBehaviour
{
    [SerializeField] GameObject Arrows;

    float timer = 2.0f;
    float time = 0.0f;

    void Update()
    {
        time += Time.deltaTime;

        if(time >= timer)
        {
            Destroy(Instantiate(Arrows, transform), 3.0f);
            gameObject.GetComponent<AudioSource>().Play();
            time = 0.0f;
        }
    }
}
