using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Peca : MonoBehaviour
{    

    public enum corPeca{Branca,Preta}
    public corPeca lado;

    public enum Tipo{Peao, torre, cavalo, bispo, rainha, rei}

    public bool movimentada;

    public Tipo tipoPeca;

    public string casaAtual;
    public string casaAnterior;

    public string casaSelecionada;

    List<Vector2> posFutures = new List<Vector2>();


}
