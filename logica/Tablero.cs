using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    /*
    public enum Ficha
    {
            Vacio,
            Jugador1,
            Jugador2
    }

    public class cFicha
    {
        public static Ficha Not(Ficha f)
        {
            if (f == Ficha.Jugador1)
                return Ficha.Jugador2;
            else if (f == Ficha.Jugador2)
                return Ficha.Jugador1;
            else
                return Ficha.Vacio;
        }
    }
    */

    /*public class Coord
    {
        public int x;
        public int y;
    }
    */

    public class Tablero
    {
        private int DIMENSION_X;
        private int DIMENSION_Y;

        public int DimX
        {
            get
            {
                return DIMENSION_X;
            }
            set
            {
                DIMENSION_X = value;
            }
        }
        public int DimY
        {
            get
            {
                return DIMENSION_Y;
            }
            set
            {
                DIMENSION_Y = value;
            }
        }


        public int[,] Pos; //= new int[DIMENSION_X, DIMENSION_Y];

        public int Turno; //jugador actual


        public Tablero(int TurnoInicial, int iDimension)
        {
            PonerDimension(iDimension);

            //inicializa tablero vacio
            Pos = new int[DimX, DimY];
            int x, y;
            for (y = 0; y < DimY; y++)
            {
                for (x = 0; x < DimX; x++)
                {
                    Pos[x, y] = 0;
                }
            }

            //turno inicial
            Turno = TurnoInicial;
        }

        public Tablero(int iDimension)
        {
            PonerDimension(iDimension);

            //inicializa tablero vacio
            Pos = new int[DimX, DimY];
            int x, y;
            for (y = 0; y < DimY; y++)
            {
                for (x = 0; x < DimX; x++)
                {
                    Pos[x, y] = 0;
                }
            }
        }

        private void PonerDimension(int Dimension)
        {
            this.DIMENSION_X = Dimension;
            this.DIMENSION_Y = Dimension;
        }
        
        public void PonerFicha(int x, int y)
        {
            this.Pos[x, y] = Turno;
            //turno = -turno;
        }

        public void Copia(Tablero Tab)
        {
            int x, y;
            for (y = 0; y < DimY; y++)
            {
                for (x = 0; x < DimX; x++)
                {
                    this.Pos[x, y] = Tab.Pos[x, y];
                }
            }
        }

        public bool EvaluaEmpate()
        {
            bool bLleno = true;
            int x, y;
            for (y = 0; y < DimY && bLleno; y++)
            {
                for (x = 0; x < DimX && bLleno; x++)
                {
                    if (this.Pos[x, y] == 0)
                        bLleno = false;
                }
            }
            return bLleno;
        }

        public int EvaluaVictoria()
        {
            //recorrer horizontales, luego verticales, luego diagonales, ver victoria
            int iReturn = 0;
            int x, y;
            bool bIguales;
            int jug;
            const int jug_null = -999;

            //horizontales
            for (y = 0; y < DimY && (iReturn == 0); y++)
            {
                bIguales = true;
                jug = jug_null;
                for (x = 0; x < DimX && bIguales; x++)
                {
                    if (jug == jug_null)
                        jug = Pos[x,y];
                    else if (Pos[x, y] != jug)
                        bIguales = false;
                }
                if (bIguales && (jug != 0))
                {
                    iReturn = jug;
                }
            }
            if (iReturn == 0)
            {
                //verticales
                for (x = 0; x < DimX && (iReturn == 0); x++)
                {
                    bIguales = true;
                    jug = jug_null;
                    for (y = 0; y < DimY && bIguales; y++)
                    {
                        if (jug == jug_null)
                            jug = Pos[x, y];
                        else if (Pos[x, y] != jug)
                            bIguales = false;
                    }
                    if (bIguales && (jug != 0))
                    {
                        iReturn = jug;
                    }
                }
            }
            if (iReturn == 0)
            {
                //diagonal 1
                bIguales = true;
                jug = jug_null;
                for (x = 0, y = 0; x < DimX && y < DimY && bIguales; x++, y++)
                {
                    if (jug == jug_null)
                        jug = Pos[x, y];
                    else if (Pos[x, y] != jug)
                        bIguales = false;
                }
                if (bIguales && (jug != 0))
                {
                    iReturn = jug;
                }
                else
                {
                    //diagonal 2
                    bIguales = true;
                    jug = jug_null;
                    for (x = DimX - 1, y = 0; x >= 0 && y < DimY && bIguales; x--, y++)
                    {
                        if (jug == jug_null)
                            jug = Pos[x, y];
                        else if (Pos[x, y] != jug)
                            bIguales = false;
                    }
                    if (bIguales && (jug != 0))
                    {
                        iReturn = jug;
                    }
                }
            }
            return iReturn;

            /*
            int[,,] Vic = new int[8, 3, 2] { { { 0, 0 }, { 0, 1 }, { 0, 2 } }, 
                                             { { 1, 0 }, { 1, 1 }, { 1, 2 } },
                                             { { 2, 0 }, { 2, 1 }, { 2, 2 } },
                                             { { 0, 0 }, { 1, 0 }, { 2, 0 } },
                                             { { 0, 1 }, { 1, 1 }, { 2, 1 } },
                                             { { 0, 2 }, { 1, 2 }, { 2, 2 } },
                                             { { 0, 0 }, { 1, 1 }, { 2, 2 } },
                                             { { 2, 0 }, { 1, 1 }, { 0, 2 } } };
            int ganador = 0;
            int i;
            for (i = 0; i < 8; i++)
            {
                if ((this.Pos[Vic[i, 0, 0], Vic[i, 0, 1]] == this.Pos[Vic[i, 1, 0], Vic[i, 1, 1]]) &&
                    (this.Pos[Vic[i, 1, 0], Vic[i, 1, 1]] == this.Pos[Vic[i, 2, 0], Vic[i, 2, 1]]) &&
                    (this.Pos[Vic[i, 0, 0], Vic[i, 0, 1]] != 0) )
                {
                    ganador = this.Pos[Vic[i, 0, 0], Vic[i, 0, 1]];
                }
            }
            return ganador;
            */
        }

    }

    public class Movimiento
    {
        public int valor;
        public int x;
        public int y;
        public int Z;

        public Movimiento()
        {
            valor = 0;
            x = 0;
            y = 0;
            Z = 0;
        }
    }
}
