using System;

namespace Raster
{
    public partial class Form1 : Form
    {
        Scene scene;
        Mesh mesh;
        public List<Model> Models;
        int index;
        Render render;
        List<Vertex> vertexes;
        List<Triangle> triangles;
        public Form1()
        {
            InitializeComponent();
            String filePath = "Objeto.obj";
            StreamReader reader = new StreamReader(filePath);
            vertexes = new List<Vertex>();
            triangles = new List<Triangle>();
            String line;

            while ((line = reader.ReadLine()) != null)
            {
                string[] parts = line.Split(' ');

                // Procesar vértices
                if (parts[0] == "v")
                {
                    float x = float.Parse(parts[1]);
                    float y = float.Parse(parts[2]);
                    float z = float.Parse(parts[3]);
                    //guardar puntos en lista de vertex
                    vertexes.Add(new Vertex([x, y, z]));
                }
                // Procesar caras
                else if (parts[0] == "f")
                {
                    List<int> vertexIndices = new List<int>();
                    for (int i = 1; i < parts.Length; i++)
                    {
                        string[] indices = parts[i].Split('/');
                        int vertexIndex = int.Parse(indices[0]) - 1; // -1 because OBJ indices start from 1
                        vertexIndices.Add(vertexIndex);
                    }
                    //generar triangulos con respecto al archivo
                    //la lista de triangulos generada se asigna a mesh
                    triangles.Add(new Triangle(
                        vertexes[vertexIndices[0]],
                        vertexes[vertexIndices[1]],
                        vertexes[vertexIndices[2]]
                    ));
                }
            }
            //leer obj



            //mesh se asigna a model
            mesh = new Mesh(triangles);
            Models = new List<Model>();
            Models.Add(new Model(mesh, new Vertex([0, 0, 0])));
            index = 0;
            render = new Render(PCT_CANVAS);
            //deben de haber 2 mesh por lo tanto 2 modelos
            //los dos modelos se asignan a la escena
            scene = new Scene(Models);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }


        private void TIMER_Tick(object sender, EventArgs e)
        {

            Render();
        }


        private void Render()
        {
            /*index = 0;
            scene.Models[index].Transform.Rotation.X += .8f;
            scene.Models[index].Transform.Rotation.Y += .3f;
            scene.Models[index].Transform.Rotation.Z += .81f;
            scene.Models[index].Transform.Translation.Z -= .01f;
            index = 1;
            scene.Models[index].Transform.Rotation.X += .8f;
            scene.Models[index].Transform.Rotation.Y += .3f;
            scene.Models[index].Transform.Rotation.Z += .81f;*/
            render.RenderScene(scene);
            PCT_CANVAS.Refresh();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
