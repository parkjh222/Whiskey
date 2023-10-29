using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DebugSkillInput : MonoBehaviour
{
    [SerializeField]
    private GraphicRaycaster graphicRaycaster;
    [SerializeField]
    private CooldownTime[] cooldownTime;

    private List<RaycastResult> raycastResults;
    private PointerEventData pointerEventData;
    // Start is called before the first frame update
    private void Awake()
    {
        raycastResults = new List<RaycastResult>();
        pointerEventData = new PointerEventData(null);
    }

    // Update is called once per frame
    void Update()
    {
        //1~9까지의 숫자를 눌러 스킬 시전
        for(int i = 0; i < cooldownTime.Length; ++i)
        {
            if(Input.GetKeyDown((i+1).ToString()))
            cooldownTime[i].StartCooldownTime();
        }
        if(raycastResults.Count > 0)
        {
            CooldownTime cool = raycastResults[0].gameObject.GetComponent<CooldownTime>() as CooldownTime;
            if(cool != null)
            {
                cool.StartCooldownTime();
            }
        }
    }

}
