using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Runtime.InteropServices;
using Emgu.CV;
using Emgu.CV.CvEnum;
using Emgu.CV.UI;
using Emgu.CV.Structure;

namespace InvertImage
{
    class Program
    {
        static void Main(string[] args)
        {
            String win1 = "Test Window"; //The name of the window
            CvInvoke.cvNamedWindow(win1); //Create the window using the specific name

            Image<Bgr, Byte> frame = new Image<Bgr, Byte>("lena.jpg");
            
            byte[, ,] data = frame.Data;
            
            //Invert each pixel in the image
            for (int i = 0; i < frame.Rows; i++)
            {
                for (int j = 0; j < frame.Cols; j++)
                {
                    data[i, j, 0] = (byte)(255 - data[i, j, 0]);
                    data[i, j, 1] = (byte)(255 - data[i, j, 1]);
                    data[i, j, 2] = (byte)(255 - data[i, j, 2]);
                }
            }

            frame.Data = data;
            CvInvoke.cvShowImage(win1, frame); //Show the image   

            CvInvoke.cvWaitKey(0);

            CvInvoke.cvDestroyWindow(win1); //Destory the window
        }
    }
}
