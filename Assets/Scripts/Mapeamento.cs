using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mapeamento
{  
    Dictionary<string,Vector2> casaPos = new Dictionary<string,Vector2>();

    int casaNumber = 0;
    char[] letras =  {'a','b','c','d','e','f','g','h'};
    char[] numeros = {'1','2','3','4','5','6','7','8'};

    string[,] casas = new string[8,8]; 

    public Dictionary<string,Vector2> Mapear(Transform casaTab){       

        for(int x = 0; x < 8; x++){

            for(int y = 0; y < 8;y++){
                
                casas[x,y] = letras[x].ToString() + numeros[y].ToString();                
                casaTab.GetChild(casaNumber).name = casas[x,y];
                casaTab.GetChild(casaNumber).GetComponentInChildren<TextMesh>().text = casas[x,y];
                Vector2 v2 = new Vector2(casaTab.GetChild(casaNumber).transform.position.x,casaTab.GetChild(casaNumber).transform.position.z);
                casaPos.Add(casaTab.GetChild(casaNumber).name,v2);
                casaNumber ++;          

            }
        }       
        
        return casaPos;

    }

}
