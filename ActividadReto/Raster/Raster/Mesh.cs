using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster
{


    public class Mesh
    {

        public List<Triangle> Triangles;

        public Mesh(List<Triangle> triangulosInput)
        {
            Triangles = triangulosInput;

        }
        
        public void AddQuads(Vertex v1, Vertex v2, Vertex v3, Vertex v4)
        {
            Triangles.Add(new Triangle(v1, v2, v3));
            Triangles.Add(new Triangle(v1, v3, v4));
        }


        public void AddTriangle(Vertex v1, Vertex v2, Vertex v3)
        {
            Triangles.Add(new Triangle(v1, v2, v3));
        }



        public void renderFigure(Graphics g)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].renderTriangle(g);
            }
        }

        public void activateLines(Graphics g)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].activateLines(g);
            }
        }

        public void putOrthogonal()
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].getOnlyFace();
            }
        }

        public void putPerspective(float distance)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].getPerspective(distance);
            }
        }

        public void traslacionFig(Size size)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].traslacionTriangulo(size);
            }
        }



        public void scaleFig(int sm)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].scale(sm);
            }
        }

        public void translateZ(float tz)
        {
            Vertex vertex1 = new Vertex([0f, 0f, tz]);

           
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].traslacionZ(vertex1);
            }
        }
        public void rotateX(float rx)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].rotateX(rx);
            }
        }

        public void rotateY(float ry)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].rotateY(ry);
            }
        }

        public void rotateZ(float rz)
        {
            for (int i = 0; i < Triangles.Count(); i++)
            {
                Triangles[i].rotateZ(rz);
            }
        }


    }
}
