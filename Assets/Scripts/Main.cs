using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main : MonoBehaviour
{
    
  public GameObject efect;
  public Transform casaTab;
  public Mapeamento mapTotal = new Mapeamento();
  public PecasMap mapPecas = new PecasMap();
  Dictionary<string,Vector2> casas = new Dictionary<string, Vector2>();
  Peca[] peca;    
  RaycastHit hit;
  public Peca selected;

  Regras regras;

  
  void Start()
  {
    peca = FindObjectsOfType<Peca>();
    casas = mapTotal.Mapear(casaTab);
    mapPecas.MapearPecas(casas,peca,casaTab);
    regras = new Regras(casas,peca,casaTab);
    regras.MapearTableiro();

  }

  void Update()
  {
      MovimentoPecasInput();

  }

  void MovimentoPecasInput(){
    
    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
          
    bool too = Physics.Raycast(ray,out hit);

    if(too){

      efect.gameObject.SetActive(true);
      efect .gameObject.transform.position = hit.collider.gameObject.transform.position;      
    
      if(Input.GetMouseButtonDown(0)){       

        bool mover = false;

        for(int i = 0;i < peca.Length;i++){
                    
          if(peca[i].casaAtual == hit.collider.gameObject.name){

            if(selected == null || peca[i].lado == selected.lado){
              selected = peca[i];           
              mover = false;
              i = peca.Length;
            }

          }else{
            mover = true;
          }                  
        }

        if(mover && selected != null){

          switch (selected.tipoPeca)
          {
              case Peca.Tipo.Peao:
                regras.PeaoMove(selected,hit.collider.gameObject.name);
              break;
              case Peca.Tipo.bispo:
                regras.BispoMove(selected,hit.collider.gameObject.name);
              break;
              case Peca.Tipo.cavalo:
                regras.CavaloMove(selected,hit.collider.gameObject.name);
              break;
              case Peca.Tipo.torre:
                regras.TorreMove(selected,hit.collider.gameObject.name);
              break;
              case Peca.Tipo.rainha:
                regras.RainhaMove(selected,hit.collider.gameObject.name);
              break;
              case Peca.Tipo.rei:
                regras.ReiMove(selected,hit.collider.gameObject.name);
              break;                            
              default:
              break;
          }

          regras.MapearTableiro();
          mapPecas.attMapPorJogada(casas,peca,casaTab);         
          selected = null;

        }                                        
      
      }

    }else{

      efect.gameObject.SetActive(false);
      
    }
  }

}
