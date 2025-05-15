# Personel Yönetim Sistemi

Personel Yönetim Sistemi, çalışanların giriş-çıkış kayıtlarını, izinlerini ve diğer personel yönetimi işlemlerini takip etmek için geliştirilmiş bir web uygulamasıdır.
![Personeller Sayfası](‪C:\Users\vural\Desktop\personeller.jpg)
![Fotoğraf Açıklaması](fotoğrafın/dosya/yolu.jpg)
![Fotoğraf Açıklaması](fotoğrafın/dosya/yolu.jpg)
## Özellikler
- **Personeller**: Personellerin eklenmesi,silinmesi ve güncellenmesi.
- **Giriş/Çıkış Yönetimi**: Çalışanların giriş ve çıkış saatlerini kaydetme.
- **Raporlama**: Çalışanların belirli tarih aralıklarındaki hareketlerini raporlama.
- **İzin Yönetimi**: Çalışan izinlerini takip etme ve yönetme.
- **Departman ve Pozisyon Yönetimi**: Departman ve pozisyon bilgilerini düzenleme.
- **İstatistikler**: Çalışanlarla ilgili istatistiksel verileri görüntüleme.

## Proje Yapısı

```
PersonelYonetimSistemiNew/
├── Controllers/          # Uygulama kontrolörleri
├── Data/                 # Veritabanı bağlamı
├── Migrations/           # Entity Framework Migrations dosyaları
├── Models/               # Veri modelleri
├── Views/                # Razor View dosyaları
├── wwwroot/              # Statik dosyalar (CSS, JS, img)
├── appsettings.json      # Uygulama ayarları
├── Program.cs            # Uygulamanın giriş noktası
├── PersonelYonetimSistemiNew.csproj # Proje dosyası
```

## Gereksinimler

- **.NET 8.0 SDK**: Projenin çalıştırılması için gereklidir.
- **Microsoft SQL Server**: Veritabanı yönetimi için kullanılır.

## Kurulum

1. Bu projeyi klonlayın:
   ```bash
   git clone <repository-url>
   cd PersonelYonetimSistemiNew
   ```

2. Gerekli bağımlılıkları yükleyin:
   ```bash
   dotnet restore
   ```

3. Veritabanını güncelleyin:
   ```bash
   dotnet ef database update
   ```

4. Uygulamayı çalıştırın:
   ```bash
   dotnet run
   ```

5. Tarayıcınızda `http://localhost:5131` adresine giderek uygulamayı görüntüleyin.

## Kullanılan Teknolojiler

- **ASP.NET Core MVC**: Web uygulaması geliştirme.
- **Entity Framework Core**: ORM (Object-Relational Mapping) aracı.
- **Bootstrap 4**: Kullanıcı arayüzü tasarımı.
- **FontAwesome**: İkon seti.
- **jQuery**: Dinamik web bileşenleri.

## Katkıda Bulunma

Katkıda bulunmak için lütfen bir `fork` oluşturun, değişikliklerinizi yapın ve bir `pull request` gönderin.

