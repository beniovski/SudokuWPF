using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Sudoku
{
    /// <summary>
    /// Logika interakcji dla klasy MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            TextBoxGeneration();
        }

        private void TextBoxGeneration()
        {
            int textBoxNum = 81;
            int colNum = 1;
            int pozInRow = 1;

            for(int i = 1; i <= textBoxNum; i++)
            {
                var el = new TextBox();
                el.Height = 30;
                el.Width = 30;
                string name = colNum.ToString() + ":" + pozInRow.ToString();
                el.Name = "box"+i;
                el.TextAlignment = TextAlignment.Center;
                el.VerticalAlignment = VerticalAlignment.Center;
                el.FontSize = 20;
                el.MaxLength = 1;
                el.PreviewTextInput += InputValidation;
                el.Text = "1";
                el.IsReadOnly = true;
                el.Background = Brushes.LightSlateGray;
                
                if (i%9 == 0)
                {
                    Canvas.SetLeft(el, 45 * pozInRow);
                    Canvas.SetTop(el, 45 * colNum);
                    canvas1.Children.Add(el);
                    colNum++;
                    pozInRow = 1;
                }
                else
                {
                    Canvas.SetLeft(el, 45 * pozInRow);
                    Canvas.SetTop(el, 45 * colNum);
                    canvas1.Children.Add(el);
                    pozInRow++;
                }             

                
               
            }
        }

        private void InputValidation(object sender, TextCompositionEventArgs e)
        {
            Regex regex = new Regex("[^0-9]+");
            e.Handled = regex.IsMatch(e.Text);
        }

       
    }
}
