using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    
    RaycastHit hit;

    [SerializeField] GameObject mouseEfect = null;
    [SerializeField] GameObject captureEfect = null;
    [SerializeField] GameObject moveEfect = null;
    
    [HideInInspector]
    public Tabuleiro tabuleiro;
    Transform pecaSelected = null;
    GameObject pecaCapBeckup = null;
    GameObject shadowBeckup = null;

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

                if((int)(tabuleiro.jogadas % 2) == 0){
                    pecasMove(tabuleiro.pecasPretas,tabuleiro.pecasBrancas);                    
                }else{
                    pecasMove(tabuleiro.pecasBrancas,tabuleiro.pecasPretas);                   
                }

            }
        
        }else{

            mouseEfect.gameObject.SetActive(false);

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
                                              
                string cordAtual = pecaSelected.GetComponent<BasePeca>().Cordenada;

                string destino = pecaSelected.GetComponent<BasePeca>().MoveTipo(pecaSelected.GetComponent<BasePeca>(),hit.collider.GetComponent<Casa>(),tabuleiro);
                         
                if(pecaSelected.GetComponent<BasePeca>().Cordenada != destino){

                    CapturaPeca(timeCorOposta);               
                    pecaSelected.GetComponent<BasePeca>().Cordenada = destino;
                    tabuleiro.SetaPecasInCord();
                    BasePeca.ClearEfect(moveEfect.transform,captureEfect.transform);
                    ClearDominio();
                    SetaDominio();
                    VerificCheck(tabuleiro);

                    if(pecaSelected.GetComponent<BasePeca>().cor == BasePeca.Cor.branco){
                        
                        if(tabuleiro.reiBranco.rei.check){
                             ResetJogada(cordAtual, timeCorOposta);
                        }else{
                            
                            pecaSelected = null;
                            tabuleiro.jogadas++;
                            ClrearShados(true);
                            ClearDominio();
                            SetaDominio();
                            VerificCheck(tabuleiro);
                        }

                    }else if(pecaSelected.GetComponent<BasePeca>().cor == BasePeca.Cor.preto){
                        if(tabuleiro.reiPreto.rei.check){
                            ResetJogada(cordAtual, timeCorOposta);
                        }else{

                            pecaSelected = null;
                            tabuleiro.jogadas++;
                            ClrearShados(true);
                            ClearDominio();
                            SetaDominio();
                            VerificCheck(tabuleiro);
                        }
                    }                        
                    
                }

            }

        }  

    }

    void ResetJogada(string cordAtual, List<Transform> timeCorOposta){
        
        if(pecaCapBeckup != null){
            pecaCapBeckup.gameObject.SetActive(true);
            timeCorOposta.Add(pecaCapBeckup.transform);            
        }

        pecaSelected.GetComponent<BasePeca>().Cordenada = cordAtual;
        tabuleiro.SetaPecasInCord();
        BasePeca.ClearEfect(moveEfect.transform,captureEfect.transform);
        
        if(pecaSelected.GetComponent<BasePeca>().CordInicial == cordAtual){
            pecaSelected.GetComponent<BasePeca>().movimentada = false;
        }

        //ClrearShados(true);
        ClearDominio();
        SetaDominio();
        VerificCheck(tabuleiro);
        
    }

    void VerificCheck(Tabuleiro jogo){       
        
       foreach (Casa casa in jogo.houses)
       {    
            if(casa.hospede != null){
                if(casa.hospede.tipo == BasePeca.Tipo.rei){
                    
                    if(casa.dominio != BasePeca.Cor.neutra){
                        if(casa.dominio != casa.hospede.cor){
                            casa.hospede.rei.check = true;
                            Debug.Log(casa.hospede.rei.check);
                            SetMate(casa.hospede,jogo);
                        }
                    }else{
                        casa.hospede.rei.check = false;
                    }

                }
            }
       }
        
    }   

    void SetMate(BasePeca peca,Tabuleiro jogo){

    }

    void ClrearShados(bool invert){

        if((int)(tabuleiro.jogadas % 2) == 0){
            if(!invert)                 
            ClearEnPassant(tabuleiro.pecasBrancas);
            else
            ClearEnPassant(tabuleiro.pecasPretas);
        }else{
           if(!invert)                 
            ClearEnPassant(tabuleiro.pecasPretas);
            else
            ClearEnPassant(tabuleiro.pecasBrancas);
        }

    }

    void SetaDominio(){

        if((int)(tabuleiro.jogadas % 2) == 0){                   
           tabuleiro.reiBranco.rei.ScanDominioAdversario(tabuleiro);
        }else{
           tabuleiro.reiPreto.rei.ScanDominioAdversario(tabuleiro);
        }

    }

    void CapturaPeca(List<Transform> timeCorOposta){
        
        pecaCapBeckup = null;

        for(int i = 0;i < timeCorOposta.Count;i++){

            if(hit.collider.gameObject.name == timeCorOposta[i].GetComponent<BasePeca>().Cordenada){                          
                
                if(timeCorOposta[i].GetComponent<BasePeca>().tipo == BasePeca.Tipo.sombra){

                    GameObject shadow = timeCorOposta[i].gameObject;
                    shadowBeckup = timeCorOposta[i].gameObject;
                    pecaCapBeckup = timeCorOposta[i].GetComponent<BasePeca>().peao.peaoVinculo.gameObject;
                    timeCorOposta[i].GetComponent<BasePeca>().peao.peaoVinculo.gameObject.SetActive(false);

                }else{                
                    pecaCapBeckup = timeCorOposta[i].gameObject;
                    timeCorOposta[i].gameObject.SetActive(false);
                    timeCorOposta.RemoveAt(i);
                }
                
            }

        }
    }

    void ClearDominio(){
       foreach (Casa c in tabuleiro.houses)
       {
           c.dominio = BasePeca.Cor.neutra;
                          
       }
       tabuleiro.ClearDominioEfects();                          
    }

    void ClearEnPassant(List<Transform> timeCorOposta){
        
        for (int i = 0; i < timeCorOposta.Count; i++)
        {
            if(timeCorOposta[i].GetComponent<BasePeca>().tipo == BasePeca.Tipo.sombra){

                GameObject shadow = timeCorOposta[i].gameObject;             
                timeCorOposta.RemoveAt(i);
                Destroy(shadow);

            }

        }

    }

}
