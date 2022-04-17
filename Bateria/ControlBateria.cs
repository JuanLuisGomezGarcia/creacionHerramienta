using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Bateria
{
    [ToolboxBitmap(typeof(ControlBateria), "icono.png")]
    public partial class ControlBateria : UserControl
    {
        Color sinBateria;
        Color conBateria;
        Color blanco;
        float porcentageCarga;
        Boolean arastrar = false;

        Boolean conectado = false;
        Boolean agotado = false;
        Graphics grafico;
        int nivel;
        public class Argumentos : EventArgs
        {
            float evento;
            public Argumentos(float evento)
            {
                this.evento = evento;
            }
            public float eventoGet
            {
                get { return evento; }
            }
        }

        public delegate void CambioValor(Object sender, Argumentos e);
        public event CambioValor ValorCambiado;
        public ControlBateria()
        {
            InitializeComponent();
            sinBateria = Color.Red;
            conBateria = Color.Green;
            blanco = Color.White;
            porcentageCarga =0;
            
            Boolean arastrar = false;
            //this.Width = this.Height / 2;
            
            
           // int a = Convert.ToInt32(this.Width * 0.34);
            //int b = Convert.ToInt32(this.Height * 0.1);
            //label1.Location = new Point(a, b);
            
        }


        public float PorcentageCarga
        {
            get { return porcentageCarga; }
            set { porcentageCarga = value;
                var evento = this.ValorCambiado;
                if (evento != null) evento(this, new Argumentos(porcentageCarga));
                Invalidate(); }
        }

        [Description("  Selecciona la carga de la bateria"),]
        public int Nivel
        {
            get {

                return nivel; }
            set {
                int a;
                if (value < 0 || value > 100) { a = 1; } else {
                    a = Convert.ToInt32(value);
                    int b = Convert.ToInt32(value);
                    int c = 100 - b;
                    float reglaTres = (c * this.Height) / 100;
                    
                    porcentageCarga = reglaTres;
                }
                nivel = a;
                
                Invalidate(); }
        }

        [Description("Cambia el estado de la bateria de normal o agotado")]
        public Boolean Agotado
        {
            get { return agotado; }
            set { agotado = value; Invalidate(); }
        }

        [Description("Cambia el estado de la bateria de normal a cargando")]
        public Boolean Cargando
        {
            get { return conectado; }
            set { conectado = value; Invalidate(); }
        }

        [Description("Permite elegir el color de la bateria cuando esta tiene menos de un 10%")]
        public Color SinBateria
        {
            get { return sinBateria; }
            set { sinBateria = value; Invalidate(); }
        }

        [Description("Permite elegir el color de la bateria cuando esta es superior a un 10%")]
        public Color ConBateria
        {
            get { return conBateria; }
            set { conBateria = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            grafico = e.Graphics;
            this.DoubleBuffered = true;    //EVITAR LAG
            int ancho = this.Width;
            int alto = this.Height;

            Brush brush1 = new SolidBrush(conBateria);
            Brush brush2 = new SolidBrush(blanco);
            Brush brush3 = new SolidBrush(sinBateria);
            int theValueToConvert = Convert.ToInt32(porcentageCarga);


            if (agotado) {
                grafico.DrawImage(Bateria.Properties.Resources.agotada, (int)(ancho * 0.03), (int)(alto * 0.03), ancho, alto);
                arastrar = false;
                grafico.DrawString("0%",this.Font,Brushes.Black, (int)(ancho * 0.4), (int)(alto * 0.1));
                
                conectado = false;
            } else {
                if (conectado) {
                    agotado = false;
                    grafico.FillRectangle(brush1, (int)(ancho * 0.108), (int)(alto * 0.09), (int)(ancho * 0.84), (int)(alto * 0.9));
                    grafico.FillRectangle(brush2, (int)(ancho * 0.108), (int)(alto * 0.03), (int)(ancho * 0.84), porcentageCarga);
                    grafico.DrawImage(Bateria.Properties.Resources.carga, (int)(ancho * 0.03), (int)(alto * 0.03), ancho, alto);
                    double reglaTres = porcentageCarga * 100;
                    double reglaTres1 = reglaTres / this.Height;
                    int theValueToConvert1 = Convert.ToInt32(reglaTres1);
                    int porcentageFinal = 100 - theValueToConvert1;
                    grafico.DrawString(porcentageFinal.ToString() + "%", this.Font, Brushes.Black, (int)(ancho * 0.4), (int)(alto * 0.1));
                    //label1.Text = porcentageFinal.ToString() + "%";
                } else {
                    grafico.FillRectangle(brush1, (int)(ancho * 0.108), (int)(alto * 0.09), (int)(ancho * 0.84), (int)(alto * 0.9));

                    if (theValueToConvert >= alto * 0.9) {
                        grafico.FillRectangle(brush3, (int)(ancho * 0.108), (int)(alto * 0.03), (int)(ancho * 0.84), alto);
                        grafico.FillRectangle(brush2, (int)(ancho * 0.108), (int)(alto * 0.03), (int)(ancho * 0.84), porcentageCarga);
                        double reglaTres = porcentageCarga * 100;
                        double reglaTres1 = reglaTres / this.Height;
                        int theValueToConvert1 = Convert.ToInt32(reglaTres1);
                        int porcentageFinal = 100 - theValueToConvert1;
                        grafico.DrawString(porcentageFinal.ToString() + "%", this.Font, Brushes.Black, (int)(ancho * 0.4), (int)(alto * 0.1));
                    }
                    else

                    { grafico.FillRectangle(brush2, (int)(ancho * 0.108), (int)(alto * 0.03), (int)(ancho * 0.84), porcentageCarga);
                        double reglaTres = porcentageCarga * 100;
                        double reglaTres1 = reglaTres / this.Height;
                        int theValueToConvert1 = Convert.ToInt32(reglaTres1);
                        int porcentageFinal = 100 - theValueToConvert1;
                        grafico.DrawString(porcentageFinal.ToString() + "%", this.Font, Brushes.Black, (int)(ancho * 0.4), (int)(alto * 0.1));
                    }


                    if (!(theValueToConvert <= alto * 0.9)) { grafico.DrawImage(Bateria.Properties.Resources.agotada, (int)(ancho * 0.03), (int)(alto * 0.03), ancho, alto);
                        double reglaTres = porcentageCarga * 100;
                        double reglaTres1 = reglaTres / this.Height;
                        int theValueToConvert1 = Convert.ToInt32(reglaTres1);
                        int porcentageFinal = 100 - theValueToConvert1;
                        grafico.DrawString(porcentageFinal.ToString() + "%", this.Font, Brushes.Black, (int)(ancho * 0.4), (int)(alto * 0.1));
                    }
                    else {

                        grafico.DrawImage(Bateria.Properties.Resources._base, (int)(ancho * 0.03), (int)(alto * 0.03), ancho, (int)(alto));
                        double reglaTres = porcentageCarga * 100;
                        double reglaTres1 = reglaTres / this.Height;
                        int theValueToConvert1 = Convert.ToInt32(reglaTres1);
                        int porcentageFinal = 100 - theValueToConvert1;
                        grafico.DrawString(porcentageFinal.ToString() + "%", this.Font, Brushes.Black, (int)(ancho * 0.4), (int)(alto * 0.1));
                    }
                    
                }
            }

        }


        private void ControlBateria_Load(object sender, EventArgs e)
        {

        }

        private void ControlBateria_Layout(object sender, LayoutEventArgs e)
        {
            if (e.AffectedProperty == "Bounds")
            {
                this.Width = this.Height / 2;




                Invalidate();
            }
        }
        private float calcular_valor(Point p)
        {
            float distancia = p.Y;
            float posicion = distancia * 100 / this.Height;
            if (distancia > this.Height) { distancia = (float)((float)this.Height); }
            else
            {
                if (distancia < 0) { distancia = 0; }
            }
            return distancia;
        }
        private void ControlBateria_MouseDown(object sender, MouseEventArgs e)
        {
            arastrar = true;
        }

        private void ControlBateria_MouseMove(object sender, MouseEventArgs e)
        {
            if (arastrar)
            {
                porcentageCarga = calcular_valor(e.Location);
                Invalidate();
            }
        }

        private void ControlBateria_MouseUp(object sender, MouseEventArgs e)
        {
            arastrar = false;
        }

        private void ControlBateria_DoubleClick(object sender, EventArgs e)
        {
            if (conectado == false)
            {
                conectado = true;
            }
            else
            {
                conectado = false;

            }
            Invalidate();
        }
        } }
