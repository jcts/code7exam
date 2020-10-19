using Code7.WeChip.Application.Contracts;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Code7.WeChip.Presentation.Wpf.UserControls
{
    /// <summary>
    /// Interaction logic for CustomerCreate.xaml
    /// </summary>
    public partial class CustomerCreate : UserControl
    {
        readonly ICustomerApp _customerApp;

        public CustomerCreate()
        {
            InitializeComponent();
        }

        private void SalvarCliente_Click(object sender, RoutedEventArgs e)
        {
            _customerApp.Create(null);
        }
    }
}
