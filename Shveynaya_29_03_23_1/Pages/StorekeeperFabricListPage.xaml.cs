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

        List<FabricStock> FabricStockResult { get; set; }
        List<Fabric> FabricResult { get; set; }
        List<UnitConvert> UnitConvertResult { get; set; }
        List<Unit> UnitResult { get; set; }

        public class Result
        {
            int Id;
            string Name;
            double Width;
            double Height;
            double PurchasePrice;
        }
        public StorekeeperFabricList()
        {
            InitializeComponent();
            AddToDataGrid.IsEnabled = false;
            RemoveFromDataGrid.IsEnabled = false;
            db = new Shveynaya3Entities();

            DocumentFrame.NavigationService.Navigate(new Uri("./../Pages/StorekeeperDocumentPage.xaml", UriKind.RelativeOrAbsolute));

            Refresh();

            FabricListDataGrid.ItemsSource = from fS in FabricStockResult
                                             join f in FabricResult on fS.IdFabric equals f.Id
                                             join u in UnitResult on fS.IdUnitWidth equals u.Id
                                             join u1 in UnitResult on fS.IdUnitHeight equals u1.Id
                                             select new { Id = fS.Id, Name = f.Name, Width = fS.Width, Height = fS.Height, PurchasePrice = fS.PurchasePrice, Unit = u.Name, Unit1 = u1.Name };

        }

        //private IQueryable<Result> GetResult()
        //{
        //    IQueryable<Result> LinqResult = (IQueryable<Result>)(from fS in db.FabricStock
        //                     join f in db.Fabric on fS.IdFabric equals f.Id
        //                     select new { Id = fS.Id, Name = f.Name, Width = fS.Width, Height = fS.Height, PurchasePrice = fS.PurchasePrice });
        //    return LinqResult;
        //}

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            if (SearchFabricStockTextBox != null)
            {
                var LinqSearch = from fS in FabricStockResult
                                 join f in FabricResult on fS.IdFabric equals f.Id
                                 join u in UnitResult on fS.IdUnitWidth equals u.Id
                                 join u1 in UnitResult on fS.IdUnitHeight equals u1.Id
                                 where (f.Name.ToUpper().Contains(SearchFabricStockTextBox.Text.Trim().ToUpper()) ||
           fS.Id.ToString().Contains(SearchFabricStockTextBox.Text.Trim()))
                                 select new { Id = fS.Id, Name = f.Name, Width = fS.Width, Height = fS.Height, PurchasePrice = fS.PurchasePrice, Unit = u.Name, Unit1 = u1.Name };
                FabricListDataGrid.ItemsSource = LinqSearch;
            }
            else
            {
                FabricListDataGrid.ItemsSource = from fS in FabricStockResult
                                                 join f in FabricResult on fS.IdFabric equals f.Id
                                                 join u in UnitResult on fS.IdUnitWidth equals u.Id
                                                 join u1 in UnitResult on fS.IdUnitHeight equals u1.Id
                                                 select new { Id = fS.Id, Name = f.Name, Width = fS.Width, Height = fS.Height, PurchasePrice = fS.PurchasePrice, Unit = u.Name, Unit1 = u1.Name };
            }
        }

        private void RefreshButton_Click(object sender, RoutedEventArgs e)
        {
            Refresh();
        }
        private void Refresh()
        {
            SearchFabricStockTextBox.Text = null;

            db.FabricStock.Load();
            db.Fabric.Load();
            db.UnitConvert.Load();
            db.Unit.Load();
            FabricStockResult = db.FabricStock.ToList();
            FabricResult = db.Fabric.ToList();
            UnitConvertResult = db.UnitConvert.ToList();
            UnitResult = db.Unit.ToList();


            FabricListDataGrid.ItemsSource = from fS in FabricStockResult
                                             join f in FabricResult on fS.IdFabric equals f.Id
                                             join u in UnitResult on fS.IdUnitWidth equals u.Id
                                             join u1 in UnitResult on fS.IdUnitHeight equals u1.Id
                                             select new { Id = fS.Id, Name = f.Name, Width = fS.Width, Height = fS.Height, PurchasePrice = fS.PurchasePrice, Unit = u.Name, Unit1 = u1.Name };
        }

        private void AddToDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if(FabricListDataGrid.SelectedItem != null)
            {
                StorekeeperFabricListDataGrid.Items.Add(FabricListDataGrid.SelectedItem);
                
            }
        }

        private void RemoveFromDataGrid_Click(object sender, RoutedEventArgs e)
        {
            if (StorekeeperFabricListDataGrid.SelectedItem != null)
            {
                StorekeeperFabricListDataGrid.Items.Remove(StorekeeperFabricListDataGrid.SelectedItem);
            }
        }

        private void MakeDocument_Click(object sender, RoutedEventArgs e)
        {
            DocumentFrame.NavigationService.Navigate(new Uri("./../Pages/StorekeeperDocumentPage.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
