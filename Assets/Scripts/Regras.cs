using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regras
{
    Dictionary<string,Vector2> casas;

    Dictionary<string,Peca> casaUsadas = new Dictionary<string, Peca>();

    Peca[] peca;
    Transform casaTab;
    
    public Regras(Dictionary<string,Vector2> casas,Peca[] peca,Transform casaTab){
        
        this.peca = peca;
        this.casas = casas;
        this.casaTab = casaTab;

    }

    #region Movimento das Pecas
    public void PeaoMove(Peca pecaSelected, string tg){

        char xCord = CordenadaSplit(pecaSelected.casaAtual, 1);
        char yCord = CordenadaSplit(pecaSelected.casaAtual, 1);        
        int xAtual = converterParaNumero(xCord);
        int yAtual = Convert.ToInt32(yCord);

        int xTg = converterParaNumero(CordenadaSplit(tg, 1));
        int yTg = converterParaNumero(CordenadaSplit(tg, 2));  

        if(pecaSelected.movimentada == false){   
           
             if(xTg == xAtual && yTg == yAtual ){
                if( !casaUsadas.ContainsKey((converterParaLetra(xAtual + 1)) + yAtual.ToString()))
                {                       
                    pecaSelected.casaSelecionada = tg;
                    pecaSelected.movimentada = true;                  
                    
                }
             }
                
            
            
        }else{


        }      


    }

    public void TorreMove(Peca selected, string tg){

        char x = CordenadaSplit(selected.casaAtual, 1);
        char y = CordenadaSplit(selected.casaAtual, 2);

        if(selected.movimentada == false){                              
                    
            
        }else{


        }     

    }

    public void CavaloMove(Peca selected, string tg){

        char x = CordenadaSplit(selected.casaAtual, 1);
        char y = CordenadaSplit(selected.casaAtual, 2);

    }

    public void BispoMove(Peca selected, string tg){
        char x = CordenadaSplit(selected.casaAtual, 1);
        char y = CordenadaSplit(selected.casaAtual, 2);

    }

    public void RainhaMove(Peca selected, string tg){

        char x = CordenadaSplit(selected.casaAtual, 1);
        char y = CordenadaSplit(selected.casaAtual, 2);

    }

    public void ReiMove(Peca selected, string tg){

        char x = CordenadaSplit(selected.casaAtual, 1);
        char y = CordenadaSplit(selected.casaAtual, 2);

        if(selected.movimentada == false){
                            
            
        }else{


        }     

    }

    void RockMovimente(Peca selected, string tg){

    }

    void LaPasata(Peca selected, string tg){

    }
    #endregion
    
    char CordenadaSplit(string cordenada, int xy){
                   
        char x = cordenada[0];
        char y = cordenada[1];

        if(xy == 1){
            return x;
        }
        else if(xy == 2){
         
           return y;

        }else{
            return ' ';
        }
        
    }


    int converterParaNumero(char digito){

        int n = 0;

        switch (digito)
        {           
            case 'a':
                n = 1;
            break;
            case 'b':
                n = 2;
            break;
            case 'c':
                n = 3;
            break;
            case 'd':
                n = 4;
            break;
            case 'e':
                n = 5;
            break;
            case 'f':
                n = 6;
            break;
            case 'g':
                n = 7;
            break;
            case 'h':
                n = 8;
            break;           
        }
        
        return n;

    }

    char converterParaLetra(int digito){

        char L = ' ';

        switch (digito)
        {           
            case 1:
                L = 'a';
            break;
            case 2:
                L = 'b';
            break;
            case 3:
                L = 'c';
            break;
            case 4:
                L = 'd';
            break;
            case 5:
                L = 'e';
            break;
            case 6:
                L = 'f';
            break;
            case 7:
                L = 'g';
            break;
            case 8:
                L = 'h';
            break;           
        }
        
        return L;

    }

    public void MapearTableiro(){

        casaUsadas.Clear();

        for(int i = 0;i <  casaTab.childCount;i++){
            for(int w = 0;w < peca.Length;w++){
                if(casaTab.GetChild(i).name == peca[w].casaAtual){
                    casaUsadas.Add(casaTab.GetChild(i).name,peca[w]);
                }
            }
        }    

    }

}
