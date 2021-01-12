Nama  : Yonas Danga Paelongan

NIM   : 19.11.2823

### Aplikasi Penjualan (Yonas.SHOP)


Cara kerja pada aplikasi penjualan ini :


1.Tampilan Awal Pada Aplikasi 


![TampilanAwal](https://user-images.githubusercontent.com/61773943/104223722-92298200-5476-11eb-8171-a107d34574bb.png)



2.Tampilan Daftar Voucher Pada Aplikasi


berfungsi sebagai penambahan jenis voucher / promo serta perhitungan saat penambahan voucher :


``` javascript

 private void generateListVoucher()
        {
            Model.Voucher awalTahun = new Model.Voucher(title: "Promo Awal Tahun Diskon 25%", discInPercent: 25);
            Model.Voucher tebusMurah = new Model.Voucher(title: "Promo Tebus Murah Diskon 30% atau max. 30.000", discInPercent: 30);
            Model.Voucher promoNatal = new Model.Voucher(title: "Promo Natal Potongan 25000", disc: 25000);

            voucherController.addItem(awalTahun);
            voucherController.addItem(tebusMurah);
            voucherController.addItem(promoNatal);

            DaftarVoucher.Items.Refresh();
        }
```


![DaftarVoucher](https://user-images.githubusercontent.com/61773943/104222998-a6b94a80-5475-11eb-87f6-a44a007897a9.png)



3.Tampilan Daftar Penawaran Pada Aplikasi 

berfungsi untuk menampilkan Daftar Penawaran :


``` javascript
 private void generateContentPenawaran()
        {
            Item coffeLate = new Item("Coffe Late", 30000);
            Item blackTea = new Item("BlackTea", 20000);
            Item milkShake = new Item("Milk Shake", 15000);
            Item watermelonJuice = new Item("Watermelon Juice", 25000);
            Item lemonSquash = new Item("Lemon Squash", 30000);
            Item pizza = new Item("Pizza", 75000);
            Item friedRice = new Item("Fried Rice Special", 45000);

            Penawarancontroller.addItem(coffeLate);
            Penawarancontroller.addItem(blackTea);
            Penawarancontroller.addItem(milkShake);
            Penawarancontroller.addItem(watermelonJuice);
            Penawarancontroller.addItem(lemonSquash);
            Penawarancontroller.addItem(pizza);
            Penawarancontroller.addItem(friedRice);

            listPenawaran.Items.Refresh();
        }
```

![DaftarPenawaran](https://user-images.githubusercontent.com/61773943/104223037-afaa1c00-5475-11eb-929e-3ab30b38393a.png)



4. Tampilan Setelah Menambahkan Item Pada Daftar Penawaran dan Memilih salah Satu Voucher :

![TambahV+P](https://user-images.githubusercontent.com/61773943/104223707-8c33a100-5476-11eb-8135-8026928403c7.png)


5. Tampilan Jika Ingin Menghapus Salah Satu Item Pada Daftar Penawaran


Berfungsi untuk output saat penghapusan item pada daftar Penawaran :



``` javascript
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
```
![DeleteItem](https://user-images.githubusercontent.com/61773943/104223692-8938b080-5476-11eb-9930-2e57a5052e21.png)



6. Tampilan Jika Ingin Menghapus Voucher Pada Daftar Voucher 


Berfungsi untuk menampilkan output saat ingin membatalkan voucher yang tela di pilih :


``` javascript
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
```



![DeleteVoucher](https://user-images.githubusercontent.com/61773943/104223700-8b9b0a80-5476-11eb-8c6b-257d3a4d5326.png)


*Yonas.SHOP_2823
