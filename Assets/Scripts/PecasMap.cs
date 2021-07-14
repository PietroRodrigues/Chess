using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PecasMap
{
    public void MapearPecas(Dictionary<string,Vector2> casas,Peca[] peca,Transform casaTab){

        for(int i = 0;i < peca.Length; i++){
            
           Peca p = peca[i];
            
           p.movimentada = false;            
            
            for(int y = 0;y < casaTab.childCount;y++){
    
               p.transform.position = new Vector3(casas[p.casaAtual].x,0.9f,casas[p.casaAtual].y);
               
            }           

        }

    }

    public void attMapPorJogada(Dictionary<string,Vector2> casas,Peca[] peca,Transform casaTab){
         
        for(int i = 0;i < peca.Length; i++){
         
            if(peca[i].casaSelecionada != ""){
                peca[i].casaAnterior =  peca[i].casaAtual;
                peca[i].casaAtual =  peca[i].casaSelecionada;
                peca[i].movimentada = true;       
            
            for(int y = 0;y < casaTab.childCount;y++){
        
                if(casas.ContainsKey(peca[i].casaAtual))
                    peca[i].transform.position = new Vector3(casas[peca[i].casaAtual].x,0.9f,casas[peca[i].casaAtual].y);
                
            }

                peca[i].casaSelecionada = "";
            }    

        }

    }

}
