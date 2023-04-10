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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shveynaya_29_03_23_1
{
    /// <summary>
    /// Логика взаимодействия для StorekeeperFabricList.xaml
    /// </summary>
    public partial class StorekeeperFabricList : Page
    {
        Shveynaya3Entities db;
        public StorekeeperFabricList()
        {
            InitializeComponent();
            db = new Shveynaya3Entities();
            db.FabricStock.Load();


            FabricListDataGrid.ItemsSource = db.FabricStock;

        }

        

    }
}
