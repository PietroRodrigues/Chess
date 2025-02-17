using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class XadrezProperts
{
    public Vector2 CordToVector(string cord){

        return cordToVector(cord[0],cord[1]);
        
    }

    public void ApliqueDominio(BasePeca peca,Casa[] casaDirection){        
        
        for (int i = 0; i < casaDirection.Length; i++)
        {            
            if(casaDirection[i] != null){         
                if(casaDirection[i].hospede == null || casaDirection[i].hospede.tipo == BasePeca.Tipo.sombra){

                    casaDirection[i].dominio = peca.cor;                        

                }else{
                    if(casaDirection[i].hospede.tipo == BasePeca.Tipo.rei && casaDirection[i].hospede.cor != peca.cor){
                        casaDirection[i].dominio = peca.cor;
                    }else{
                        casaDirection[i].dominio = peca.cor;
                        i = casaDirection.Length;
                    }
                }
            }

        }

    }

    public BasePeca GetKing(Tabuleiro jogo, BasePeca.Cor corRei){

        BasePeca rei = null;
                
        foreach (Casa casa in jogo.houses)
        {    
            if(casa.hospede != null){
                if(casa.hospede.tipo == BasePeca.Tipo.rei){                    
                    if(casa.hospede.cor == corRei){
                        return casa.hospede;
                    }
                }                    
            }
        }

        return rei;
        
    }

    Vector2 cordToVector(char L, char N){

       int letra = 0;
       int numero = 0;

       switch (L)
       {
            case 'a':
                letra = 1;
            break;
            case 'b':
                letra = 2;
            break;
            case 'c':
                letra = 3;
            break;
            case 'd':
                letra = 4;
            break;
            case 'e':
                letra = 5;
            break;
            case 'f':
                letra = 6;
            break;
            case 'g':
                letra = 7;
            break;
            case 'h':
                letra = 8;
            break;
           
       }

       switch (N)
       {
            case '1':
                numero = 1;
            break;
            case '2':
                numero = 2;
            break;
            case '3':
                numero = 3;
            break;
            case '4':
                numero = 4;
            break;
            case '5':
                numero = 5;
            break;
            case '6':
                numero = 6;
            break;
            case '7':
                numero = 7;
            break;
            case '8':
                numero = 8;
            break;           
       }

       return new Vector2(letra,numero);       
   }

    public string VectorToPos(Vector2 pos){

        return vectorToPos((int)pos.x,(int)pos.y);
        
    }

    string vectorToPos(int x, int y){

       char letra = ' ';
       char numero = ' ';

       switch (x)
       {
            case 1:
                letra = 'a';
            break;
            case 2:
                letra = 'b';
            break;
            case 3:
                letra = 'c';
            break;
            case 4:
                letra = 'd';
            break;
            case 5:
                letra = 'e';
            break;
            case 6:
                letra = 'f';
            break;
            case 7:
                letra = 'g';
            break;
            case 8:
                letra = 'h';
            break;
           
       }

       switch (y)
       {
            case 1:
                numero = '1';
            break;
            case 2:
                numero = '2';
            break;
            case 3:
                numero = '3';
            break;
            case 4:
                numero = '4';
            break;
            case 5:
                numero = '5';
            break;
            case 6:
                numero = '6';
            break;
            case 7:
                numero = '7';
            break;
            case 8:
                numero = '8';
            break;           
       }

       return letra.ToString() + numero.ToString();       
   }
}
