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

        int xAtual = converterParaNumero(pecaSelected.casaAtual[0]);
        int yAtual = converterParaNumero(pecaSelected.casaAtual[1]);
        int xTg = converterParaNumero(tg[0]);
        int yTg = converterParaNumero(tg[1]); 

        //int variaLado = 0;      
        
        Debug.Log(pecaSelected.casaAtual[0] + "," + tg[0]);
        Debug.Log(xTg + "," + xAtual);
        bool podeMover = false;

        if((pecaSelected.lado == Peca.corPeca.Branca && xTg > xAtual) || (pecaSelected.lado == Peca.corPeca.Preta && xTg < xAtual))
        podeMover = true;
        
        if(podeMover == true){
            if(pecaSelected.lado == Peca.corPeca.Branca){
                if(pecaSelected.movimentada == false && (yTg == yAtual && xTg <= xAtual + 2)){
                        
                    Debug.Log("Entro");                        
                    pecaSelected.casaSelecionada = tg;
                    pecaSelected.movimentada = true;                
                
                }else if(yTg == yAtual && xTg <= xAtual + 1){
                    
                    pecaSelected.casaSelecionada = tg;
                    pecaSelected.movimentada = true; 

                }
            }else if(pecaSelected.lado == Peca.corPeca.Preta){
                
                if(pecaSelected.movimentada == false && (yTg == yAtual && xTg >= xAtual - 2)){
                        
                    Debug.Log("Entro");                        
                    pecaSelected.casaSelecionada = tg;
                    pecaSelected.movimentada = true;                
                
                }else if(yTg == yAtual && xTg >= xAtual - 1){
                    
                    pecaSelected.casaSelecionada = tg;
                    pecaSelected.movimentada = true; 

                }
            }
        }    


    }

    public void TorreMove(Peca selected, string tg){

        char x = tg[0];
        char y = tg[1];

        if(selected.movimentada == false){                              
                    
            
        }else{


        }     

    }

    public void CavaloMove(Peca selected, string tg){

        char x = tg[0];
        char y = tg[1];

    }

    public void BispoMove(Peca selected, string tg){
        
        char x = tg[0];
        char y = tg[1];

    }

    public void RainhaMove(Peca selected, string tg){

        char x = tg[0];
        char y = tg[1];

    }

    public void ReiMove(Peca selected, string tg){

        char x = tg[0];
        char y = tg[1];

        if(selected.movimentada == false){
                            
            
        }else{


        }     

    }

    void RockMovimente(Peca selected, string tg){

    }

    void LaPasata(Peca selected, string tg){

    }
    #endregion

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
            case '1':
                n = 1;
            break;
            case '2':
                n = 2;
            break;
            case '3':
                n = 3;
            break;
            case '4':
                n = 4;
            break;
            case '5':
                n = 5;
            break;
            case '6':
                n = 6;
            break;
            case '7':
                n = 7;
            break;
            case '8':
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
