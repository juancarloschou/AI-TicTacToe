using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Logica
{
    public class IA
    {
        private int MAX_PROFUNDIDAD;
        public int Profundidad
        {
            get
            {
                return MAX_PROFUNDIDAD;
            }
            set
            {
                MAX_PROFUNDIDAD = value;
            }
        }

        public Tablero Partida = null;

        public int Dimension;

        public int TurnoAct; // numero de turno actual (empieza en 0 = antes empezar);

        public IA(int JugadorInicial, int iDimension, int iProfundidad)
        {
            TurnoAct = 0;
            Dimension = iDimension;
            Profundidad = iProfundidad;
            Partida = new Tablero(JugadorInicial, iDimension);
        }

        /*public IA(int iDimension)
        {
            Dimension = iDimension;
            Partida = new Tablero(iDimension);
        }*/


        public void JugarHumano(int x, int y)
        {
            Partida.PonerFicha(x, y);
        }

        public Movimiento JugarOrdenador()
        {
            Movimiento mejor = MiniMax(Partida, 0, Partida.Turno);
            Partida.PonerFicha(mejor.x, mejor.y);
            return mejor;
        }

        private Movimiento MiniMax(Tablero Tab, int Z, int jugador)
        {
            Movimiento ganador = new Movimiento();
            ganador.Z = Z;

            ganador.valor = Tab.EvaluaVictoria();
            if (ganador.valor != 0 || Tab.EvaluaEmpate() || Z > Profundidad)
            {
                //hay 3 en raya mio o del otro, o partida terminada en empate, o llegamos al maximo de profundidad
                return ganador; //1, -1, 0
            }
            else
            {
                const int gan_null = -9999;
                ganador.valor = gan_null;
                Movimiento g;
                int x, y;
                for (y = 0; y < Tab.DimY; y++)
                {
                    for (x = 0; x < Tab.DimX; x++)
                    {
                        if (Tab.Pos[x, y] == 0)
                        {
                            Tablero TabAux = new Tablero(this.Dimension);
                            TabAux.Copia(Tab); 
                            TabAux.Pos[x, y] = jugador;

                            int otro_jug = -jugador; //alterna jugador
                            g = MiniMax(TabAux, Z + 1, otro_jug);

                            //hacer bucle q devuelva todas las posibilidades ya pesadas
                            //escoger la de victoria con menor profundidad (ganar antes)
                            //meter random en empates y/o heuristica (ptos por tener centro y mas fichas en linea no bloqueada y mas lineas no bloqueadas a la vez)

                            if (ganador.valor == gan_null || 
                                ( (jugador == -1) && ( (g.valor < ganador.valor) || ((g.valor == ganador.valor) && (g.Z < ganador.Z)) ) ) ||
                                ( (jugador == 1)  && ( (g.valor > ganador.valor) || ((g.valor == ganador.valor) && (g.Z < ganador.Z)) ) )   )
                            //if (g.valor > ganador.valor)
                            {
                                ganador.valor = g.valor;
                                ganador.x = x;
                                ganador.y = y;
                                ganador.Z = g.Z;
                            }
                        }
                    }
                }
                if (ganador.valor == gan_null)
                    ganador.valor = 0;
                return ganador;
            }
        }


    }

    /*
    class Minimax
    {
        Arbol<TableroIA> MinMax = new Arbol<TableroIA>();

        public Minimax()
        {
            MinMax = null;
        }
    }
    */



}