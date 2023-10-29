//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;
//using UnityEngine.UI;

//public class GameManager : MonoBehaviour
//{
//    [SerializeField]
//    private GameObject mainImage;
//    [SerializeField]
//    private Sprite gameOverSpr;
//    [SerializeField]
//    private Sprite gameClearSpr;
//    [SerializeField]
//    private GameObject panel;
//    [SerializeField]
//    private GameObject restartButton;
//    [SerializeField]
//    private GameObject nextButton;

//    //�ð� ����
//    [SerializeField]
//    private GameObject timeBar;
//    [SerializeField]
//    private GameObject timeText;
//    TimeController timeCnt;

//    // Start is called before the first frame update
//    private void Awake()
//    {
//        Invoke("InactiveImage", 1.0f);
//        panel.SetActive(false);

//        //�ð� ����
//        timeCnt = GetComponent<TimeController>();
//        if (timeCnt != null)
//        {
//            if (timeCnt.gameTime == 0.0f)
//            {
//                timeBar.SetActive(false);
//            }
//        }
//    }

//    // Update is called once per frame
//    private void Update()
//    {
//        if (PlayerMovementController.gameState == "gameclear")
//        {
//            mainImage.SetActive(true);
//            panel.SetActive(true);
//            Button bt = restartButton.GetComponent<Button>();
//            bt.interactable = false;
//            mainImage.GetComponent<Image>().sprite = gameClearSpr;
//           PlayerMovementController.gameState = "gameend";

//            //�߰� �ڵ�
//            if (timeCnt != null)
//            {
//                timeCnt.isTimeOver = true;
//            }
//        }
//        else if (PlayerMovementController.gameState == "gameover")
//        {
//            mainImage.SetActive(true);
//            panel.SetActive(true);
//            Button bt = nextButton.GetComponent<Button>();
//            bt.interactable = false;
//            mainImage.GetComponent<Image>().sprite = gameOverSpr;
//           PlayerMovementController.gameState = "gameend";

//            //�߰� �ڵ�
//            if (timeCnt != null)
//            {
//                timeCnt.isTimeOver = true; //�ð� ī��Ʈ ����
//            }
//        }
//        else if (PlayerMovementController.gameState == "playing")
//        {
//            GameObject player = GameObject.FindGameObjectWithTag("Player");
//           PlayerMovementController playerCnt = player.GetComponent<PlayerMovementController>();
//            //�ð� ���� �߰�
//            if (timeCnt != null)
//            {
//                if (timeCnt.gameTime > 0.0f)
//                {
//                    int time = (int)timeCnt.displayTime;
//                    timeText.GetComponent<Text>().text = time.ToString();
//                    if (time == 0)
//                    {
//                        playerCnt.GameOver(); //���� ���� �Լ� �ʿ�
//                    }
//                }

//            }
//            void InactiveImgae()
//            {
//                mainImage.SetActive(false);
//            }
//        }
//    }
//}
