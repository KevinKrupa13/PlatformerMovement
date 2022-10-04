using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    
    private float timeBtwAtt;
    private float startTimeBtwAtt = 1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (timeBtwAtt <= 0) {
            timeBtwAtt = startTimeBtwAtt;

            if (Input.GetKey(KeyCode.Mouse0)) {
                print("Good");
            }

        } else {
            timeBtwAtt -= Time.deltaTime;
        }
    }
}
