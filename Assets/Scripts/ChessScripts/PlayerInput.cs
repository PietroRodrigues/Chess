using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    [SerializeField] int jogadas = 1;
    RaycastHit hit;
    [SerializeField] GameObject rayEfectHit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void ReyInput(){

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool too = Physics.Raycast(ray,out hit);

        if(too){

            rayEfectHit.gameObject.SetActive(true);
            rayEfectHit.gameObject.transform.position = hit.collider.gameObject.transform.position;

            if(Input.GetMouseButtonDown(0)){

                if((int)(jogadas % 2) == 0){
                    
                }else{
                
                }

            }else{

                rayEfectHit.gameObject.SetActive(false);
                
            }

        }

    }
}
