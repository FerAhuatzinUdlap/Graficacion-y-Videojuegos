using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.Xml;
using System.Text;
using System.Threading.Tasks;

namespace Raster
{
    public class Model
    {

        public Vertex position;

        public Mesh mesh;

        Transform transform;


        public Model(Mesh mesh, Vertex position)
        {
            this.mesh = mesh;
            this.position = position;
            transform = new Transform(1, new Vertex([0,0,0]), new Vertex([0, 0, 0]));

        }

    }
}
