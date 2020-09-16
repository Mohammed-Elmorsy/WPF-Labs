using System;
using System.Collections.Generic;
using System.IO;
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

namespace WpfApp3
{
    /// <summary>
    /// Interaction logic for flowdocumentreader.xaml
    /// </summary>
    public partial class flowdocumentreader : Window
    {
        public flowdocumentreader()
        {
            InitializeComponent();
        }

        private void readtextfile(object sender, RoutedEventArgs e)
        {
            // read text file
           StreamReader sr =  File.OpenText("d:/iti.txt");
            string myfile=sr.ReadToEnd();
           string[] lines= myfile.Split('\n');
            for (int i = 0; i < lines.Length; i++)
            {
                Paragraph p = new Paragraph();
                /* Task for Students */
             /* Complete Creation OF p Tag And Add it to Block Collection For Flow document container */   

                //mydocument.Blocks.Add(new Paragraph())
                //Paragraph p = new Paragraph(new Inline(lines[i]) );
            }
            //mydocument.Blocks.Add()
        }
    }
}
