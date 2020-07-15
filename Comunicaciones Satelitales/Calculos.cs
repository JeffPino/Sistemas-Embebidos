using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;

public class Calculos : MonoBehaviour
{
    int dl;
    int dLt;
    int dLs;
    public Dropdown idl;
    public Dropdown idLt;
    public Dropdown idLs;
    public InputField lat;
    public InputField Longt;
    public InputField Longs;
    public InputField fteta;
    public InputField fphi;
    public InputField fdist;
    public InputField ori;
    float l;
    float Lt;
    float Ls;
    float deltaL;
    float aux;
    float Re = 6378;
    float h = 42164;
    float rl;
    float rLt;
    float rLs;
    float azimutpri;
    float teta;
    float dist;
    float azimut;

     string orientacion;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        
    }
    public void Calcular()
    {

        l = float.Parse(lat.text);
        Lt = float.Parse(Longt.text);
        Ls = float.Parse(Longs.text);
        dl = idl.value;
        dLs = idLs.value;
        dLt = idLt.value;
        if (dl == 0)
        {
            orientacion = "n";
            if ((dLs == 0) && (dLt == 0))
            {
                if (Lt > Ls) { orientacion = "NE"; }
                else orientacion = "NO";
            }

            else if ((dLs == 0) && (dLt == 1)) { orientacion = "NO"; }

            else if ((dLs == 1) && (dLt == 0)) { orientacion = "NE"; }

            else
            {
                if (Lt > Ls) { orientacion = "NO"; }
                else orientacion = "NE";
            }


        }
        else
        {
            orientacion = "s";
            if ((dLs == 0) && (dLt == 0))
            {
                if (Lt > Ls) { orientacion = "SE"; }
                else orientacion = "SO";
            }

            else if ((dLs == 0) && (dLt == 1)) { orientacion = "SO"; }

            else if ((dLs == 1) && (dLt == 0)) { orientacion = "SE"; }

            else
            {
                if (Lt > Ls) { orientacion = "SO"; }
                else orientacion = "SE";
            }
        };

        Re = 6378;
        h = 42164;
        rl = l * Mathf.PI / 180;
        rLt = Lt * Mathf.PI / 180;
        rLs = Ls * Mathf.PI / 180;
        rl = l * Mathf.PI / 180;
        deltaL = Mathf.Abs(rLs - rLt);
        aux = ((Mathf.Cos(rl)) * (Mathf.Cos(deltaL)));
        azimutpri = (180 / Mathf.PI) * (Mathf.Atan((Mathf.Tan(deltaL)) / (Mathf.Sin(rl))));
        teta = (180 / Mathf.PI) * (Mathf.Atan((aux - (Re / h)) / (Mathf.Sin(Mathf.Acos(aux)))));
        dist = 35786.04f* Mathf.Sqrt(1+(0.41999f * (1 - aux)));
   
        switch (orientacion)
        {
            case "se":
                azimut = 180 - azimutpri;
                break;
            case "so":
                azimut = 180 + azimutpri;
                break;
            case "ne":
                azimut = azimutpri;
                break;
            default:
                azimut = 360 - azimutpri;
                break;
        }

        fteta.text = teta.ToString();
        fphi.text = azimut.ToString();
        fdist.text = dist.ToString();
        ori.text = orientacion;

    }
}
        

