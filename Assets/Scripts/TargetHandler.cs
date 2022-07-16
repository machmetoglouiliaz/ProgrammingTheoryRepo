using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI damageText;

    private int overallDamage;
    private Vector3 dmgTextLocation = new Vector3(925, 38, 0);
    private Vector3 dmgTextFadeOutLocation = new Vector3(925, 128, 0);

    // Start is called before the first frame update
    void Start()
    {
        overallDamage = 0;

        Debug.Log(damageText.transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageTarget(int dmg)
    {
        overallDamage += dmg;

        damageText.text = "" + dmg;
        StartCoroutine(DamageTextAnimation());
    }

    private IEnumerator DamageTextAnimation()
    {
        Vector3 currentPosition;
        float currentTransparency;
        float timer = 0;
        Color textColor = damageText.color;
        while(timer < 1)
        {
            currentPosition =  Vector3.Lerp(dmgTextLocation, dmgTextFadeOutLocation, timer);
            currentTransparency = Mathf.Lerp(1, 0, timer);

            damageText.transform.position = currentPosition;
            damageText.color = new Color(textColor.r, textColor.g, textColor.b, currentTransparency);

            timer += Time.deltaTime;
            yield return new WaitForFixedUpdate();
        }
    }
}
