using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{

    [SerializeField] int jogadas = 1;
    RaycastHit hit;
    [SerializeField] GameObject mouseEfect = null;
    [SerializeField] GameObject captureEfect = null;
    [SerializeField] GameObject moveEfect = null;
    
    [HideInInspector]
    public Tabuleiro tabuleiro;
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

            mouseEfect.gameObject.SetActive(true);
            mouseEfect.gameObject.transform.position = hit.collider.gameObject.transform.position;

            if(Input.GetMouseButtonDown(0)){

                if((int)(jogadas % 2) == 0){
                    pecasMove(tabuleiro.pecasPretas,tabuleiro.pecasBrancas);                    
                }else{
                    pecasMove(tabuleiro.pecasBrancas,tabuleiro.pecasPretas);                   
                }

            }
        
        }else{

            mouseEfect.gameObject.SetActive(false);

        }
    }

    void ClearEnPassant(List<Transform> timeCorOpsota){
        
        for (int i = 0; i < timeCorOpsota.Count; i++)
        {
            if(timeCorOpsota[i].GetComponent<BasePeca>().peao.enPassantAlvo != null){
                Destroy(timeCorOpsota[i].GetComponent<BasePeca>().peao.enPassantAlvo);
                timeCorOpsota[i].GetComponent<BasePeca>().peao.enPassantAlvo = null;
            }
        }

    }
    
    void pecasMove(List<Transform> timeCor, List<Transform> timeCorOposta){

         if(pecaSelected == null){

              for(int i = 0;i < timeCor.Count;i++){
                  
                  if(hit.collider.gameObject.name == timeCor[i].gameObject.GetComponent<BasePeca>().Cordenada){

                      pecaSelected = timeCor[i];
                      BasePeca.ClearEfect(moveEfect.transform,captureEfect.transform);
                      pecaSelected.GetComponent<BasePeca>().EfeitosCasasPosiveis(pecaSelected.GetComponent<BasePeca>(),tabuleiro,moveEfect.transform,captureEfect.transform);
                      i = timeCor.Count;

                  }

              }

         }else{

            bool mover = true;
             
            for(int i = 0;i < timeCor.Count;i++){

                 if(timeCor[i].GetComponent<BasePeca>().Cordenada == hit.collider.gameObject.name){
                     pecaSelected = timeCor[i];
                     BasePeca.ClearEfect(moveEfect.transform,captureEfect.transform);
                     pecaSelected.GetComponent<BasePeca>().EfeitosCasasPosiveis(pecaSelected.GetComponent<BasePeca>(),tabuleiro,moveEfect.transform,captureEfect.transform);
                     mover = false;
                     i = timeCor.Count;

                 }

            }

            if(mover){

                string destino = pecaSelected.GetComponent<BasePeca>().MoveTipo(pecaSelected.GetComponent<BasePeca>(),hit.collider.GetComponent<Casa>(),tabuleiro);

                //Verificar c estou em check antes de passar a vez


                if(pecaSelected.GetComponent<BasePeca>().Cordenada != destino){

                    for(int i = 0;i < timeCorOposta.Count;i++){

                        if(hit.collider.gameObject.name == timeCorOposta[i].GetComponent<BasePeca>().Cordenada){                          
                            
                            if(timeCorOposta[i].GetComponent<BasePeca>().peao.enPassantAlvo != null){
                                Destroy(timeCorOposta[i].GetComponent<BasePeca>().peao.enPassantAlvo);
                            }
                            timeCorOposta[i].gameObject.SetActive(false);
                            timeCorOposta.RemoveAt(i);
                        }

                    }           
               
                    pecaSelected.GetComponent<BasePeca>().Cordenada = destino;
                    tabuleiro.SetaPecasInCord();
                    BasePeca.ClearEfect(moveEfect.transform,captureEfect.transform);
                    pecaSelected = null;
                    
                    if((int)(jogadas % 2) == 0){                   
                        ClearEnPassant(tabuleiro.pecasBrancas);
                    }else{
                        ClearEnPassant(tabuleiro.pecasPretas);
                    }

                    jogadas++;
                    
                    ClearDominio();
                    VerificaCheck();
                    
                }

            }

        }     


    }

    void VerificaCheck(){
       
        if((int)(jogadas % 2) == 0){
            foreach (Transform peca in tabuleiro.pecasPretas)
            {
                if(peca.GetComponent<BasePeca>().tipo == BasePeca.Tipo.rei)
                    peca.GetComponent<BasePeca>().rei.CheckVerific(tabuleiro.pecasBrancas,tabuleiro);
            }                      
        }else{
            foreach (Transform peca in tabuleiro.pecasBrancas)
            {
                if(peca.GetComponent<BasePeca>().tipo == BasePeca.Tipo.rei)
                    peca.GetComponent<BasePeca>().rei.CheckVerific(tabuleiro.pecasPretas,tabuleiro);
            }     
        }

    }

    void ClearDominio(){
       foreach (Casa c in tabuleiro.houses)
       {
           c.dominio = BasePeca.Cor.neutra;
                          
       }
                          
    }

    void VerificaMate(){

    }   

}
