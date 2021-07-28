using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{    
    [SerializeField] ChessBoard board;
    RaycastHit hit;
    [SerializeField] GameObject rayEfectHit;
    [SerializeField] PecaBase pecaSelected;

    // Update is called once per frame
  

    void Update()
    {
         RayInput();
    }

    void RayInput(){
    
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
    bool too = Physics.Raycast(ray,out hit);

    if(too){

      rayEfectHit.gameObject.SetActive(true);
      rayEfectHit.gameObject.transform.position = hit.collider.gameObject.transform.position;
     
      if(Input.GetMouseButtonDown(0)){      
        
        for(int i = 0;i < board.chessPiecesWhite.Count;i++){
          
          if(pecaSelected == null){
            
            if(hit.collider.gameObject.name == board.chessPiecesWhite[i].Cordenada){
              pecaSelected = board.chessPiecesWhite[i];
              i = board.chessPiecesWhite.Count;
            }
                               

          }else{
            Debug.LogWarning("PArei Aki");
            if(hit.collider.gameObject.name == board.chessPiecesWhite[i].Cordenada){
              pecaSelected = board.chessPiecesWhite[i];
              i = board.chessPiecesWhite.Count;
            }else{       
              pecaSelected.Cordenada = hit.collider.gameObject.name;
              pecaSelected = null;        
              i = board.chessPiecesWhite.Count;          
            }
          }       

        }
        
      }

    }else{

      rayEfectHit.gameObject.SetActive(false);
      
    }
  }
}
