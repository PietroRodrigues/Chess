using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peao : XadrezProperts
{
    string destino;

    BasePeca King;

    Casa[] casasDispoN;
    Casa[] casasDispoS;
    Casa[] casasDispoNL;
    Casa[] casasDispoSO;
    Casa[] casasDispoNO;
    Casa[] casasDispoSL;

    public GameObject enPassantAlvo = null;
    public BasePeca peaoVinculo = null;


    public string Mover(BasePeca peca,Casa casaTG,Tabuleiro jogo){

        King = GetKing(jogo,peca.cor);

        int n = (peca.movimentada)? 1 : 2;
        
        destino = peca.Cordenada;

        if(peca.cor == BasePeca.Cor.branco){
            casasDispoN = new Casa[n];
            casasDispoNL = new Casa[1];
            casasDispoNO = new Casa[1];
        }else if(peca.cor == BasePeca.Cor.preto){
            casasDispoS = new Casa[n];      
            casasDispoSO = new Casa[1];
            casasDispoSL = new Casa[1];
        }             
        
        ScanCasasPosiveis(jogo, peca);

        //Regra de Movimento-----------
        if(peca.cor == BasePeca.Cor.branco){
            RegraMovimentes(peca,casasDispoN,casaTG,jogo);
            RegraMovimentes(peca,casasDispoNL,casaTG,jogo);
            RegraMovimentes(peca,casasDispoNO,casaTG,jogo);
        }else if(peca.cor == BasePeca.Cor.preto){
            RegraMovimentes(peca,casasDispoS,casaTG,jogo);
            RegraMovimentes(peca,casasDispoSO,casaTG,jogo);      
            RegraMovimentes(peca,casasDispoSL,casaTG,jogo);
        }                    
        //---------------------------------
                
        return destino;
        
    }

    public void EfectAtive(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){

        King = GetKing(jogo,peca.cor);

        int n = (peca.movimentada)? 1 : 2;

        if(peca.cor == BasePeca.Cor.branco){
            casasDispoN = new Casa[n];
            casasDispoNL = new Casa[1];
            casasDispoNO = new Casa[1];
        }else if(peca.cor == BasePeca.Cor.preto){
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
                        casasDispoNL[j] = jogo.houses[i];
                    }

                }
                for (int j = 0; j < casasDispoNO.Length; j++)
                {
                    if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y + (1+j)){
                        casasDispoNO[j] = jogo.houses[i];
                    }

                }
            }else if(peca.cor == BasePeca.Cor.preto){
                for (int j = 0; j < casasDispoS.Length; j++)
                {
                    if(v2houses.x == v2Peca.x && v2houses.y == v2Peca.y - (1+j)){
                        casasDispoS[j] = jogo.houses[i];
                    }
                }
                for (int j = 0; j < casasDispoSO.Length; j++)
                {
                    if(v2houses.x == v2Peca.x - (1+j) && v2houses.y == v2Peca.y - (1+j)){
                        casasDispoSO[j] = jogo.houses[i];
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
    }

    public void CasasDominio(BasePeca peca,Tabuleiro jogo){  
        
        int n = (peca.movimentada)? 1 : 2;

        if(peca.cor == BasePeca.Cor.branco){
            casasDispoN = new Casa[n];
            casasDispoNL = new Casa[1];
            casasDispoNO = new Casa[1];
        }else if(peca.cor == BasePeca.Cor.preto){
            casasDispoS = new Casa[n];        
            casasDispoSO = new Casa[1];        
            casasDispoSL = new Casa[1];        
        } 

        ScanCasasPosiveis(jogo, peca);

        if(peca.cor == BasePeca.Cor.branco){
            ApliqueDominio(peca,casasDispoNL);
            ApliqueDominio(peca,casasDispoNO);
        }else if(peca.cor == BasePeca.Cor.preto){
            ApliqueDominio(peca,casasDispoSL);
            ApliqueDominio(peca,casasDispoSO);      
        }
    }

    void EfectsDistribuite(BasePeca peca,Casa[] casaDirection,Transform EfectMove,Transform EfectCapture){

        for (int i = 0; i < casaDirection.Length; i++)
        {            
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null){
                    if(casaDirection[i].CasaCord[0] == peca.Cordenada[0]){

                        for (int j = 0; j < EfectMove.childCount; j++)
                        {
                            if(!EfectMove.GetChild(j).gameObject.activeSelf){                
                                Transform  efect = EfectMove.GetChild(j);
                                efect.position = casaDirection[i].transform.position;
                                efect.gameObject.SetActive(true);
                                j = EfectMove.childCount;
                            }    
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

    void RegraMovimentes(BasePeca peca,Casa[] casaDirection,Casa casaTG,Tabuleiro jogo){

        for (int i = 0; i < casaDirection.Length; i++)
        {
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null){
                    if(casaDirection[i].CasaCord[0] == peca.Cordenada[0]){
                        if(casaDirection[i].CasaCord == casaTG.CasaCord){
                                                  
                            if(i == 1){
                                    peca.peao.enPassantAlvo = GameObject.CreatePrimitive(PrimitiveType.Cube);

                                    if(peca.peao.enPassantAlvo.GetComponent<MeshRenderer>() != null)
                                    GameObject.Destroy(peca.peao.enPassantAlvo.GetComponent<MeshRenderer>());

                                    if(peca.peao.enPassantAlvo.GetComponent<BoxCollider>() != null)
                                    GameObject.Destroy(peca.peao.enPassantAlvo.GetComponent<BoxCollider>());

                                    if(peca.peao.enPassantAlvo.GetComponent<BasePeca>() == null){
                                        peca.peao.enPassantAlvo.AddComponent<BasePeca>();                            
                                    }                                    

                                    peca.peao.enPassantAlvo.GetComponent<BasePeca>().gameObject.name = "enPassantAlvo";
                                    peca.peao.enPassantAlvo.GetComponent<BasePeca>().Cordenada = casaDirection[0].CasaCord;
                                    casaDirection[0].hospede =  peca.peao.enPassantAlvo.GetComponent<BasePeca>();
                                    peca.peao.enPassantAlvo.GetComponent<BasePeca>().peao.peaoVinculo = peca;
                                    peca.peao.enPassantAlvo.GetComponent<BasePeca>().cor = peca.cor;
                                    peca.peao.enPassantAlvo.GetComponent<BasePeca>().tipo = BasePeca.Tipo.sombra;
                                    
                                    if(peca.cor == BasePeca.Cor.branco){
                                        jogo.pecasBrancas.Add(peca.peao.enPassantAlvo.GetComponent<BasePeca>().gameObject.transform);
                                    }else if(peca.cor == BasePeca.Cor.preto){
                                        jogo.pecasPretas.Add(peca.peao.enPassantAlvo.GetComponent<BasePeca>().gameObject.transform);
                                    }
                                    

                                    peca.peao.enPassantAlvo.transform.position = casaDirection[0].transform.position;
                                }
                             
                            peca.movimentada = true;
                            destino = casaTG.CasaCord;
                            
                        }
                    }
                }else{

                    if(casaDirection[i].hospede.cor != peca.cor){
                        if(CordToVector(casaDirection[i].CasaCord).x == CordToVector(peca.Cordenada).x + 1 || CordToVector(casaDirection[i].CasaCord).x == CordToVector(peca.Cordenada).x - 1){                         
                            if(casaDirection[i].CasaCord == casaTG.CasaCord){
                                peca.movimentada = true;
                                destino = casaTG.CasaCord;
                            }else{
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
