using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] int jogadas = 1;
    RaycastHit hit;
    [SerializeField] GameObject rayEfectHit = null;
    Tabuleiro tabuleiro;
    Transform pecaSelected = null;

    // Update is called once per frame

    private void Awake() {
        tabuleiro = GetComponent<Tabuleiro>();
    }

    void Update()
    {
        ReyInput();
    }

    void ReyInput(){

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        bool too = Physics.Raycast(ray,out hit);

        if(too){

            rayEfectHit.gameObject.SetActive(true);
            rayEfectHit.gameObject.transform.position = hit.collider.gameObject.transform.position;

            if(Input.GetMouseButtonDown(0)){

                if((int)(jogadas % 2) == 0){
                    pecasMove(tabuleiro.pecasPretas,tabuleiro.pecasBrancas);
                }else{
                    pecasMove(tabuleiro.pecasBrancas,tabuleiro.pecasPretas);
                }

            }
        
        }else{

            rayEfectHit.gameObject.SetActive(false);

        }
    }

    void pecasMove(List<Transform> timeCor, List<Transform> timeCorOposta){

         if(pecaSelected == null){

              for(int i = 0;i < timeCor.Count;i++){
                  
                  if(hit.collider.gameObject.name == timeCor[i].gameObject.GetComponent<BasePeca>().Cordenada){

                      pecaSelected = timeCor[i];
                      i = timeCor.Count;

                  }

              }

         }else{

            bool mover = true;
             
            for(int i = 0;i < timeCor.Count;i++){

                 if(timeCor[i].GetComponent<BasePeca>().Cordenada == hit.collider.gameObject.name){
                     pecaSelected = timeCor[i];
                     mover = false;
                     i = timeCor.Count;

                 }

            }

            if(mover){

                for(int i = 0;i < timeCorOposta.Count;i++){

                    if(hit.collider.gameObject.name == timeCorOposta[i].GetComponent<BasePeca>().Cordenada){
                        timeCorOposta[i].gameObject.SetActive(false);
                        timeCorOposta.RemoveAt(i);
                    }

                }            

            pecaSelected.GetComponent<BasePeca>().Cordenada = hit.collider.gameObject.name; //pecaSelected.MoveTipo(pecaSelected,hit.collider.gameObject.name,jogadas);
            pecaSelected = null;
            jogadas++;

            }

         }

    }

}
