using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasePeca : MonoBehaviour
{
    public Peao peao = new Peao();
    public Bispo bispo= new Bispo();
    public Cavalo cavalo = new Cavalo();
    public Torre torre = new Torre();
    public Dama dama = new Dama();
    public Rei rei = new Rei();   

    [SerializeField] private string cordenada;

    [SerializeField] private string cordInicial;

    public bool movimentada = false;
        
    public string Cordenada { get => cordenada; set => cordenada = value; }
    public string CordInicial { get => cordInicial; set => cordInicial = value; }

    public enum Cor{branco,preto,neutra}
    public Cor cor;

    public enum Tipo{peao, torre, cavalo,bispo, dama, rei,sombra}
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

    public void SetDominio(Tabuleiro jogo){

        switch (this.tipo)
        {
            case BasePeca.Tipo.peao:
             peao.CasasDominio(this,jogo); 
            break;
            case BasePeca.Tipo.torre:
             torre.CasasDominio(this,jogo);
            break;
            case BasePeca.Tipo.cavalo:
             cavalo.CasasDominio(this,jogo);
            break;
            case BasePeca.Tipo.bispo:
             bispo.CasasDominio(this,jogo);
            break;
            case BasePeca.Tipo.dama:
             dama.CasasDominio(this,jogo);
            break;
            case BasePeca.Tipo.rei:
             rei.CasasDominio(this,jogo);
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
