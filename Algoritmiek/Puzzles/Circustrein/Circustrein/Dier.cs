﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Circustrein
{
    enum Formaat
    {
        klein,
        middel,
        groot
    }
    class Dier
    {
        public bool vleesEter{ private set; get; }
        Formaat formaat;

        public Dier(bool vleesEter, Formaat formaat)
        {
            this.vleesEter = vleesEter;
            this.formaat = formaat;
        }


        public int GetPuntIndex()
        {
            switch (formaat)
            {
                case Formaat.klein:
                    return 1;
                case Formaat.middel:
                    return 3;
                case Formaat.groot:
                    return 5;

            }
            return 0;
        }

        public override string ToString()
        {
            string eter = vleesEter ? "vleesEter" : "nietVleesEter";
            return formaat.ToString() + " " + eter + "| " ;
        }
    }
}