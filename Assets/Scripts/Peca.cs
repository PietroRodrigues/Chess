using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peca : MonoBehaviour
{    

    public Transform movementos;
    public enum corPeca{Branca,Preta}
    public corPeca lado;

    public bool selected;

    public enum Tipo{Peao, torre, cavalo, bispo, rainha, rei}

    public bool movimentada;

    public Tipo tipoPeca;

    public string casaAtual;
    public string casaAnterior;

    public string casaSelecionada;

    List<Vector2> posFutures = new List<Vector2>();
    
    bool pecaCapturada = false;

    public void PecaMorta(){

        pecaCapturada = true;
        this.gameObject.GetComponentInChildren<MeshRenderer>().enabled = false;
        this.enabled = false;       

    }


}
