using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _0001
{
    public partial class Histograma : Form
    {

        float[,] histogram;
        float mayor;
        public Histograma()
        {
            InitializeComponent();

            histogram = BitProcess.getHistogram(Canvas.bits);
            
            int n = 0;

            mayor = 0;
            for (int i = 0; i < histogram.GetLength(0); i++)
            {
                for (int j = 0; j < histogram.GetLength(1); j++)
                {
                    
                    if(histogram[i, j] > mayor)
                    {

                        mayor = histogram[i, j];

                    }//end if
                    
                }//end for

            }//end for

            for (int i = 0; i < histogram.GetLength(0); i++)
            {
                for (int j = 0; j < histogram.GetLength(1); j++)
                {
                    histogram[i, j] = histogram[i, j] / mayor * 256.0f;
                }
            }


        }//end Histograma


        public void updateHistograma()
        {

            histogram = BitProcess.getHistogram(Canvas.bits);
            histogram = BitProcess.getHistogram(Canvas.bits);

            int n = 0;

            mayor = 0;
            for (int i = 0; i < histogram.GetLength(0); i++)
            {
                for (int j = 0; j < histogram.GetLength(1); j++)
                {

                    if (histogram[i, j] > mayor)
                    {

                        mayor = histogram[i, j];

                    }//end if

                }//end for

            }//end for

            for (int i = 0; i < histogram.GetLength(0); i++)
            {
                for (int j = 0; j < histogram.GetLength(1); j++)
                {
                    histogram[i, j] = histogram[i, j] / mayor * 256.0f;
                }
            }

            this.Invalidate();

        }//end updateHistograma

        private void Histograma_Load(object sender, EventArgs e)
        {

        }

        public void Histograma_Paint(object sender, PaintEventArgs e)
        {
            int n = 0;
            int altura = 0;
            Graphics g = e.Graphics;
            Pen[] pens = { Pens.Red, Pens.Green, Pens.Blue };
            Pen plumaEjes = new Pen(Color.Coral);

            g.DrawLine(plumaEjes, 19, 271, 277, 271);
            g.DrawLine(plumaEjes, 19, 270, 19, 14);


            for (int i = 0; i < 3; i++)
            {
                for (n = 0; n < 256; n++)
                {

                    g.DrawLine(pens[i],n+20,270 ,n+20, 270-histogram[i,n]);

                }//end for

            }//end for

           
        }//end Histograma_Paint

    }//end class

}//end namespace
