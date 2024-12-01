using Avalonia.Controls;
using Avalonia.Interactivity;
using ConstructorDeconstructor_VK_363.Models;

namespace ConstructorDeconstructor_VK_363.Views;


public partial class MainWindow : Window
{
    public MainWindow()
    {
        InitializeComponent();
    }

    private void Button_AppendProduct(object? sender, RoutedEventArgs e)
    {
        bool isValid = true;

        if (string.IsNullOrWhiteSpace(ProductName.Text))
        {
            isValid = false;
            NameError.Text = "Введите название для продукта -_-";
        }
        else
        {
            NameError.Text = string.Empty;
        }

        if (!double.TryParse(ProductPrice.Text, out double productPrice) || productPrice <= 0)
        {
            isValid = false;
            PriceError.Text = "Введите цену для продукта (+_+)";
        }
        else
        {
            PriceError.Text = string.Empty;
        }

        if (string.IsNullOrWhiteSpace(ProductName.Text) &&
            (int.TryParse(ProductQuantity.Text, out int productQuantity) || productQuantity < 0))
        {
            isValid = false;
            QuantityError.Text = "Колво товара не может быть меньше 0 (0_0)";
        }
        else
        {
            QuantityError.Text = string.Empty;
        }

        if (isValid == true)
        {
            int quantity = string.IsNullOrWhiteSpace(ProductQuantity.Text)
                ? Product.defaultQuantity
                : int.Parse(ProductQuantity.Text);
           var product = new Product(ProductName.Text, productPrice,quantity);
           ProductsList.Items.Add(product);

           ClearAllTextBox();
        }
    }

    private void Button_DeconstructionSelectedProduct(object? sender, RoutedEventArgs e)
    {
        if (ProductsList.SelectedItem is Product selectedProduct)
        {
            var (name,price,quantity) = selectedProduct;
            DeconstructedProductInformation.Text = $"Название продукта {selectedProduct.Name}\n" +
                                                   $"Цена продукта {selectedProduct.Price}\n" +
                                                   $"Количетсво продуктов на слкаде {quantity}";
        }
        else
        {
            DeconstructedProductInformation.Text = "Изберите продукт для сего деяния";
        }
    }

    private void ClearAllTextBox()
    {
        ProductName.Text = string.Empty;
        ProductPrice.Text = string.Empty;
        ProductQuantity.Text = string.Empty;
    }
}