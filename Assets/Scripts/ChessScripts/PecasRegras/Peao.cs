using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao : conversorCord
{

    public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){
        
        string destino = peca.Cordenada;

        Vector2 v2CasaTG = CordToVector(casaTG.CasaCord);
        Vector2 v2Peca = CordToVector(peca.Cordenada);
        Casa[] casasDispo = new Casa[2];
        Casa[] casasDispoCap = new Casa[2];
        int  um = 0, dois = 0;

        if(peca.cor == BasePeca.Cor.branco){
            um = 1;
            dois = 2;
        }else if(peca.cor == BasePeca.Cor.preto){
            um = -1;
            dois = -2;
        }

        for (int i = 0; i < jogo.houses.Count; i++)
        {
            if(jogo.houses[i].CasaCord[0] == peca.Cordenada[0] &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + um){
                casasDispo[0] =  jogo.houses[i];               
            }

            if(jogo.houses[i].CasaCord[0] == peca.Cordenada[0] &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + dois){
                casasDispo[1] =  jogo.houses[i];               
            }
    
            if(CordToVector(jogo.houses[i].CasaCord).x == v2Peca.x + 1 &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + um){
                casasDispoCap[0] =  jogo.houses[i];               
            }

            if(CordToVector(jogo.houses[i].CasaCord).x == v2Peca.x - 1 &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + um){
                casasDispoCap[1] =  jogo.houses[i];               
            }

        }
        
        //Regra de Movimento-----------
           
        if(casaTG.CasaCord == casasDispo[0].CasaCord){
            if(casasDispo[0].hospede == null){
                peca.movimentada = true;
                destino = casaTG.CasaCord;
            }
        }

        if(peca.movimentada == false){
            if(casaTG.CasaCord == casasDispo[1].CasaCord){
                if(casasDispo[0].hospede == null && 
                   casasDispo[1].hospede == null){
                    peca.movimentada = true;
                    destino = casaTG.CasaCord;
                }
            }
        }
        
        for (int i = 0; i < casasDispoCap.Length; i++){
            if(casasDispoCap[i] != null){
                if(casaTG.CasaCord == casasDispoCap[i].CasaCord){
                    if(casasDispoCap[i].hospede != null && casasDispoCap[i].hospede.cor != peca.cor){
                        peca.movimentada = true;
                        destino = casaTG.CasaCord;
                    }
                }
            }
        }            
                     
        //---------------------------------
                
        return destino;
        
    }

    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        Vector2 v2Peca = CordToVector(peca.Cordenada);
        Casa[] casasDispo = new Casa[2];
        Casa[] casasDispoCap = new Casa[2];
        int  um = 0, dois = 0;

        if(peca.cor == BasePeca.Cor.branco){
            um = 1;
            dois = 2;
        }else if(peca.cor == BasePeca.Cor.preto){
            um = -1;
            dois = -2;
        }

        for (int i = 0; i < jogo.houses.Count; i++)
        {
            if(jogo.houses[i].CasaCord[0] == peca.Cordenada[0] &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + um){
                casasDispo[0] =  jogo.houses[i];               
            }

            if(jogo.houses[i].CasaCord[0] == peca.Cordenada[0] &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + dois){
                casasDispo[1] =  jogo.houses[i];               
            }

            if(CordToVector(jogo.houses[i].CasaCord).x == v2Peca.x + 1 &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + um){
                casasDispoCap[0] =  jogo.houses[i];               
            }

            if(CordToVector(jogo.houses[i].CasaCord).x == v2Peca.x - 1 &&
            CordToVector(jogo.houses[i].CasaCord).y == v2Peca.y + um){
                casasDispoCap[1] =  jogo.houses[i];               
            }

        }

        for (int i = 0; i < casasDispo.Length; i++)
        {   
            if(casasDispo[i] != null){         
                if(casasDispo[i].hospede == null){

                    Transform  efect = EfectMove.GetChild(i);
                    efect.position = casasDispo[i].transform.position;
                    efect.gameObject.SetActive(true);
                    
                    if(peca.movimentada)
                        i=casasDispo.Length;

                }else{
                    i=casasDispo.Length;
                }
            }

        }

        for (int i = 0; i < casasDispoCap.Length; i++)
        {
            if(casasDispoCap[i] != null){
                if(casasDispoCap[i].hospede != null && casasDispoCap[i].hospede.cor != peca.cor){
                    
                    Transform efect = EfectCapture.GetChild(i);                    
                    efect.position = casasDispoCap[i].transform.position;
                    efect.gameObject.SetActive(true);

                }
            }

        }     

    }


}
