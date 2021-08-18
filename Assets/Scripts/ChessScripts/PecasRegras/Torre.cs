using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torre : conversorCord
{
    string destino;

    Casa[] casasDispoN;
    Casa[] casasDispoS;
    Casa[] casasDispoO;
    Casa[] casasDispoL;

    public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){
        
        destino = peca.Cordenada;            

        casasDispoN = new Casa[7];
        casasDispoS = new Casa[7];
        casasDispoO = new Casa[7];
        casasDispoL = new Casa[7];

        ScanCasasPosiveis(jogo, peca);

        //Regra de Movimento-----------        
        RegraMovimentes(peca,casasDispoN,casaTG);
        RegraMovimentes(peca,casasDispoS,casaTG);
        RegraMovimentes(peca,casasDispoO,casaTG);
        RegraMovimentes(peca,casasDispoL,casaTG);
        //---------------------------------
        return destino;

    }

    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        casasDispoN = new Casa[7];
        casasDispoS = new Casa[7];
        casasDispoO = new Casa[7];
        casasDispoL = new Casa[7];   
        
        ScanCasasPosiveis(jogo, peca);
       
        EfectsDistribuite(peca,casasDispoN,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoS,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoO,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoL,EfectMove,EfectCapture);        
      
    }


    void ScanCasasPosiveis(Tabuleiro jogo,BasePeca peca){

        Vector2 v2Peca = CordToVector(peca.Cordenada);

        for(int i = 0;i < jogo.houses.Count;i++){

            Vector2 v2houses = CordToVector(jogo.houses[i].CasaCord);

            for (int j = 0; j < casasDispoN.Length; j++)
            {
                if(v2houses.x == v2Peca.x && v2houses.y == v2Peca.y + (1+j)){
                    casasDispoN[j] = jogo.houses[i];
                }

            }
            for (int j = 0; j < casasDispoS.Length; j++)
            {
                if(v2houses.x == v2Peca.x && v2houses.y == v2Peca.y - (1+j)){
                    casasDispoS[j] = jogo.houses[i];
                }

            }
            for (int j = 0; j < casasDispoO.Length; j++)
            {
                if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y){
                    casasDispoO[j] = jogo.houses[i];
                }

            }
            for (int j = 0; j < casasDispoL.Length; j++)
            {
                if(v2houses.x == v2Peca.x + (1+j) && v2houses.y == v2Peca.y){
                    casasDispoL[j] = jogo.houses[i];
                }

            }

        }
    }

    void RegraMovimentes(BasePeca peca,Casa[] casaDirection,Casa casaTG){      


        for (int i = 0; i < casaDirection.Length; i++)
        {
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null){
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
                if(casaDirection[i].hospede == null){
                    
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
