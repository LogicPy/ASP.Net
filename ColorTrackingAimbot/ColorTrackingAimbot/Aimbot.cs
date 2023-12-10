using System.Windows.Forms;
using System.Drawing.Imaging; // For PixelFormat
using DrawingPoint = System.Drawing.Point; // Alias for System.Drawing.Point
using DrawingRectangle = System.Drawing.Rectangle; // Alias for System.Drawing.Rectangle

using System.Drawing; // For Bitmap
using System.Runtime.InteropServices; // For DllImport
using SixLabors.ImageSharp; // For ImageSharp functionalities
using SixLabors.ImageSharp.PixelFormats; // For ImageSharp Pixel Formats
using SixLabors.ImageSharp.Processing; // For ImageSharp Processing
using ImageSharpPoint = SixLabors.ImageSharp.Point; // Alias for SixLabors.ImageSharp.Point
using DrawingColor = System.Drawing.Color; // Alias for System.Drawing.Color
using ImageSharpColor = SixLabors.ImageSharp.Color; // Alias for SixLabors.ImageSharp.Color
System.Drawing.Image myImage;


public class Aimbot
{
    public class ScreenCapture
    {
        public Bitmap CaptureScreen()
        {
            DrawingRectangle bounds = Screen.PrimaryScreen.Bounds;
            Bitmap screenshot = new Bitmap(bounds.Width, bounds.Height, System.Drawing.Imaging.PixelFormat.Format32bppArgb);

            using (Graphics g = Graphics.FromImage(screenshot))
            {
                g.CopyFromScreen(DrawingPoint.Empty, DrawingPoint.Empty, bounds.Size);
            }

            return screenshot;
        }

        // Method to find the color
        private ScreenCapture screenCapture = new ScreenCapture();

        public DrawingPoint? FindColor(DrawingColor targetColor)
        {
            Bitmap screenShot = screenCapture.CaptureScreen();


            for (int x = 0; x < screenShot.Width; x++)
            {
                for (int y = 0; y < screenShot.Height; y++)
                {
                    //Color color = screenShot.GetPixel(x, y);
                    DrawingColor color = DrawingColor.FromArgb(255, 0, 0); // For System.Drawing.Color

                    if (color == targetColor)
                    {
                        DrawingPoint point = new DrawingPoint(100, 100); // For System.Drawing.Point
                        return point;
                    }
                }
            }

            return null;
        }

        // P/Invoke declaration for mouse movement
        [DllImport("user32.dll")]
        static extern bool SetCursorPos(int X, int Y);

        // Method to move the mouse
        public void MoveMouse(DrawingPoint position)
        {
            SetCursorPos(position.X, position.Y);
        }

        // Method to execute the aimbot logic
        public void Execute()
        {
            // Resolved
            DrawingPoint point = new DrawingPoint(100, 100); // For System.Drawing.Point
            DrawingColor color = DrawingColor.FromArgb(255, 0, 0); // For System.Drawing.Color


            // Assuming FindColor is a method that returns a nullable Point (Point?) and takes a Color parameter
            DrawingColor targetColor = DrawingColor.FromArgb(255, 0, 0); // Example target color
            DrawingPoint? colorPosition = FindColor(targetColor);

            if (colorPosition.HasValue)
            {
                MoveMouse(colorPosition.Value);
            }

        }
    }
}
