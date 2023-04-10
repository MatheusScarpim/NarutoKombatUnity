using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Menu : MonoBehaviour
{
    public GameObject Hulk;
    public bool HulkAtivo;
    public GameObject Itachi;
    public bool ItachiAtivo;
    public GameObject NarutoJovem;
    public bool NarutoJovemAtivo;

    public Button Click;

    // Start is called before the first frame update
    void Start()
    {
        Click = GetComponent<Button>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void  AtivarHulk()
    {
        if(HulkAtivo == true)
        {
            Hulk.SetActive(true);
        }
        else
        {
            NarutoJovemAtivo = false;
            NarutoJovem.SetActive(false);
            ItachiAtivo = false;
            Itachi.SetActive(false);
        }
    }

    public void AtivarNarutoJovem()
    {
        if(NarutoJovemAtivo == true)
        {
            NarutoJovem.SetActive(true);
        }
        else
        {
            HulkAtivo = false;
            Hulk.SetActive(false);
            ItachiAtivo = false;
            Itachi.SetActive(false);
        }
    }

    public void AtivarItachi()
    {
        if(ItachiAtivo == true)
        {
            Itachi.SetActive(true);
        }
        else
        {
            HulkAtivo = false;
            Hulk.SetActive(false);
            NarutoJovemAtivo = false;
            NarutoJovem.SetActive(false);
        }
    }
}