using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChessBoard : MonoBehaviour
{   
    [SerializeField] bool ViewCord;
    [SerializeField] Transform board;
    char[] letras = {'a','b','c','d','e','f','g','h'};
    char[] numeros = {'1','2','3','4','5','6','7','8'};
    string[,] housesName = new string[8,8];

    public Dictionary<string,Vector2> cordPos = new Dictionary<string, Vector2>();
    int indc;

    public List<PecaBase> chessPiecesWhite =  new List<PecaBase>();
    public List<PecaBase> chessPiecesBlack =  new List<PecaBase>();

    PecaBase[] pieces;

    private void Start() {

        pieces = FindObjectsOfType<PecaBase>();

        for(int i = 0;i < pieces.Length;i++){

            if(pieces[i].cor == PecaBase.Cor.Branca){
                chessPiecesWhite.Add(pieces[i]);
            }else  if(pieces[i].cor == PecaBase.Cor.Preta){
                chessPiecesBlack.Add(pieces[i]);
            }           

        }         
        
        for(int y = 0;y < 8;y++){
            for(int x = 0;x < 8;x++){
                
                housesName[x,y] = (letras[x].ToString() + numeros[y].ToString());
                board.GetChild(indc).gameObject.name =  housesName[x,y];
                
                if(!ViewCord)
                    board.GetChild(indc).transform.GetComponentInChildren<TextMesh>().text = "";
                else
                    board.GetChild(indc).transform.GetComponentInChildren<TextMesh>().text = housesName[x,y];

               
               Vector2 v2 = new Vector2(board.GetChild(indc).transform.position.x,board.GetChild(indc).transform.position.z);
               cordPos.Add(housesName[x,y],v2);
               indc++;
               
            }
        }
                  
    }

    private void Update() {
        
       AttMapaGame();

    }

    void AttMapaGame(){

         foreach (PecaBase p in chessPiecesWhite)
        {
             if(cordPos.ContainsKey(p.Cordenada)){
                Vector3 vec = new Vector3(cordPos[p.Cordenada].x,0.9f,cordPos[p.Cordenada].y);
                p.transform.position = vec;
            }
        }

        foreach (PecaBase p in chessPiecesBlack)
        {   
            if(cordPos.ContainsKey(p.Cordenada)){
                Vector3 vec = new Vector3(cordPos[p.Cordenada].x,0.9f,cordPos[p.Cordenada].y);
                p.transform.position = vec;
            }
        }
    }

    public Vector2 pos(string cord){

        return converterPos(cord[0],cord[1]);
        
    }

    Vector2 converterPos(char L, char N){

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

    
    public string cord(Vector2 pos){

        return converterCord((int)pos.x,(int)pos.y);
        
    }

    string converterCord(int x, int y){

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
