using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rei : XadrezProperts
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

    public bool check = false;
    public bool checkMate = false;

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

     public bool ScanerCheck(Tabuleiro jogo,BasePeca peca){
        
        bool check = false;

        casasDispoN = new Casa[1];
        casasDispoS = new Casa[1];
        casasDispoO = new Casa[1];
        casasDispoL = new Casa[1];
        casasDispoNL = new Casa[1];
        casasDispoSO = new Casa[1];
        casasDispoNO = new Casa[1];
        casasDispoSL = new Casa[1];

        ScanCasasPosiveis(jogo, peca);

        check = (!check)? ScanAtacks(casasDispoL,peca) : true;
        check = (!check)? ScanAtacks(casasDispoN,peca) : true;
        check = (!check)? ScanAtacks(casasDispoO,peca) : true;
        check = (!check)? ScanAtacks(casasDispoS,peca) : true;
        check = (!check)? ScanAtacks(casasDispoNL,peca) : true;
        check = (!check)? ScanAtacks(casasDispoNO,peca) : true;
        check = (!check)? ScanAtacks(casasDispoSL,peca) : true;
        check = (!check)? ScanAtacks(casasDispoSO,peca) : true;


        return check;

    }

    void RegraMovimentes(BasePeca peca,Casa[] casaDirection,Casa casaTG){      


        for (int i = 0; i < casaDirection.Length; i++)
        {
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null || casaDirection[i].hospede.tipo == BasePeca.Tipo.sombra){
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
                   
                    if(i == 0 && casaDirection[i].hospede.cor != peca.cor ){
                                               
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

                    if(i == 0 && casaDirection[i].hospede.cor != peca.cor){
                        
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

    public void CheckVerific(List<Transform> pecas,Tabuleiro jogo){

            foreach (Transform p in pecas)
            {
                BasePeca pecaOposta = p.GetComponent<BasePeca>();
                if(!this.check){          
                    switch (pecaOposta.tipo)
                    {
                        case BasePeca.Tipo.peao:
                        this.check = pecaOposta.peao.ScanerCheck(jogo,pecaOposta);
                        break;
                        case BasePeca.Tipo.torre:
                        this.check =  pecaOposta.torre.ScanerCheck(jogo,pecaOposta);
                        break;
                        case BasePeca.Tipo.cavalo:
                        this.check =  pecaOposta.cavalo.ScanerCheck(jogo,pecaOposta);
                        break;
                        case BasePeca.Tipo.bispo:
                        this.check =  pecaOposta.bispo.ScanerCheck(jogo,pecaOposta);
                        break;
                        case BasePeca.Tipo.dama:
                        this.check =  pecaOposta.dama.ScanerCheck(jogo,pecaOposta);
                        break;
                        case BasePeca.Tipo.rei:
                        this.check =  pecaOposta.rei.ScanerCheck(jogo,pecaOposta);
                        break;                
                    }
                }                
            }

            Debug.Log(this.check);

        }

}
