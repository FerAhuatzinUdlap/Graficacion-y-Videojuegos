using System;
using System.Collections.Generic;
using System.Drawing.Imaging;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Raster
{
    
    public class Canvas
    {

        public Bitmap bmp;
        public float width, height;
        public byte[] bits;
        Graphics g;
        int pixelFormatSize, stride;

        public Canvas(Size size)
        {

            init(size.Width, size.Height);

        }//end Canvas

        private void init(int width, int height)
        {

            PixelFormat format;
            GCHandle handle;
            IntPtr bitPtr;
            int padding;

            format = PixelFormat.Format32bppArgb;
            bmp = new Bitmap(width, height);
            this.width = width;
            this.height = height;
            pixelFormatSize = Image.GetPixelFormatSize(format) / 8;
            stride = width * pixelFormatSize;
            padding = (stride % 4);
            stride += padding == 0 ? 0 : 4 - padding;
            bits = new byte[stride * height];
            handle = GCHandle.Alloc(bits, GCHandleType.Pinned);
            bitPtr = Marshal.UnsafeAddrOfPinnedArrayElement(bits, 0);
            bmp = new Bitmap(width, height, stride, format, bitPtr);
            g = Graphics.FromImage(bmp);

        }//end init

        /*
        public void DrawPixel(int x, int y, Color C)
        {

            int res = (int)((x * pixelFormatSize) + (y * stride));

            bits[res + 0] = C.B; //(byte)Blue
            bits[res + 1] = C.G;//(byte)Green
            bits[res + 2] = C.R;//(byte)Red
            bits[res + 3] = C.A;//(byte)Alpha

        }//end DrawPixel11
        */

        public void FastClear()
        {

            unsafe
            {

                BitmapData bitmapData = bmp.LockBits(new Rectangle(0, 0, bmp.Width, bmp.Height), ImageLockMode.ReadWrite, bmp.PixelFormat);
                int bytesPerPixel = System.Drawing.Bitmap.GetPixelFormatSize(bmp.PixelFormat) / 8;
                int heightInPixels = bitmapData.Height;
                int widthInBytes = bitmapData.Width * bytesPerPixel;
                byte* PtrFirstPixel = (byte*)bitmapData.Scan0;
                Parallel.For(0, heightInPixels, y => // usando proceso en paralelo
                {
                    byte* bits = PtrFirstPixel + (y * bitmapData.Stride);
                    for (int x = 0; x < widthInBytes; x = x + bytesPerPixel)
                    {
                        bits[x + 0] = 0;// (byte)Blue;
                        bits[x + 1] = 0;// (byte)Green;
                        bits[x + 2] = 0;// (byte)Red;
                        bits[x + 3] = 0;// (byte)Red;
                    }
                });
                bmp.UnlockBits(bitmapData);


            }//end unsafe

        }//end FastClear

        

        public void render(Size size, Mesh figure)
        {

            FastClear();
            g.Clear(Color.Black);

            figure.activateLines(g);
            figure.renderFigure(g);

        }
    }


    /*
    internal class Canvas
    {
        Graphics g;
        Bitmap bmp;

        public Canvas(PictureBox picturebox)
        {
            bmp = new Bitmap(picturebox.Width, picturebox.Height);
            g = Graphics.FromImage(bmp);
            picturebox.Image = bmp;

        }

        public void render(Size size, Mesh figure)
        {
            g.Clear(Color.Black);

            figure.activateLines(g);
            figure.renderFigure(g);

        }
    }*/
    


}
