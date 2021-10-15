using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuestReward : MonoBehaviour
{
    [Header("Quest reward")]
    public int rewardXP;
    public string[] rewarditems;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other){
        OpenQuestRewardScreen();
    }

    public void OpenQuestRewardScreen(){
        BattleReward.instance.OpenRewardScreen(rewardXP, rewarditems);
    }
}
