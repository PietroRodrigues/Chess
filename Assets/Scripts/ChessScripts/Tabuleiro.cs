using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tabuleiro : MonoBehaviour
{
    [SerializeField] bool ViewCord;
    [SerializeField] Transform tabuleiro = null;
    char[] letras = {'a','b','c','d','e','f','g','h'};
    char[] numeros = {'1','2','3','4','5','6','7','8'};
    string[,] housesName = new string[8,8];
    public List<Transform> pecasBrancas = null;
    public List<Transform> pecasPretas = null;
    public List<Casa> houses = null;
    Dictionary<string,Vector2> casas = new Dictionary<string, Vector2>();  
    int indc;

    // Start is called before the first frame update
    void Start()
    {
        
         NomeiaCasas();

         PosicionaPecaInicial();
        

    }

    // Update is called once per frame
    void Update()
    {
        HudView();
    }

    void NomeiaCasas(){

        for(int y = 0;y < 8;y++){
            for(int x = 0;x < 8;x++){               

                housesName[x,y] = letras[x].ToString() + numeros[y].ToString();
                tabuleiro.GetChild(indc).gameObject.AddComponent<Casa>();
                Casa houseScript = tabuleiro.GetChild(indc).gameObject.GetComponent<Casa>();
                houseScript.CasaCord = housesName[x,y];
                houseScript.gameObject.name = housesName[x,y];
                houseScript.transform.GetComponentInChildren<TextMesh>().text = housesName[x,y];

                Vector2 v2 = new Vector2(houseScript.transform.position.x,houseScript.transform.position.z);
                houses.Add(houseScript);
                casas.Add(housesName[x,y],v2);
                indc++;

            }
         }

    }

    void HudView(){

         for(int i = 0;i < tabuleiro.childCount;i++){           

                if(!ViewCord){
                    tabuleiro.GetChild(i).transform.GetComponentInChildren<MeshRenderer>().enabled = false;
                }else{
                    tabuleiro.GetChild(i).transform.GetComponentInChildren<MeshRenderer>().enabled = true;                                
                }

          }
     
    }

    void PosicionaPecaInicial(){


        for (int i = 0; i < pecasBrancas.Count; i++)
         {
                pecasBrancas[i].gameObject.AddComponent<BasePeca>();
                pecasBrancas[i].gameObject.GetComponent<BasePeca>().cor = BasePeca.Cor.branco;

                 for (int w = 0; w < tabuleiro.childCount; w++)
                 {                   
                     Vector2 casaV2 , pecaV2;

                     pecaV2 = new Vector2( pecasBrancas[i].transform.position.x, pecasBrancas[i].transform.position.z);

                     casaV2 = new Vector2(houses[w].transform.position.x,houses[w].transform.position.z);

                     if(pecaV2 == casaV2){
                         
                         houses[w].hospede =  pecasBrancas[i].GetComponent<BasePeca>();
                         houses[w].hospede.Cordenada = houses[w].CasaCord;
                         houses[w].hospede.tipo = SetTipo(houses[w].hospede);                        

                     }

                 }

         }

         for (int i = 0; i < pecasPretas.Count; i++)
         {
                 pecasPretas[i].gameObject.AddComponent<BasePeca>();
                 pecasPretas[i].gameObject.GetComponent<BasePeca>().cor = BasePeca.Cor.preto;

                 for (int w = 0; w < tabuleiro.childCount; w++)
                 {
                     Vector2 casaV2 , pecaV2;

                     pecaV2 = new Vector2( pecasPretas[i].transform.position.x, pecasPretas[i].transform.position.z);

                     casaV2 = new Vector2(houses[w].transform.position.x,houses[w].transform.position.z);

                     if(pecaV2 == casaV2){

                         houses[w].hospede =  pecasPretas[i].GetComponent<BasePeca>();
                         houses[w].hospede.Cordenada =  houses[w].CasaCord;
                         houses[w].hospede.tipo = SetTipo(houses[w].hospede);

                     }

                 }

         }

    }

    BasePeca.Tipo SetTipo(BasePeca peca){
        
        BasePeca.Tipo tp = BasePeca.Tipo.peao;

        if(peca.Cordenada == "a1" || peca.Cordenada == "h1" || 
        peca.Cordenada == "a8" || peca.Cordenada == "h8"){
            tp =  BasePeca.Tipo.torre;
        }else if(peca.Cordenada == "b1" || peca.Cordenada == "g1" || 
        peca.Cordenada == "b8" || peca.Cordenada == "g8"){
            tp =  BasePeca.Tipo.cavalo;
        }else if(peca.Cordenada == "c1" || peca.Cordenada == "f1" || 
        peca.Cordenada == "c8" || peca.Cordenada == "f8"){
            tp =  BasePeca.Tipo.bispo;
        }else if(peca.Cordenada == "d1" || peca.Cordenada == "d8"){
            tp =  BasePeca.Tipo.dama;
        }else if(peca.Cordenada == "e1" || peca.Cordenada == "e8"){
            tp =  BasePeca.Tipo.rei;
        }

        return tp;

    }

    public void SetaPecasInCord(){

        foreach (Casa c in houses){
             c.hospede = null;
        }

        foreach (Casa c in houses){
        
            foreach (Transform peca in pecasBrancas)
            {
                string cord = peca.GetComponent<BasePeca>().Cordenada;

                if(c.hospede == null){
                    if(peca.GetComponent<BasePeca>().Cordenada == c.CasaCord)
                        c.hospede = peca.GetComponent<BasePeca>();
                
                }

                if(casas.ContainsKey(cord)){

                    Vector3 vec = new Vector3(casas[cord].x,0.9f,casas[cord].y);
                    peca.position = vec;

                }
                
            }

            foreach (Transform peca in pecasPretas)
            {
                string cord = peca.GetComponent<BasePeca>().Cordenada;

                if(c.hospede == null){
                    if(peca.GetComponent<BasePeca>().Cordenada == c.CasaCord)
                        c.hospede = peca.GetComponent<BasePeca>();
                
                }

                if(casas.ContainsKey(cord)){

                    Vector3 vec = new Vector3(casas[cord].x,0.9f,casas[cord].y);
                    peca.position = vec;

                }
                
            }
            
        }


    }

}
