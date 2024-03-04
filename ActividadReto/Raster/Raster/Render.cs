using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Raster
{
    internal class Render
    {


        private Canvas canvas;
        public Size size;


        public Render(PictureBox size)
        {
            canvas = new Canvas(size.Size);
            size.Image = canvas.bmp;
            this.size = size.Size;
        }
        public void RenderScene(Scene scene)
        {
            //canvas.FastClear();//-------------------CLEAR SCENE
            Model model;
            for (int s = 0; s < scene.Models.Count; s++)
            {

                
                model = scene.Models[s];
                //----- ALL TRANSFORMATIONS --------------------------------------
                model.mesh.rotateX(25f);
                model.mesh.rotateY(25f);
                model.mesh.rotateZ(-25f);
                model.mesh.scaleFig(100);
                model.mesh.traslacionFig(size);
                //model.mesh.translateZ(-10f);
                //if (s == 0) { model.mesh.translateZ(-0.01f); }
                canvas.render(size, model.mesh);
                /*model.mesh.activateLines(canvas.g);
                model.mesh.renderFigure(canvas.g);*/
                
                
            }
        }

    }
}
