using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputPlayer : MonoBehaviour
{    
    [SerializeField] int jogadas = 1;
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
        
        if((int)(jogadas % 2) == 0){
          MoveBlack();
        }else{
          MoveWhite();
        }
       

      }

    }else{

      rayEfectHit.gameObject.SetActive(false);
      
    }
  }

   void MoveWhite(){

     if(pecaSelected == null){

          for(int i = 0;i < board.chessPiecesWhite.Count;i++){

            if(hit.collider.gameObject.name == board.chessPiecesWhite[i].Cordenada){

              pecaSelected = board.chessPiecesWhite[i];
              i = board.chessPiecesWhite.Count;

            }
              
          }

        }else{
          
          bool move = true;

          for(int i = 0;i < board.chessPiecesWhite.Count;i++){          

            if(board.chessPiecesWhite[i].Cordenada == hit.collider.gameObject.name){

              pecaSelected = board.chessPiecesWhite[i];
              move = false;
              i = board.chessPiecesWhite.Count;

            } 

          }

          if(move){

            for(int i = 0;i < board.chessPiecesBlack.Count;i++){

              if(hit.collider.gameObject.name == board.chessPiecesBlack[i].Cordenada){
                    board.chessPiecesBlack[i].gameObject.SetActive(false);
                    board.chessPiecesBlack.RemoveAt(i);
              }  
                
            }
              
            pecaSelected.Cordenada = hit.collider.gameObject.name;
            pecaSelected = null;
            jogadas++;         

          }

        }
    
  }

   void MoveBlack(){

     if(pecaSelected == null){

          for(int i = 0;i < board.chessPiecesBlack.Count;i++){

            if(hit.collider.gameObject.name == board.chessPiecesBlack[i].Cordenada){

              pecaSelected = board.chessPiecesBlack[i];
              i = board.chessPiecesBlack.Count;

            }
              
          }

        }else{
          
          bool move = true;

          for(int i = 0;i < board.chessPiecesBlack.Count;i++){          

            if(board.chessPiecesBlack[i].Cordenada == hit.collider.gameObject.name){

              pecaSelected = board.chessPiecesBlack[i];
              move = false;
              i = board.chessPiecesBlack.Count;

            } 

          }

          if(move){

            for(int i = 0;i < board.chessPiecesWhite.Count;i++){

              if(hit.collider.gameObject.name == board.chessPiecesWhite[i].Cordenada){
                  board.chessPiecesWhite[i].gameObject.SetActive(false);
                  board.chessPiecesWhite.RemoveAt(i);
              }  
              
            }
              
            pecaSelected.Cordenada = hit.collider.gameObject.name;
            pecaSelected = null;
            jogadas++;         

          }

        }
    
  }

}


