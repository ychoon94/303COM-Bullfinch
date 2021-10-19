using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureDetection : MonoBehaviour
{
    public GameObject crate;

    public string crateAnswer;
    public string[] triggerAnswer;

    public bool isHigherDifficulty;
    public bool activateOnEnter, activateOnStay, activateOnExit;

    public bool isCorrect;
    
    private bool found;

    // Start is called before the first frame update
    void Start()
    {
        crate.name = crateAnswer;
        isCorrect = false;
        found = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other) {
        for (int i = 0; i < triggerAnswer.Length; i++){
            if (!other.CompareTag($"Crate")){
                return;
            } else {
                if (Vector3.Distance(transform.position,other.transform.position ) > 0.3f){
                    return;
                } else {
                    if (isHigherDifficulty){
                        if (other.gameObject.name == triggerAnswer[i]){
                            if (activateOnStay){
                                isCorrect = true;
                                found = true;
                                gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
                                other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                                Destroy(this);
                            }
                        }
                        if (!found){
                            isCorrect = false;
                            gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
                            Destroy(this);
                        }                   
                    } else {
                        if (other.gameObject.name == triggerAnswer[i]){
                            if (activateOnStay){
                                isCorrect = true;
                                found = true;
                                gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
                                other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                                Destroy(this);
                            }
                        }
                    }
                }
            }
        }
        if (!found) {
            isCorrect = false;
            gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
        }
    }

    private void OnTriggerExit2D(Collider2D other) {
        gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    public bool AnswerIsCorrect(){
        return isCorrect;
    }
}
