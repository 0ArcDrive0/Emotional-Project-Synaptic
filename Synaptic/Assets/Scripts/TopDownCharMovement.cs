using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TopDownCharMovement : MonoBehaviour
{
    private InputHandler _input;
    [SerializeField]
    private float moveSpeed;

     Animator myAnim;

     float speed;
     


    private void Awake()
    {
        _input = GetComponent < InputHandler>();
        myAnim = GetComponent < Animator>();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       var targetVector = new Vector3(_input.InputVector.x, 0, _input.InputVector.y); 

       MoveTowardTarget(targetVector);

       myAnim.SetFloat("MoveX" , _input.InputVector.x);
       myAnim.SetFloat("MoveY" , _input.InputVector.y);
    }

    private void MoveTowardTarget(Vector3 targetVector)
    {
        speed = moveSpeed * Time.deltaTime;
        transform.Translate(targetVector * speed);
    }
}
