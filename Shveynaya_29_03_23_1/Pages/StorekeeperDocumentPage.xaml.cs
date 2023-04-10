using Microsoft.VisualBasic.FileIO;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Shveynaya_29_03_23_1.Pages
{
    /// <summary>
    /// Логика взаимодействия для StorekeeperDocumentPage.xaml
    /// </summary>
    public partial class StorekeeperDocumentPage : Page
    {
        Shveynaya3Entities db;
        DataGrid storekeeperFabricListDataGrid;

        public StorekeeperDocumentPage()
        {
            InitializeComponent();
            db = new Shveynaya3Entities();
            db.FabricStock.Load();
            db.Fabric.Load();
            db.Unit.Load();


            
        }

        private void FillAccessibleFilesListBox()
        {
            try
            {
                string[] supplyFiles = Directory.GetFiles(@".\Storage\SupplyFiles\", "*.csv");
                AccessibleFilesListBox.ItemsSource = supplyFiles;
            }
            catch { }
        }

        private void AccessibleFilesListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                string[] supplyFiles = Directory.GetFiles(@".\Storage\SupplyFiles\", "*.csv");
                AccessibleFilesListBox.ItemsSource = supplyFiles;
            }
            catch { }
        }

        public string SupplyFileName = string.Empty;

        private void AddFileButton_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog op = new OpenFileDialog();
            op.Title = "Выберите файл";
            op.Filter = "CSV (*.csv)|*.csv";
            if (op.ShowDialog() == true)
            {
                SupplyFileName = op.SafeFileName;
                ParseCsvSupplyFile(op.FileName);
                AcceptFileButton.IsEnabled = true;

            }
        }

            private void AcceptFileButton_Click(object sender, RoutedEventArgs e)
        {

        }

        private void ParseCsvSupplyFile(string filePath)
        {

            using (TextFieldParser parser = new TextFieldParser(filePath))
            {
                try
                {
                    StorekeeperFabricListDataGrid.Items.Clear();
                    parser.TextFieldType = FieldType.Delimited;
                    parser.SetDelimiters(";");
                    string[] fields = parser.ReadFields();
                    List<FabricStock> list = new List<FabricStock>();
                    while (!parser.EndOfData)
                    {
                        fields = parser.ReadFields();
                        int IdUnitWidth_ = Convert.ToInt32(fields[2]);
                        int IdUnitHeight_ = Convert.ToInt32(fields[4]);
                        FabricStock supplyFileInfo = new FabricStock
                        {
                            IdFabric = fields[0],
                            Width = Convert.ToInt32(fields[1]),
                            IdUnitWidth = Convert.ToInt32(fields[2]),
                            Unit = db.Unit.Where(u => u.Id == IdUnitWidth_).First(),
                            Height = Convert.ToInt32(fields[3]),
                            IdUnitHeight = Convert.ToInt32(fields[4]),
                            Unit1 = db.Unit.Where(u => u.Id == IdUnitHeight_).First(),
                            PurchasePrice = Convert.ToDouble(fields[5])
                        };
                        list.Add(supplyFileInfo);

                    }
                    MessageBox.Show("+1");
                    StorekeeperFabricListDataGrid.ItemsSource = list;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Ошибка чтения файла \n" + ex.ToString());
                }


            }
        }


    }
}
