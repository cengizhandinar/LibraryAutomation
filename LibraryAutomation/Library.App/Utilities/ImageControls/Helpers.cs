using System.Drawing;
using System.Drawing.Drawing2D;

namespace Library.App.Utilities.ImageControls
{
    public static class Helpers
    {
        public static Image ImageResize(Image imgToResize, Size size)
        {
            var sourceWidth = imgToResize.Width;
            var sourceHeight = imgToResize.Height;
            var nPercentW = size.Width / (float)sourceWidth;
            var nPercentH = size.Height / (float)sourceHeight;
            var nPercent = nPercentH < nPercentW ? nPercentH : nPercentW;
            var destWidth = (int)(sourceWidth * nPercent);
            var destHeight = (int)(sourceHeight * nPercent);

            var bitmap = new Bitmap(destWidth, destHeight);
            var g = Graphics.FromImage(bitmap);
            g.InterpolationMode = InterpolationMode.HighQualityBicubic;
            g.DrawImage(imgToResize, 0, 0, destWidth, destHeight);
            g.Dispose();

            return bitmap;
        }
    }
}