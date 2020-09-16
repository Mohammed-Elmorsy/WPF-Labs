using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;
using System.Windows.Ink;
using System.IO;

namespace canvas
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Window
    {
        public Window1()
        {
            InitializeComponent();
        }

        private void changecolor(object sender, RoutedEventArgs e)
        {
            string color = (sender as RadioButton).Content.ToString();

            switch(color)
            {
                case "red":
                    myCanvas.DefaultDrawingAttributes.Color = Colors.Red;
                    break;

                case "green":
                    myCanvas.DefaultDrawingAttributes.Color = Colors.Green;
                    break;

                case "blue":
                    myCanvas.DefaultDrawingAttributes.Color = Colors.Blue;
                    break;

                case "yellow":
                    myCanvas.DefaultDrawingAttributes.Color = Colors.Yellow;
                    break;

            }

        }

        private void changemode(object sender, RoutedEventArgs e)
        {
            string mode = (sender as RadioButton).Content.ToString();

            switch (mode)
            {
                case "ink":
                    myCanvas.EditingMode = InkCanvasEditingMode.Ink;
                    break;

                case "select":
                    myCanvas.EditingMode = InkCanvasEditingMode.Select;
                    break;

                case "erase":
                    myCanvas.EditingMode = InkCanvasEditingMode.EraseByPoint;
                    break;

                case "erase by stroke":
                    myCanvas.EditingMode = InkCanvasEditingMode.EraseByStroke;
                    break;

            }
        }

        private void changeshape(object sender, RoutedEventArgs e)
        {
            string shape = (sender as RadioButton).Content.ToString();
            //Ellipse ellipse = new Ellipse();
            //Rectangle rectangle = new Rectangle();

            switch (shape)
            {
                case "ellipse":
                    myCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Ellipse;
                    
                    break;

                case "rectangle":
                    myCanvas.DefaultDrawingAttributes.StylusTip = System.Windows.Ink.StylusTip.Rectangle;
                    break;

            }
        }

        private void changebrushsize(object sender, RoutedEventArgs e)
        {
            string brushSize = (sender as RadioButton).Content.ToString();

            switch (brushSize)
            {
                case "small":
                    myCanvas.DefaultDrawingAttributes.Height = 5;
                    myCanvas.DefaultDrawingAttributes.Width = 5;
                    break;

                case "normal":
                    myCanvas.DefaultDrawingAttributes.Height = 15;
                    myCanvas.DefaultDrawingAttributes.Width = 15;
                    break;

                case "large":
                    myCanvas.DefaultDrawingAttributes.Height = 30;
                    myCanvas.DefaultDrawingAttributes.Width = 30;
                    break;

            }
        }

        private void savefun(object sender, RoutedEventArgs e)
        {
            FileStream sw = new FileStream("E:/DotNET/WPF/Lab/drawings/drawing.ink", FileMode.Create, FileAccess.Write);

            myCanvas.Strokes.Save(sw);
            sw.Close();
        }

        private void loadfun(object sender, RoutedEventArgs e)
        {
            FileStream sr = new FileStream("E:/DotNET/WPF/Lab/drawings/drawing.ink", FileMode.Open, FileAccess.Read);

            myCanvas.Strokes = new StrokeCollection(sr);

            sr.Close();
        }

        private void newfun(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("Are you sure you want to clear the canvas ?","confirm" ,MessageBoxButton.OKCancel);
            switch(result)
            {
                case MessageBoxResult.OK:
                    myCanvas.Strokes.Clear();
                    break;
                case MessageBoxResult.Cancel:
                    break;

            }

            
        }

        private void copyfun(object sender, RoutedEventArgs e)
        {
            myCanvas.CopySelection();
        }

        private void cutfun(object sender, RoutedEventArgs e)
        {
            myCanvas.CutSelection();
        }

        private void pastefun(object sender, RoutedEventArgs e)
        {
            myCanvas.Paste();
        }
    }
}
