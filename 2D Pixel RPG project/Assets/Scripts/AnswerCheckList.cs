using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnswerCheckList : MonoBehaviour
{
    [Header("Correct Color")]
    public Color correctColor;

    [Header("Activate Object")]
    public GameObject objectToActivate;
    public bool activeIfComplete;

    private bool initialCheckDone;

    [Header("All Trigger")]
    public GameObject[] triggerList;
    public bool[] answerList;
    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        checkAnswer();
        checkCompletion();
    }

    void checkAnswer(){
        for (int i = 0; i < triggerList.Length; i++){
            if (triggerList[i].GetComponent<Renderer>().material.color == correctColor){
                answerList[i] = true;
            }else {
                answerList[i] = false;
            }
        }
    }

    public void checkCompletion(){
        bool check = true;
        for (int i = 0; i < answerList.Length; i++){
            if (!answerList[i]){
                check = false;
            }
        }
        if (check){
            objectToActivate.SetActive(activeIfComplete);
            Destroy(this);
        }
    }
}
