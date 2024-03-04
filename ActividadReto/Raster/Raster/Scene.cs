using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster
{
    internal class Scene
    {
        public List<Model> Models;
        public Scene(List<Model> models)
        {
            Models = new List<Model>();
            Models = models;
        }


    }
}
