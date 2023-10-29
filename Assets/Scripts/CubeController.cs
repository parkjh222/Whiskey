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
            Debug.Log("�浹");
        }
    }

    private IEnumerator HoldPlayerForSeconds(float seconds)
    {
        // �÷��̾��� CharacterController�� �������ų�, �ٸ� �̵� ���� ������Ʈ�� �����ؾ� �մϴ�.
        MovementCharacterController playerController = FindObjectOfType<MovementCharacterController>();

        if (playerController != null)
        {
            // �÷��̾� �̵� ����
            playerController.enabled = false;

            // ���� �ð� ���� ���
            yield return new WaitForSeconds(seconds);

            // �÷��̾� �̵� �ٽ� Ȱ��ȭ
            playerController.enabled = true;
        }

        isHoldingPlayer = false;
    }
}
