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
        SetaPecasInCord();
    }

    void NomeiaCasas(){

        for(int y = 0;y < 8;y++){
            for(int x = 0;x < 8;x++){

                housesName[x,y] = letras[x].ToString() + numeros[y].ToString();
                tabuleiro.GetChild(indc).gameObject.name = housesName[x,y];

                if(!ViewCord){
                    tabuleiro.GetChild(indc).transform.GetComponentInChildren<TextMesh>().text = "";
                }else{
                    tabuleiro.GetChild(indc).transform.GetComponentInChildren<TextMesh>().text = housesName[x,y];            
                }
                
                Vector2 v2 = new Vector2(tabuleiro.GetChild(indc).transform.position.x,tabuleiro.GetChild(indc).transform.position.z);
                casas.Add(housesName[x,y],v2);
                indc++;

            }
         }

    }

    void PosicionaPecaInicial(){

        for (int i = 0; i < pecasBrancas.Count; i++)
         {
                pecasBrancas[i].gameObject.AddComponent<BasePeca>();

                 for (int w = 0; w < tabuleiro.childCount; w++)
                 {
                     Vector2 casaV2 , pecaV2;

                     pecaV2 = new Vector2( pecasBrancas[i].transform.position.x, pecasBrancas[i].transform.position.z);

                     casaV2 = new Vector2(tabuleiro.GetChild(w).transform.position.x,tabuleiro.GetChild(w).transform.position.z);

                     if(pecaV2 == casaV2){
                         pecasBrancas[i].GetComponent<BasePeca>().Cordenada = tabuleiro.GetChild(w).name;
                     }

                 }

         }
         for (int i = 0; i < pecasPretas.Count; i++)
         {
                 pecasPretas[i].gameObject.AddComponent<BasePeca>();

                 for (int w = 0; w < tabuleiro.childCount; w++)
                 {
                     Vector2 casaV2 , pecaV2;

                     pecaV2 = new Vector2( pecasPretas[i].transform.position.x, pecasPretas[i].transform.position.z);

                     casaV2 = new Vector2(tabuleiro.GetChild(w).transform.position.x,tabuleiro.GetChild(w).transform.position.z);

                     if(pecaV2 == casaV2){
                         pecasPretas[i].GetComponent<BasePeca>().Cordenada = tabuleiro.GetChild(w).name;
                     }

                 }

         }

    }

    void SetaPecasInCord(){
        
        foreach (Transform peca in pecasBrancas)
        {
            string cord = peca.GetComponent<BasePeca>().Cordenada;

            if(casas.ContainsKey(cord)){

                 Vector3 vec = new Vector3(casas[cord].x,0.9f,casas[cord].y);
                 peca.position = vec;

            }
            
        }

        foreach (Transform peca in pecasPretas)
        {
            string cord = peca.GetComponent<BasePeca>().Cordenada;

            if(casas.ContainsKey(cord)){

                 Vector3 vec = new Vector3(casas[cord].x,0.9f,casas[cord].y);
                 peca.position = vec;

            }
            
        }

    }

}
