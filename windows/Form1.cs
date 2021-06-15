using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Logica;

namespace windows
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        public IA Juego = null;

        public static bool bEsperarJugador = false;
        public int JugX;
        public int JugY;

        readonly object stateLock = new object();


        private void Form1_Load(object sender, EventArgs e)
        {
            cmbNumCasillas.Items.Add(3);
            cmbNumCasillas.Items.Add(4);
            cmbNumCasillas.Items.Add(5);

            cmbNumCasillas.SelectedIndex = 0; //3 dimensiones
            int iDimension = (int)cmbNumCasillas.Items[cmbNumCasillas.SelectedIndex];
            Juego = new IA(0, iDimension, 0);
            VisualizarTablero(pctTablero);
        }

        private void cmbNumCasillas_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (Juego != null)
            {
                int iDimension = (int)cmbNumCasillas.Items[cmbNumCasillas.SelectedIndex];
                Juego = new IA(0, iDimension, 0);
                VisualizarTablero(pctTablero);
            }
        }

        /*
        public void VisualizarTablero(TextBox txt)
        {
            string sResult = "";

            Tablero Tab = Juego.Partida;
            int x, y;
            for (y = 0; y < Tablero.DIMENSION_Y; y++)
            {
                for (x = 0; x < Tablero.DIMENSION_X; x++)
                {
                    switch (Tab.Pos[x, y])
                    {
                        case 0: sResult += "."; break;
                        case 1: sResult += "X"; break;
                        case -1: sResult += "O"; break;
                    }
                    if (x < Tablero.DIMENSION_X - 1)
                    {
                        sResult += " | ";
                    }
                }
                sResult += "\r\n";
                if (y < Tablero.DIMENSION_Y - 1)
                {
                    sResult += "---------";
                }
                sResult += "\r\n";
            }

            txt.Text = sResult;            
        }
        */

        public void VisualizarTablero(PictureBox pct)
        {
            pct.Refresh();
        }

        private void pctTablero_Paint(object sender, PaintEventArgs e)
        {
            if (Juego != null)
            {
                Tablero Tab = Juego.Partida;
                //dibuja las lineas separadoras tablero
                int x, y;
                for (y = 0; y <= Tab.DimY; y++)
                {
                    e.Graphics.DrawLine(Pens.Black, 0, y * 100, Tab.DimX * 100, y * 100);
                }
                for (x = 0; x <= Tab.DimX; x++)
                {
                    e.Graphics.DrawLine(Pens.Black, x * 100, 0, x * 100, Tab.DimY * 100);
                }
                /*e.Graphics.DrawLine(Pens.Black, 100, 0, 100, 300);
                e.Graphics.DrawLine(Pens.Black, 200, 0, 200, 300);
                e.Graphics.DrawLine(Pens.Black, 0, 100, 300, 100);
                e.Graphics.DrawLine(Pens.Black, 0, 200, 300, 200);*/


                //dibuja las fichas
                Font myFont = new Font("Arial", 45);
                for (y = 0; y < Tab.DimY; y++)
                {
                    for (x = 0; x < Tab.DimX; x++)
                    {
                        if (Tab.Pos[x, y] == 1)
                            e.Graphics.DrawString("X", myFont, Brushes.Blue, new PointF(x * 100 + 20, y * 100 + 20));

                        if (Tab.Pos[x, y] == -1)
                            e.Graphics.DrawString("O", myFont, Brushes.Red, new PointF(x * 100 + 20, y * 100 + 20));
                    }
                }
            }
        }

        public void VisualizarMovimiento(PictureBox pct, Movimiento mov)
        {
            //movimiento del ordenador
            //System.Threading.Thread.Sleep(500);

            Juego.Partida.Pos[mov.x, mov.y] = Juego.Partida.Turno;
            pct.Refresh();
            System.Threading.Thread.Sleep(500);
            Juego.Partida.Pos[mov.x, mov.y] = 0;
            pct.Refresh();
            System.Threading.Thread.Sleep(500);
            Juego.Partida.Pos[mov.x, mov.y] = Juego.Partida.Turno;
            pct.Refresh();
            //System.Threading.Thread.Sleep(500);
        }

        public void VisualizarTurno(Label lbl)
        {
            string sTurno = "";

            if (Juego.Partida.Turno == 1)
                sTurno = "Jugador 1 (Humano)";
            else if (Juego.Partida.Turno == -1)
                sTurno = "Jugador 2 (Ordenador)";
            else
                sTurno = "Sin empezar";

            sTurno += ". Turno nº " + Juego.TurnoAct.ToString();
            lbl.Text = sTurno;
            lbl.Refresh();
        }

        public void VisualizarResultado(Label lbl)
        {
            string sResultado = "";

            int Vict;
            Vict = Juego.Partida.EvaluaVictoria();
            if ((Vict == 0) && !Juego.Partida.EvaluaEmpate())
                sResultado = "en juego";
            else
            {
                if (Vict == 1)
                    sResultado = "Victoria Jugador 1 (Humano)";
                else if (Vict == -1)
                    sResultado = "Victoria Jugador 2 (Ordenador)";
                else 
                    sResultado = "Empate";
            }

            lbl.Text = sResultado;
            lbl.Refresh();
        }


        //---------------------************** BUCLE DE JUEGO *****************---------------------
        private void btnEmpezar_Click(object sender, EventArgs e)
        {
            int TurnoInicial;
            if (rdbEmpiezaJug.Checked)
                TurnoInicial = 1;
            else
                TurnoInicial = -1;

            int iDimension = (int)cmbNumCasillas.Items[cmbNumCasillas.SelectedIndex];

            int iProfundidad;
            switch (iDimension)
            {
                case 3:
                    iProfundidad = 10;
                    break;
                case 4:
                    iProfundidad = 5;
                    break;
                case 5:
                    iProfundidad = 3;
                    break;
                default:
                    iProfundidad = 3;
                    break;
            }

            Juego = new IA(TurnoInicial, iDimension, iProfundidad);

            VisualizarTurno(this.lblTurno);
            VisualizarTablero(this.pctTablero);
            VisualizarResultado(this.lblResultado);

            bool bNoFinal = true;
            do
            {

                Juego.TurnoAct++;
                VisualizarTurno(this.lblTurno);

                if (Juego.Partida.Turno == 1)
                {
                    //esperar movimiento jugador
                    lock (stateLock)
                    {
                        bEsperarJugador = true;
                    }
                    JugX = -1;
                    JugY = -1;
                    //Int64 tiempo = 0;
                    //Application.DoEvents();
                    bool bEsperar;
                    do
                    {
                        Application.DoEvents();
                        lock (stateLock)
                        {
                            bEsperar = bEsperarJugador;
                        }
                    }
                    while (bEsperar);

                    if ((JugX == -1 || JugY == -1))
                        MessageBox.Show("error pulsacion jugador humano");
                    else
                    {
                        Juego.JugarHumano(JugX, JugY);
                    }

                }
                else if (Juego.Partida.Turno == -1)
                {
                    //movimiento ordenador
                    Movimiento MovOrd = Juego.JugarOrdenador();
                    VisualizarMovimiento(this.pctTablero, MovOrd);
                }

                bNoFinal = (Juego.Partida.EvaluaVictoria() == 0) && !Juego.Partida.EvaluaEmpate();
                if (bNoFinal)
                {
                    //si esto sigue cambio el turno, si se acaba lo dejo para ver el turnovencedor
                    Juego.Partida.Turno = -Juego.Partida.Turno;
                }
                VisualizarTurno(this.lblTurno);
                VisualizarTablero(this.pctTablero);
                VisualizarResultado(this.lblResultado);
            }
            while (bNoFinal);

            //VisualizarTurno(this.lblTurno);
            //VisualizarTablero(this.pctTablero);
            //VisualizarResultado(this.lblResultado);

        }


        private void Picture_MouseDown(object sender, System.Windows.Forms.MouseEventArgs e)
        {
            bool bEsperar;
            lock (stateLock)
            {
                bEsperar = bEsperarJugador;
            }
             
            //if (Juego != null) //
            if(bEsperar)
            {
                JugX = -1;
                JugY = -1;
                bool bPulsa = false;
                int x, y;
                for (y = 0; y < Juego.Partida.DimY; y++)
                {
                    for (x = 0; x < Juego.Partida.DimX; x++)
                    {
                        if ((x * 100 < e.X) && ((x + 1) * 100 > e.X) &&
                            (y * 100 < e.Y) && ((y + 1) * 100 > e.Y))
                        {
                            if (Juego.Partida.Pos[x, y] == 0)
                            {
                                JugX = x;
                                JugY = y;
                                bPulsa = true;
                            }
                        }
                    }
                }

                lock (stateLock)
                {
                    bEsperarJugador = !bPulsa;
                }
            }
        }

    }
}
