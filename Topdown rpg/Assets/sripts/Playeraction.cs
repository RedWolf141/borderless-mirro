using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Playeraction : MonoBehaviour

{

    public GameManager gameManager;
    float hInput;
    float vInput;
    float timeSpan;  //경과 시간을 갖는 변수
    float checkTime;  // 특정 시간을 갖는 변수
    Vector3 playerDir; //플레이어가 바라보는 방향
    Vector2 MousePosition; // 마우스 위치
    public static int teleportCount=3; // 텔레포트 가능 횟수
    public Text UIstageEnd;

    bool isHorizontalMove;
 
    Rigidbody2D rigid;

    void Awake()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        
        Vector2 pos;
        pos = this.gameObject.transform.position;
        gameManager = (GameManager)FindObjectOfType(typeof(GameManager));
        

    }

    // Start is called before the first frame update
    void Update()
    {
        hInput = Input.GetAxisRaw("Horizontal");
        vInput = Input.GetAxisRaw("Vertical");


        // 플레이어의 이동 방향을 구함 상, 하, 좌,우 
        if (hInput == 0 && vInput != 0)
        {
            isHorizontalMove = false;
            if (vInput == 1)
                playerDir = Vector3.up;
            else if (vInput == -1)
                playerDir = Vector3.down;
        }
        else
        {
            isHorizontalMove = true;
            if (hInput == 1)
                playerDir = Vector3.right;
            else if (hInput == -1)
                playerDir = Vector3.left;
        }



            
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        rigid.velocity = new Vector2(hInput, vInput);

     
        if (Input.GetKeyDown(KeyCode.X))
        {

            if (teleportCount > 0)
            {
                //플레이어가 바라보는 방향으로 1만큼 이동
                transform.position = transform.position + (playerDir * 1.0f);
            }
            teleportCount--;

        }
       


        

    }

     void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            //gameManager.NextStage();
            Debug.Log("스테이지 끝");
            UIstageEnd.text = "스테이지 끝";
        }
    }


}



      
