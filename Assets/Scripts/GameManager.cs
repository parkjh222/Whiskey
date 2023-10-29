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

//    //시간 제한
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

//        //시간 제한
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

//            //추가 코드
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

//            //추가 코드
//            if (timeCnt != null)
//            {
//                timeCnt.isTimeOver = true; //시간 카운트 중지
//            }
//        }
//        else if (PlayerMovementController.gameState == "playing")
//        {
//            GameObject player = GameObject.FindGameObjectWithTag("Player");
//           PlayerMovementController playerCnt = player.GetComponent<PlayerMovementController>();
//            //시간 제한 추가
//            if (timeCnt != null)
//            {
//                if (timeCnt.gameTime > 0.0f)
//                {
//                    int time = (int)timeCnt.displayTime;
//                    timeText.GetComponent<Text>().text = time.ToString();
//                    if (time == 0)
//                    {
//                        playerCnt.GameOver(); //게임 오버 함수 필요
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
