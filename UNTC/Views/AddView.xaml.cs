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

namespace UNTC.Views
{
    /// <summary>
    /// Логика взаимодействия для AddView.xaml
    /// </summary>
    public partial class AddView : UserControl
    {
        private static readonly Regex _regex = new Regex("[^0-9,]+");
        public AddView()
        {
            InitializeComponent();
        }

        private void TBDepth_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }

        private void TBDensity_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            e.Handled = IsTextAllowed(e.Text);
        }
        private bool IsTextAllowed(string text)
        {
            return _regex.IsMatch(text);
        }
    }
}
