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

namespace PuteshestviePoRossiiGilyazov
{
    /// <summary>
    /// Логика взаимодействия для HotelWindow.xaml
    /// </summary>
    public partial class HotelWindow : Window
    {
        public static TestEntities _context = new TestEntities();
        private Hotel _hotel;
        private int _currentPage = 1;
        private int _maxPage = 0;
        public HotelWindow()
        {
            try
            {
                InitializeComponent();

                RefreshHotels();
                this.WindowStartupLocation = WindowStartupLocation.CenterScreen;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        public void RefreshHotels()
        {
            try
            {
                DataGridHotels.ItemsSource = _context.Hotel.OrderBy(h => h.Name).ToList();
                _maxPage = Convert.ToInt32(Math.Ceiling(_context.Hotel.ToList().Count * 1.0 / 10));

                var listHotels = _context.Hotel.ToList().Skip((_currentPage - 1) * 10).Take(10).ToList();

                LblTotalPages.Content = "of " + _maxPage.ToString();
                TxtCurrentPageNumber.Text = _currentPage.ToString();
                DataGridHotels.ItemsSource = listHotels;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnEditHotelInfo_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                EditHotelInfoWindow editHotelInfoWindow = new EditHotelInfoWindow(_context, sender, this);
                editHotelInfoWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoFirstPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentPage = 1;
                RefreshHotels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoPrevPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentPage - 1 < 1)
                {
                    return;
                }
                _currentPage = _currentPage - 1;
                RefreshHotels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void TxtCurrentPageNumber_TextChanged(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentPage > 0 && _currentPage <= _maxPage && TxtCurrentPageNumber.Text != "")
                {
                    if(int.Parse(TxtCurrentPageNumber.Text) <= _maxPage)
                    {
                        _currentPage = Convert.ToInt32(TxtCurrentPageNumber.Text);
                        RefreshHotels();
                    }
                    else
                    {
                        MessageBox.Show("Такой страницы нет!", "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                    
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoNextPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (_currentPage + 1 > _maxPage)
                {
                    return;
                }
                _currentPage = _currentPage + 1;
                RefreshHotels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void GoLastPageButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                _currentPage = _maxPage;
                RefreshHotels();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void BtnAddHotel_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                AddHotelWindow addHotelWindow = new AddHotelWindow(_context, this);
                addHotelWindow.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error!", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
