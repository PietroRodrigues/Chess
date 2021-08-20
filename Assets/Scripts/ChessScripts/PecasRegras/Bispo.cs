using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bispo : conversorCord
{   
    string destino;

    Casa[] casasDispoNL;
    Casa[] casasDispoSO;
    Casa[] casasDispoNO;
    Casa[] casasDispoSL;

    public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){
               
        destino = peca.Cordenada;

        //Add Regra de Movimento-----------

        casasDispoNL = new Casa[7];
        casasDispoSO = new Casa[7];
        casasDispoNO = new Casa[7];
        casasDispoSL = new Casa[7];

        ScanCasasPosiveis(jogo, peca);

        //Regra de Movimento-----------        
        RegraMovimentes(peca,casasDispoNL,casaTG);
        RegraMovimentes(peca,casasDispoSO,casaTG);
        RegraMovimentes(peca,casasDispoNO,casaTG);
        RegraMovimentes(peca,casasDispoSL,casaTG);

        //---------------------------------
        
        return destino;

    }

    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        casasDispoNL = new Casa[7];
        casasDispoSO = new Casa[7];
        casasDispoNO = new Casa[7];
        casasDispoSL = new Casa[7];   
        
        ScanCasasPosiveis(jogo, peca);
       
        EfectsDistribuite(peca,casasDispoNL,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoSO,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoNO,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoSL,EfectMove,EfectCapture);

    }

     void ScanCasasPosiveis(Tabuleiro jogo,BasePeca peca){

        Vector2 v2Peca = CordToVector(peca.Cordenada);

        for(int i = 0;i < jogo.houses.Count;i++){

            Vector2 v2houses = CordToVector(jogo.houses[i].CasaCord);

            for (int j = 0; j < casasDispoNL.Length; j++)
            {
                if(v2houses.x == v2Peca.x + (1+j) && v2houses.y == v2Peca.y + (1+j)){
                    casasDispoNL[j] = jogo.houses[i];
                }

            }
            for (int j = 0; j < casasDispoSO.Length; j++)
            {
                if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y - (1+j)){
                    casasDispoSO[j] = jogo.houses[i];
                }

            }
            for (int j = 0; j < casasDispoNO.Length; j++)
            {
                if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y + (1+j)){
                    casasDispoNO[j] = jogo.houses[i];
                }

            }
            for (int j = 0; j < casasDispoSL.Length; j++)
            {
                if(v2houses.x == v2Peca.x + (1+j) && v2houses.y == v2Peca.y - (1+j)){
                    casasDispoSL[j] = jogo.houses[i];
                }

            }

        }
    }

    void RegraMovimentes(BasePeca peca,Casa[] casaDirection,Casa casaTG){      


        for (int i = 0; i < casaDirection.Length; i++)
        {
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null || casaDirection[i].hospede.tipo == BasePeca.Tipo.sombra){
                    if(casaDirection[i].CasaCord == casaTG.CasaCord){
                        peca.movimentada = true;
                        destino = casaTG.CasaCord;
                    }
                }else{
                    if(casaDirection[i].hospede.cor != peca.cor){
                        
                        if(casaDirection[i].CasaCord == casaTG.CasaCord){
                            peca.movimentada = true;
                            destino = casaTG.CasaCord;
                        }else{
                            i = casaDirection.Length;
                        }

                    }else{
                        i = casaDirection.Length;
                    }
                }
            }
        }
    }       

    void EfectsDistribuite(BasePeca peca,Casa[] casaDirection,Transform EfectMove,Transform EfectCapture){

        for (int i = 0; i < casaDirection.Length; i++)
        {            
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null || casaDirection[i].hospede.tipo == BasePeca.Tipo.sombra){
                    
                    for (int j = 0; j < EfectMove.childCount; j++)
                    {
                        if(!EfectMove.GetChild(j).gameObject.activeSelf){                
                            Transform  efect = EfectMove.GetChild(j);
                            efect.position = casaDirection[i].transform.position;
                            efect.gameObject.SetActive(true);
                            j = EfectMove.childCount;
                        }    
                    }           

                }else{

                    if(casaDirection[i].hospede.cor != peca.cor){
                        
                        for (int j = 0; j < EfectCapture.childCount; j++)
                        {
                            if(!EfectCapture.GetChild(j).gameObject.activeSelf){                
                                Transform  efect = EfectCapture.GetChild(j);
                                efect.position = casaDirection[i].transform.position;
                                efect.gameObject.SetActive(true);
                                j = EfectMove.childCount;
                                i = casaDirection.Length;
                            }    
                        }

                    }else{
                        i = casaDirection.Length;
                    }

                }
            }

        }

    }


}
