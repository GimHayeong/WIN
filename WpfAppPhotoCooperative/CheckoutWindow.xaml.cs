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
using WpfAppPhotoCooperative.BLL;

namespace WpfAppPhotoCooperative
{
    /// <summary>
    /// CheckoutWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class CheckoutWindow : Window
    {
        public PrintList ShoppingCart { get; set; }
        public CardBrand SelectedCard { get; set; }

        public CheckoutWindow()
        {
            InitializeComponent();

            InitData();
        }

        private void InitData()
        {
            SelectedCard = CardBrand.NotSelected;
        }

        /// <summary>
        /// 카드결제 방법 선택
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CreditCardRadioButton_Click(object sender, RoutedEventArgs e)
        {
            RadioButton rbtn = sender as RadioButton;
            if(rbtn != null)
            {
                switch (rbtn.Name)
                {
                    case "rbtnVisa":
                        SelectedCard = CardBrand.Visa;
                        break;

                    case "rbtnMasterCard":
                        SelectedCard = CardBrand.MasterCard;
                        break;

                    case "rbtnAmericanExpress":
                        SelectedCard = CardBrand.AmericanExpress;
                        break;

                    case "rbtnDiscover":
                        SelectedCard = CardBrand.Discover;
                        break;

                    default:
                        SelectedCard = CardBrand.NotSelected;
                        break;
                }
            }
        }

        /// <summary>
        /// 결제처리 버튼
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ProcessOrderButton_Click(object sender, RoutedEventArgs e)
        {
            string creditCardNumber = tbxCreditCardNumber.Text;

            if(SelectedCard == CardBrand.NotSelected)
            {
                MessageBox.Show("Please select a credit card type"
                                , "Invalid card"
                                , MessageBoxButton.OK
                                , MessageBoxImage.Error);
            }
            else
            {
                if(CreditCardValidator.Validate(SelectedCard, creditCardNumber))
                {
                    lblResult.Content = "Validated.";
                }
                else
                {
                    lblResult.Content = "Invalid card number.";
                }
            }
        }
    }
}
