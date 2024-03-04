using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster
{
    public class Triangle
    {
        List<Vertex> puntos3Ds;
        List<Vertex> faceOfFigure;
        List<Vertex> translatedPoints;
        List<Vertex> escaledPoints;

        public Triangle(Vertex v1, Vertex v2, Vertex v3)
        {
            puntos3Ds = new List<Vertex>();
            faceOfFigure = new List<Vertex>();
            translatedPoints = new List<Vertex>();
            escaledPoints = new List<Vertex>();

            agregarPunto(v1);
            agregarPunto(v2);
            agregarPunto(v3);
        }
        public void agregarPunto(Vertex punto)
        {
            puntos3Ds.Add(punto);
            faceOfFigure.Add(punto);
            translatedPoints.Add(punto);
            escaledPoints.Add(punto);
        }

        public void renderPoint(Graphics g, PointF punto)
        {
            g.FillEllipse(Brushes.Yellow, punto.X, punto.Y, 1,1);
        }
        private void activateLine(Graphics g, PointF punto, PointF punto2)
        {
            g.DrawLine(Pens.Turquoise, punto, punto2);
        }
        public void renderTriangle(Graphics g)
        {
            for (int i = 0; i < puntos3Ds.Count; i++)
            {
                renderPoint(g, new PointF(translatedPoints[i][0], translatedPoints[i][1]));
            }
        }

        public void activateLines(Graphics g)
        {
            for (int i = 0; i < puntos3Ds.Count - 1; i++)
            {
                activateLine(g, new PointF(translatedPoints[i][0], translatedPoints[i][1]), new PointF(translatedPoints[i + 1][0], translatedPoints[i + 1][1]));
            }
            activateLine(g, new PointF(translatedPoints[puntos3Ds.Count - 1][0], translatedPoints[puntos3Ds.Count - 1][1]), new PointF(translatedPoints[0][0], translatedPoints[0][1]));

        }

        public Vertex eliminatePointZ(Vertex v)
        {
            Mtx Mat;
            float[,] axis = new float[,]
                {
                { 1,0,0},
                { 0,1,0},
                { 0,0,0}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(v);
        }

        public Vertex getPerspectivePoint(Vertex v, float distance)
        {
            Mtx Mat;
            float z = -1 / (distance - v[2]);
            float[,] axis = new float[,]
                {
                { z,0,0},
                { 0,z,0},
                { 0,0,1}
                };
            Mat = new Mtx(axis);
            return Mat.Mul(v);
        }

        public void getOnlyFace()
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = (eliminatePointZ(puntos3Ds[i]));
            }
        }

        public void getPerspective(float distance)
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = (getPerspectivePoint(puntos3Ds[i], distance));
            }
        }

        public void scale(int sm)
        {

            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                escaledPoints[i] = new Vertex(new float[] { (faceOfFigure[i][0]) * sm, faceOfFigure[i][1] * sm, faceOfFigure[i][2] * sm });
                translatedPoints[i] = escaledPoints[i];
            }
        }

        public Vertex traslacionPunto(Vertex punto, Size size)
        {
            float[] v = { punto[0] + size.Width / 2, punto[1] + size.Height / 2, 0 };
            return new Vertex(v);
        }

        public void traslacionTriangulo(Size size)
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                translatedPoints[i] = traslacionPunto(escaledPoints[i], size);
                //escaledPoints[i] = translatedPoints[i];
            }
        }

        private Vertex Translate(Vertex a, Vertex b)
        {
            float[] array1;
            array1 = [a[0], a[1], a[2] + b[2]];

            return (new Vertex(array1));
        }

        public void traslacionZ(Vertex b) 
        {
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                translatedPoints[i] = Translate(translatedPoints[i], b);
                //escaledPoints[i] = faceOfFigure[i];
            }

        }


        public void rotateX(float rx)
        {
            Rotacion rot = new Rotacion();
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = rot.RotarX(rx, faceOfFigure[i]);
            }
        }

        public void rotateY(float ry)
        {
            Rotacion rot = new Rotacion();
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = rot.RotarY(ry, faceOfFigure[i]);
            }
        }

        public void rotateZ(float rz)
        {
            Rotacion rot = new Rotacion();
            for (int i = 0; i < puntos3Ds.Count(); i++)
            {
                faceOfFigure[i] = rot.RotarZ(rz, faceOfFigure[i]);
            }
        }

    }
}
