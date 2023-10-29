using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class CooldownTime : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textInfo;
    [SerializeField]
    private TextMeshProUGUI textCooldownTime;
    [SerializeField]
    private Image imageCooldownTime;
    [SerializeField]
    private string skillName;
    [SerializeField]
    private float maxCooldownTime;

    private float currentCooldownTime;
    private bool isCooldown;

    // Start is called before the first frame update
    private void Awake()
    {
        SetCooldownIs(false);   
    }

    public void StartCooldownTime()
    {
        if(isCooldown == true)
        {
            textInfo.text = $"{skillName} CooldownTime : {currentCooldownTime.ToString("F1")}";
        }

        textInfo.text = $"Use Skill : {skillName}";
        StartCoroutine("OnCooldownTime", maxCooldownTime);
    }

    private IEnumerator OnCooldownTime(float maxCooldownTime)
    {
        currentCooldownTime = maxCooldownTime;

        SetCooldownIs(true);

        while(currentCooldownTime > 0)
        {
            currentCooldownTime -= Time.deltaTime;
            imageCooldownTime.fillAmount = currentCooldownTime / maxCooldownTime;
            textCooldownTime.text = currentCooldownTime.ToString("F1");

            yield return null;
        }
        SetCooldownIs(false);
    }

    private void SetCooldownIs(bool boolean)
    {
        isCooldown = boolean;
        textCooldownTime.enabled = boolean;
        imageCooldownTime.enabled = boolean;
    }
}
