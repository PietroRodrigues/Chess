using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei : conversorCord
{    
    string destino;

    BasePeca[] torres = new BasePeca[2];
    
    Casa[] casasDispoN;
    Casa[] casasDispoS;
    Casa[] casasDispoO;
    Casa[] casasDispoL;
    Casa[] casasDispoNL;
    Casa[] casasDispoSO;
    Casa[] casasDispoNO;
    Casa[] casasDispoSL;

    public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){
        
        destino = peca.Cordenada;

        GetTorres(peca,jogo);
        
        int n1 = (!peca.movimentada && !torres[0].movimentada)? 3 : 1;
        int n2 = (!peca.movimentada && !torres[1].movimentada)? 2 : 1;
       
        casasDispoN = new Casa[1];
        casasDispoS = new Casa[1];
        casasDispoO = new Casa[n1];
        casasDispoL = new Casa[n2];
        casasDispoNL = new Casa[1];
        casasDispoSO = new Casa[1];
        casasDispoNO = new Casa[1];
        casasDispoSL = new Casa[1];        
        
        ScanCasasPosiveis(jogo, peca);

        //Add Regra de Movimento-----------
        RegraMovimentes(peca,casasDispoN,casaTG);
        RegraMovimentes(peca,casasDispoS,casaTG);
        RegraMovimentes(peca,casasDispoO,casaTG);
        RegraMovimentes(peca,casasDispoL,casaTG);
        RegraMovimentes(peca,casasDispoNL,casaTG);
        RegraMovimentes(peca,casasDispoSO,casaTG);
        RegraMovimentes(peca,casasDispoNO,casaTG);
        RegraMovimentes(peca,casasDispoSL,casaTG);
        //---------------------------------

        return destino;

    }
    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        GetTorres(peca,jogo);

        int n1 = (!peca.movimentada && !torres[0].movimentada)? 2 : 1;
        int n2 = (!peca.movimentada && !torres[1].movimentada)? 2 : 1;      

        casasDispoN = new Casa[1];
        casasDispoS = new Casa[1];
        casasDispoO = new Casa[n1];
        casasDispoL = new Casa[n2];
        casasDispoNL = new Casa[1];
        casasDispoSO = new Casa[1];
        casasDispoNO = new Casa[1];
        casasDispoSL = new Casa[1];

        ScanCasasPosiveis(jogo, peca);

        EfectsDistribuite(peca,casasDispoN,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoS,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoO,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoL,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoNL,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoSO,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoNO,EfectMove,EfectCapture);
        EfectsDistribuite(peca,casasDispoSL,EfectMove,EfectCapture);
       

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
                if(casaDirection[i].hospede == null){
                    if(casaDirection[i].CasaCord == casaTG.CasaCord){
                        if(casaTG.CasaCord[0] == 'c' &&  !peca.movimentada && !torres[0].movimentada){

                            peca.movimentada = true;
                            torres[0].movimentada = true;
                            torres[0].Cordenada = VectorToPos(new Vector2(CordToVector(torres[0].Cordenada).x + 3,CordToVector(torres[0].Cordenada).y)); 
                            destino = casaTG.CasaCord;

                        }else if(casaTG.CasaCord[0] == 'g' &&  !peca.movimentada && !torres[1].movimentada)
                        {
                            peca.movimentada = true;
                            torres[1].movimentada = true;
                            torres[1].Cordenada = VectorToPos(new Vector2(CordToVector(torres[1].Cordenada).x - 2,CordToVector(torres[1].Cordenada).y)); 
                            destino = casaTG.CasaCord;

                        }else{
                            peca.movimentada = true;
                            destino = casaTG.CasaCord;
                        }
                    }
                }else{
                    if(casaDirection[i].hospede.cor != peca.cor ){
                        
                        Debug.Log("Arrumar peça inimiga entre o roque");

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

    void GetTorres(BasePeca peca,Tabuleiro jogo){
                   
        foreach (Casa casa in jogo.houses)
        {
                if(casa.hospede != null){
                    if(casa.hospede.cor == peca.cor){
                        if(casa.hospede.tipo == BasePeca.Tipo.torre && !casa.hospede.movimentada ){
                            if(casa.hospede.Cordenada[0] == 'a')
                                torres[0] = casa.hospede;
                            if(casa.hospede.Cordenada[0] == 'h')
                                torres[1] = casa.hospede;
                    }
                }
            }
        }
        
      
    }

    void Check(){
        
    }

}
