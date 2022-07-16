using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TargetHandler : MonoBehaviour 
{
    [SerializeField] private Camera mainCamera;
    [SerializeField] private TextMeshProUGUI damageText;
    [SerializeField] private Transform damageTextWorldPosition;

    public int overallDamage { get; private set; } // ENCAPSULATION
    private Vector3 dmgFadeOutOffset = new Vector3(0, 2, 0);

    // Start is called before the first frame update
    void Start()
    {
        overallDamage = 0;

        damageText.color = new Color(damageText.color.r, damageText.color.g, damageText.color.b, 0);
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

        Vector3 dmgTextLocation = mainCamera.WorldToScreenPoint(damageTextWorldPosition.position);
        Vector3 dmgTextFadeOutLocation = mainCamera.WorldToScreenPoint(damageTextWorldPosition.position + dmgFadeOutOffset);

        while (timer < 1)
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
