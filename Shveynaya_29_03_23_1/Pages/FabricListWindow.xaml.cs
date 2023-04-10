using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace Shveynaya_29_03_23_1
{
    /// <summary>
    /// Логика взаимодействия для StorekeeperFabricListWindow.xaml
    /// </summary>
    public partial class FabricListWindow : Window
    {
        Shveynaya3Entities db;
        public FabricListWindow()
        {
            InitializeComponent();
            db = new Shveynaya3Entities();
            db.Fabric.Load();

            FabricListDataGrid.ItemsSource = db.Fabric;
        }
    }
}
