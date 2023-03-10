using System;
using System.Collections.Generic;
using System.Diagnostics;
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
using UAS_2823.Controller;
using UAS_2823.Model;
using static UAS_2823.PilihVoucher;

namespace UAS_2823
{
    public partial class MainWindow : Window,
        OnPenawaranChangedListener,
        OnPilihVoucherChangedListener,
        OnPaymentChangedListener,
        OnKeranjangBelanjaChangedListener
    {
        MainWindowController controller;
        Payment payment;

        public MainWindow()
        {
            InitializeComponent();

            payment = new Payment(this);
            payment.setBalance(500000);
            payment.setPromo(0);

            KeranjangBelanja keranjangBelanja = new KeranjangBelanja(payment, this);

            controller = new MainWindowController(keranjangBelanja);

            listBoxPesanan.ItemsSource = controller.getSelectedItems();
            listBoxPakaiVoucher.ItemsSource = controller.getSelectedVouchers();

            initializeView();

        }

        private void initializeView()
        {
            labelSubtotal.Content = 0;
            labelGrantTotal.Content = 0;
            labelPromoFee.Content = (payment.getPromo() > 0) ? -payment.getPromo() : 0;
        }

        public void onPenawaranSelected(Item item)
        {
            controller.addItem(item);
        }

        private void onButtonAddItemClicked(object sender, RoutedEventArgs e)
        {
            Penawaran penawaranWindow = new Penawaran();
            penawaranWindow.SetOnItemSelectedListener(this);
            penawaranWindow.Show();
        }

        private void listBoxPesanan_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin menghapus item ini?",
                    "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Item item = listBox.SelectedItem as Item;
                controller.deleteSelectedItem(item);
            }
        }

        private void listBoxPakaiVoucher_ItemClicked(object sender, MouseButtonEventArgs e)
        {
            if (MessageBox.Show("Kamu ingin membatalkan voucher ini?",
                   "Konfirmasi", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                ListBox listBox = sender as ListBox;
                Voucher item = listBox.SelectedItem as Voucher;
                controller.deleteSelectedVoucher(item);
            }
        }

        public void onPriceUpdated(double subtotal, double grantTotal, double potongan)
        {
            labelSubtotal.Content = "Rp " + subtotal;
            labelGrantTotal.Content = "Rp " + grantTotal;
            labelPromoFee.Content = "Rp " + potongan;
        }

        public void removeItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void addItemSucceed()
        {
            listBoxPesanan.Items.Refresh();
        }

        public void removeVoucherSucceed()
        {
            listBoxPakaiVoucher.Items.Refresh();
        }

        public void addVoucherSucceed()
        {
            listBoxPakaiVoucher.Items.Refresh();
        }

        private void OnPilihVoucherClicked(object sender, RoutedEventArgs e)
        {
            PilihVoucher pilihVoucherWindow = new PilihVoucher();
            pilihVoucherWindow.SetOnItemSelectedListener(this);
            pilihVoucherWindow.Show();
        }

        public void OnPilihVoucherChangedListener(Voucher item)
        {
            controller.addVoucher(item);
        }


    }
}