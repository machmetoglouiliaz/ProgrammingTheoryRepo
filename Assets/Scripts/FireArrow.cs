using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireArrow : Arrow //INHERITANCE
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        LookToMovementDirection(); //ABSTRACTION
    }

    //POLYMORPHISM
    public override void HitTarget(Collider other)
    {
        base.HitTarget(other); //INHERITANCE
        StartCoroutine(DamageOverTime(other));
    }

    private IEnumerator DamageOverTime(Collider other)
    {
        float timer = 0;
        while(timer < 4)
        {
            yield return new WaitForSeconds(1);
            other.GetComponent<TargetHandler>().DamageTarget(-15);
            timer += 1;
            
        }
        

    }
}
