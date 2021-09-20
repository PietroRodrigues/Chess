using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cavalo : XadrezProperts
{    
     string destino ;
     
     BasePeca King;

     Casa[] casasDispo;    


     public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){
        
        King = GetKing(jogo,peca.cor);

        destino = peca.Cordenada;
        casasDispo = new Casa[8];
              
        ScanCasasPosiveis(jogo, peca);        

        //Add Regra de Movimento-----------
        for (int i = 0; i < casasDispo.Length; i++)
        {
            if(casasDispo[i] != null){
               
                if(casaTG.CasaCord == casasDispo[i].CasaCord){
                    
                    if(casasDispo[i].hospede == null){
                                         
                        destino = casaTG.CasaCord;

                    }else{
                        
                        if(casasDispo[i].hospede.cor != peca.cor){
                            destino = casaTG.CasaCord;
                        }
                        
                    }          
                }
            }
        }
        //---------------------------------

        
        return destino;

    }

    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        King = GetKing(jogo,peca.cor);

        Vector2 v2Peca = CordToVector(peca.Cordenada);
        casasDispo = new Casa[8];

        ScanCasasPosiveis(jogo, peca);

        for (int i = 0; i < casasDispo.Length; i++)
        {
            if(casasDispo[i] != null){
                if(casasDispo[i].hospede == null || casasDispo[i].hospede.tipo == BasePeca.Tipo.sombra){
                    
                    Transform  efect = EfectMove.GetChild(i);
                    efect.position = casasDispo[i].transform.position;
                    efect.gameObject.SetActive(true);               
                                
                }else{

                    if(casasDispo[i].hospede.cor != peca.cor){

                        Transform  efect = EfectCapture.GetChild(i);
                        efect.position = casasDispo[i].transform.position;
                        efect.gameObject.SetActive(true);
                        
                    }
                }
            }
        }
    }

    public void CasasDominio(BasePeca peca,Tabuleiro jogo){

        casasDispo = new Casa[8];

        ScanCasasPosiveis(jogo, peca);

        for (int i = 0; i < casasDispo.Length; i++)
        {
            if(casasDispo[i] != null)
                casasDispo[i].dominio = peca.cor;
        }
        
    }

    void ScanCasasPosiveis(Tabuleiro jogo,BasePeca peca){

        Vector2 v2Peca = CordToVector(peca.Cordenada);

        for (int i = 0; i < jogo.houses.Count; i++)
        {
            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x + 1, v2Peca.y + 2)){
                casasDispo[0] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x - 1, v2Peca.y - 2)){
                casasDispo[1] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x + 1, v2Peca.y - 2)){
                casasDispo[2] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x - 1, v2Peca.y + 2)){
                casasDispo[3] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x + 2, v2Peca.y + 1)){
                casasDispo[4] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x - 2, v2Peca.y - 1)){
                casasDispo[5] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x + 2, v2Peca.y - 1)){
                casasDispo[6] = jogo.houses[i];
            }

            if(CordToVector(jogo.houses[i].CasaCord) == new Vector2(v2Peca.x - 2, v2Peca.y + 1)){
                casasDispo[7] = jogo.houses[i];
            }
            
        }

    }
}
