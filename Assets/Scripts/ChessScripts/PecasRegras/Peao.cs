using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao : conversorCord
{
    string destino;

    Casa[] casasDispoN;
    Casa[] casasDispoS;
    Casa[] casasDispoNL;
    Casa[] casasDispoSO;
    Casa[] casasDispoNO;
    Casa[] casasDispoSL;


    public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){

        int n = (peca.movimentada)? 1 : 2;
        
        destino = peca.Cordenada;

        if(peca.cor == BasePeca.Cor.branco){
            casasDispoN = new Casa[n];
            casasDispoNL = new Casa[1];
            casasDispoNO = new Casa[1];
        }else{
            casasDispoS = new Casa[n];      
            casasDispoSO = new Casa[1];
            casasDispoSL = new Casa[1];
        }             
        
        ScanCasasPosiveis(jogo, peca);

        //Regra de Movimento-----------
        if(peca.cor == BasePeca.Cor.branco){
            RegraMovimentes(peca,casasDispoN,casaTG);
            RegraMovimentes(peca,casasDispoNL,casaTG);
            RegraMovimentes(peca,casasDispoNO,casaTG);
        }else{
            RegraMovimentes(peca,casasDispoS,casaTG);
            RegraMovimentes(peca,casasDispoSO,casaTG);      
            RegraMovimentes(peca,casasDispoSL,casaTG);
        }                    
        //---------------------------------
                
        return destino;
        
    }

    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        int n = (peca.movimentada)? 1 : 2;

        if(peca.cor == BasePeca.Cor.branco){
            casasDispoN = new Casa[n];
            casasDispoNL = new Casa[1];
            casasDispoNO = new Casa[1];
        }else{
            casasDispoS = new Casa[n];        
            casasDispoSO = new Casa[1];        
            casasDispoSL = new Casa[1];        
        }

        ScanCasasPosiveis(jogo, peca);

        if(peca.cor == BasePeca.Cor.branco){
            EfectsDistribuite(peca,casasDispoN,EfectMove,EfectCapture);
            EfectsDistribuite(peca,casasDispoNL,EfectMove,EfectCapture);
            EfectsDistribuite(peca,casasDispoNO,EfectMove,EfectCapture);
        }else{
            EfectsDistribuite(peca,casasDispoS,EfectMove,EfectCapture);        
            EfectsDistribuite(peca,casasDispoSO,EfectMove,EfectCapture);
            EfectsDistribuite(peca,casasDispoSL,EfectMove,EfectCapture);
        }

    }

    void ScanCasasPosiveis(Tabuleiro jogo,BasePeca peca){

        Vector2 v2Peca = CordToVector(peca.Cordenada);

        for(int i = 0;i < jogo.houses.Count;i++){

            Vector2 v2houses = CordToVector(jogo.houses[i].CasaCord);
                       
            if(peca.cor == BasePeca.Cor.branco){
                for (int j = 0; j < casasDispoN.Length; j++)
                {
                    if(v2houses.x == v2Peca.x && v2houses.y == v2Peca.y + (1+j)){
                        casasDispoN[j] = jogo.houses[i];
                    }
                }
                for (int j = 0; j < casasDispoNL.Length; j++)
                {
                    if(v2houses.x == v2Peca.x + (1+j) && v2houses.y == v2Peca.y + (1+j)){
                        if(jogo.houses[i].hospede != null && jogo.houses[i].hospede.cor != peca.cor)
                        casasDispoNL[j] = jogo.houses[i];
                    }

                }
                for (int j = 0; j < casasDispoNO.Length; j++)
                {
                    if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y + (1+j)){
                        if(jogo.houses[i].hospede != null && jogo.houses[i].hospede.cor != peca.cor)
                        casasDispoNO[j] = jogo.houses[i];
                    }

                }
            }else{
                for (int j = 0; j < casasDispoS.Length; j++)
                {
                    if(v2houses.x == v2Peca.x && v2houses.y == v2Peca.y - (1+j)){
                        casasDispoS[j] = jogo.houses[i];
                    }
                }
                for (int j = 0; j < casasDispoSO.Length; j++)
                {
                    if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y - (1+j)){
                        if(jogo.houses[i].hospede != null && jogo.houses[i].hospede.cor != peca.cor)
                        casasDispoSO[j] = jogo.houses[i];
                    }

                }
                
                for (int j = 0; j < casasDispoSL.Length; j++)
                {
                    if(v2houses.x == v2Peca.x + (1+j) && v2houses.y == v2Peca.y - (1+j)){
                        if(jogo.houses[i].hospede != null && jogo.houses[i].hospede.cor != peca.cor)
                        casasDispoSL[j] = jogo.houses[i];
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

                    if(casaDirection[i].hospede.cor != peca.cor && casaDirection[i].hospede.Cordenada[0] != peca.Cordenada[0]){
                        
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

}
