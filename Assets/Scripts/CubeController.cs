using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private bool isHoldingPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player") && !isHoldingPlayer)
        {
            isHoldingPlayer = true;
            StartCoroutine(HoldPlayerForSeconds(2.0f));
            Debug.Log("충돌");
        }
    }

    private IEnumerator HoldPlayerForSeconds(float seconds)
    {
        // 플레이어의 CharacterController를 가져오거나, 다른 이동 관련 컴포넌트를 참조해야 합니다.
        MovementCharacterController playerController = FindObjectOfType<MovementCharacterController>();

        if (playerController != null)
        {
            // 플레이어 이동 중지
            playerController.enabled = false;

            // 일정 시간 동안 대기
            yield return new WaitForSeconds(seconds);

            // 플레이어 이동 다시 활성화
            playerController.enabled = true;
        }

        isHoldingPlayer = false;
    }
}
