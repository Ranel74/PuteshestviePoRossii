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

namespace PuteshestviePoRossiiGilyazov
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private TestEntities _context = new TestEntities();
        private List<Tour> _tours = new List<Tour>();
        private string _SelectedType;
        private string _FindedName;
        public MainWindow()
        {
            try
            {
                InitializeComponent();
                ListTours.ItemsSource = _context.Tour.OrderBy(tour => tour.Name).ToList();

                List<Type> types = new List<Type>();
                types.Add(new Type() { Name = "Все типы" });
                types.AddRange(_context.Type.OrderBy(t => t.Name).ToList());

                CmbType.ItemsSource = types;

                this._tours = _context.Tour.ToList();
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtFindedTourName_TextChanged(object sender, TextChangedEventArgs e)
        {
            try
            {
                _FindedName = TxtFindedTourName.Text;

                _tours = _context.Tour.OrderBy(t => t.Name).ToList();

                RefreshTours();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void RefreshTours()
        {
            try
            {
                if (CmbType.SelectedItem != null)
                {
                    if ((CmbType.SelectedItem as Type).Name != "Все типы")
                    {
                        Type type = CmbType.SelectedItem as Type;
                        _SelectedType = type.Name;
                        _tours = (from t in _tours
                                  from tn in t.Type
                                  where tn.Name == _SelectedType
                                  select t).ToList();
                    }
                    else if ((CmbType.SelectedItem as Type).Name == "Все типы")
                    {
                        _tours = _context.Tour.OrderBy(t => t.Name).ToList();
                    }
                }

                if (TxtFindedTourName.Text != "")
                {
                    _tours = _tours.OrderBy(t => t.Name).Where(t => t.Name.ToLower().Contains(_FindedName)).ToList();
                }

                if ((bool)ChbActual.IsChecked)
                {
                    _tours = _tours.OrderBy(t => t.Name).Where(t => t.IsActual == true).ToList();
                }

                ListTours.ItemsSource = _tours;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CmbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            try
            {
                _tours = _context.Tour.OrderBy(t => t.Name).ToList();

                RefreshTours();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChbActual_Checked(object sender, RoutedEventArgs e)
        {
            try
            {
                _tours = _context.Tour.OrderBy(t => t.Name).ToList();
                RefreshTours();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void ChbActual_Unchecked(object sender, RoutedEventArgs e)
        {
            try
            {
                _tours = _context.Tour.OrderBy(t => t.Name).ToList();
                RefreshTours();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnShowHotelWindow_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                HotelWindow window = new HotelWindow();
                window.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
