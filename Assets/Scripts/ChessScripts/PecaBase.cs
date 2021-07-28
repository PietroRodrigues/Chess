using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PecaBase : MonoBehaviour
{  
    Peao peao = new Peao();
    Bispo bispo= new Bispo();
    Cavalo cavalo = new Cavalo();
    Torre torre = new Torre();
    Rainha rainha = new Rainha();
    Rei rei = new Rei();

    public enum Cor{Branca,Preta}
    public Cor cor;

    public enum Tipo{Peao, torre, cavalo, bispo, rainha, rei}

    public Tipo tipo;

    [SerializeField] string cordenada;

    public string Cordenada { get => cordenada; set => cordenada = value; }

    private void Start() {

        switch (tipo)
        {
            case PecaBase.Tipo.Peao:
            
            break;
            case PecaBase.Tipo.torre:
            
            break;
            case PecaBase.Tipo.cavalo:
                
            break;
            case PecaBase.Tipo.bispo:
            
            break;
            case PecaBase.Tipo.rainha:
                
            break;
            case PecaBase.Tipo.rei:

            break;
           
        }

    }

}
