using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePeca : MonoBehaviour
{
    Peao peao = new Peao();
    Bispo bispo= new Bispo();
    Cavalo cavalo = new Cavalo();
    Torre torre = new Torre();
    Dama dama = new Dama();
    Rei rei = new Rei();

    [SerializeField] private string cordenada;

    public bool movimentada = false;

    nada = nada;

    public string Cordenada { get => cordenada; set => cordenada = value; }

    public enum Cor{branco,preto}
    public Cor cor;

    public enum Tipo{peao, torre, cavalo,bispo, dama, rei}
    public Tipo tipo;

    public string MoveTipo(BasePeca peca,Casa casaTG,Tabuleiro jogo){
        
        string cord = "";

        switch (peca.tipo)
        {
            case BasePeca.Tipo.peao:
             cord = peao.Mover(peca,casaTG,jogo); 
            break;
            case BasePeca.Tipo.torre:
             cord = torre.Mover(peca,casaTG,jogo);
            break;
            case BasePeca.Tipo.cavalo:
             cord = cavalo.Mover(peca,casaTG,jogo);
            break;
            case BasePeca.Tipo.bispo:
             cord = bispo.Mover(peca,casaTG,jogo);
            break;
            case BasePeca.Tipo.dama:
             cord = dama.Mover(peca,casaTG,jogo);
            break;
            case BasePeca.Tipo.rei:
             cord = rei.Mover(peca,casaTG,jogo);
            break;
           
        }

        return cord;

    }

    public void EfeitosCasasPosiveis(BasePeca peca,Tabuleiro jogo,Transform EfectMove,Transform EfectCapture){       
       
        switch (peca.tipo)
        {
            case BasePeca.Tipo.peao:
             peao.EfectAtive(peca,jogo,EfectMove,EfectCapture); 
            break;
            case BasePeca.Tipo.torre:
             torre.EfectAtive(peca,jogo,EfectMove,EfectCapture);
            break;
            case BasePeca.Tipo.cavalo:
             cavalo.EfectAtive(peca,jogo,EfectMove,EfectCapture);
            break;
            case BasePeca.Tipo.bispo:
             bispo.EfectAtive(peca,jogo,EfectMove,EfectCapture);
            break;
            case BasePeca.Tipo.dama:
             dama.EfectAtive(peca,jogo,EfectMove,EfectCapture);
            break;
            case BasePeca.Tipo.rei:
             rei.EfectAtive(peca,jogo,EfectMove,EfectCapture);
            break;           
           
        }

    }

    public static void ClearEfect(Transform EfectMove,Transform EfectCapture){

        foreach (Transform efects in EfectMove)
        {
            efects.gameObject.SetActive(false);
            efects.position = EfectMove.position;            
        }

        foreach (Transform efects in EfectCapture)
        {
            efects.gameObject.SetActive(false);
            efects.position = EfectCapture.position;            
        }

    }

    
}
