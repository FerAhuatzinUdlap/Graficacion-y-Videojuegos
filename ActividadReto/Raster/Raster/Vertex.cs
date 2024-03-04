using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Raster
{
    public class Vertex
    {

        const int x = 0;
        const int y = 1;
        const int z = 2;
        public float[] Values;

        public float this[int i]
        {
            get { return Values[i]; }
            set { Values[i] = value; }
        }

        public Vertex(float[] values)
        {
            this.Values = values;
        }

        public static Vertex operator *(Vertex a, Vertex b)
        {
            return new Vertex(new float[] { a[x] * b[x], a[y] * b[y], a[z] * b[z] });
        }

        public static Vertex operator +(Vertex a, Vertex b)
        {
            return new Vertex(new float[] { a[x] + b[x], a[y] + b[y], a[z] + b[z] });
        }

        public override string ToString()
        {
            return this[x] + ", " + this[y] + ", " + this[z];

        }
    }
}
