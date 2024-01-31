using System.Collections.ObjectModel;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace VeriskTest
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private ObservableCollection<Item> itemsList = new ObservableCollection<Item>();

        public MainWindow()
        {
            InitializeComponent();
            btnAdd.Visibility = Visibility.Hidden;
            btnUpdate.Visibility = Visibility.Hidden;
            lstItems.ItemsSource = itemsList;
            EnableFields(false);
        }

        private void ButtonAddItem_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtName.Text))
            {
                Item newItem = new Item
                {
                    Name = txtName.Text,
                    Description = txtDescription.Text,
                    Quantity = int.TryParse(txtQuantity.Text, out int quantity) ? quantity : 0
                };

                if (!itemsList.Any(item => item.Name == newItem.Name))
                {
                    itemsList.Add(newItem);
                    lstItems.SelectedItem = newItem;
                    lstItems.Items.Refresh();
                    btnUpdate.Visibility = Visibility.Visible;
                    btnAdd.Visibility = Visibility.Collapsed;
                }
            }
        }

        // ADD VALIDATION
        // Validate name is unique (on add and update)
        // Validate quantity is above 0 (on add and update)

        private void BtnNewItem_Click(object sender, RoutedEventArgs e)
        {
            txtName.Clear();
            txtDescription.Clear();
            txtQuantity.Clear();
            btnAdd.Visibility = Visibility.Visible;
            btnUpdate.Visibility = Visibility.Collapsed;
            EnableFields(true);
        }

        private void ButtonUpdateItem_Click(object sender, RoutedEventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                Item selectedItem = (Item)lstItems.SelectedItem;
                selectedItem.Name = txtName.Text;
                selectedItem.Description = txtDescription.Text;
                selectedItem.Quantity = int.TryParse(txtQuantity.Text, out int quantity) ? quantity : 0;

                // Update the ListBox to reflect changes
                lstItems.Items.Refresh();

                // Reset the UI
                btnUpdate.Visibility = Visibility.Visible;
                btnUpdate.IsEnabled = true;
                btnAdd.Visibility = Visibility.Collapsed;
                EnableFields(true);
                //ClearFields();
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (lstItems.SelectedItem != null)
            {
                Item selectedItem = (Item)lstItems.SelectedItem;
                txtName.Text = selectedItem.Name;
                txtDescription.Text = selectedItem.Description;
                txtQuantity.Text = selectedItem.Quantity.ToString();
                btnAdd.Visibility = Visibility.Collapsed;
                btnUpdate.Visibility = Visibility.Visible;
            }
        }

        private void EnableFields(bool isEnabled)
        {
            txtName.IsEnabled = isEnabled;
            txtDescription.IsEnabled = isEnabled;
            txtQuantity.IsEnabled = isEnabled;
            btnAdd.IsEnabled = isEnabled;
        }
    }

}