using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int stageIndex;
    public int maxTeleportCount=3;
    public GameObject[] Stages;

    public Text UIteleportCount;

    // Start is called before the first frame update
    public void NextStage()
    {

        // Change Stage
        if (stageIndex < Stages.Length - 1)
        {
            Debug.Log("스 끝");
            Stages[stageIndex].SetActive(false);
            stageIndex++;
            Stages[stageIndex].SetActive(true);
        }

     

        
            
    }


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Playeraction.teleportCount < maxTeleportCount || Playeraction.teleportCount > 0)
        {
            UIteleportCount.text = "남은 텔포 횟수 : " + (Playeraction.teleportCount);
        }

        else if (Playeraction.teleportCount < 0)
        {
            UIteleportCount.text = "텔레포트 가능 횟수를 모두 소진하셨습니다";
        }
    }
}
