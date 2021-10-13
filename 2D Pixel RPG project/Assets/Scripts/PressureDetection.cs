using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PressureDetection : MonoBehaviour
{
    public GameObject crate;

    public string crateAnswer;
    public string[] triggerAnswer;

    public bool activateOnEnter, activateOnStay, activateOnExit;
    // private bool inArea;

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
        // if (other.tag == "Crate"){
        //     if (activateOnStay){
        //         Debug.Log("ACTIVATEDDDDDDDDDDDDD");
        //     }
        // }

        // if (!other.CompareTag($"Crate")) return;

        for (int i = 0; i < triggerAnswer.Length; i++){
            if (!other.CompareTag($"Crate")){
                return;
            } else {
                if (Vector3.Distance(transform.position,other.transform.position ) > 0.2f){
                    return;
                } else {
                    if (other.gameObject.name == triggerAnswer[i]){
                        if (activateOnStay){
                            isCorrect = true;
                            found = true;
                            // Debug.Log("This is IT!!!!!!!");
                            gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
                            other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
                            Destroy(this);
                        }
                    } 
                    // else
                    // {
                    //     isCorrect = false;
                        // gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
                        // Destroy(this);
                    // }
                }
            }
        }

        if (!found) {
            isCorrect = false;
            gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
            // Destroy(this);
        }




        // if (!other.CompareTag($"Crate")){
        //     return;
        // } else {
        //     if (Vector3.Distance(transform.position,other.transform.position ) > 0.2f){
        //         return;
        //     } else {
        //         if (other.gameObject.name == triggerAnswer[0] || other.gameObject.name == triggerAnswer[1] || other.gameObject.name == triggerAnswer[2]){
        //             if (activateOnStay){
        //                 isCorrect = true;
        //                 // Debug.Log("This is IT!!!!!!!");
        //                 gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
        //                 other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //                 Destroy(this);
        //             }
        //         } else
        //         {
        //             isCorrect = false;
        //             gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
        //             // Destroy(this);
        //         }
        //     }
        // }



        // if (!other.CompareTag($"Crate")){
        //     return;
        // } else {
        //     if (Vector3.Distance(transform.position,other.transform.position ) > 0.2f){
        //         return;
        //     } else {
        //         if (other.gameObject.name == triggerAnswer){
        //             if (activateOnStay){
        //                 isCorrect = true;
        //                 // Debug.Log("This is IT!!!!!!!");
        //                 gameObject.GetComponentInChildren<Renderer>().material.color = Color.green;
        //                 other.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Static;
        //                 Destroy(this);
        //             }
        //         } else
        //         {
        //             isCorrect = false;
        //             gameObject.GetComponentInChildren<Renderer>().material.color = Color.red;
        //             Destroy(this);
        //         }
        //     }
        // }

    }

    private void OnTriggerExit2D(Collider2D other) {
        gameObject.GetComponentInChildren<Renderer>().material.color = Color.white;
    }

    public bool AnswerIsCorrect(){
        return isCorrect;
    }
}
