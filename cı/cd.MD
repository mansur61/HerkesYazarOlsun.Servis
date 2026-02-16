Bak;
HerkesYazarOlsun.Model -> githubta private paket olarak yayınlandı. Herhangi bir eklemeler olursa
ilgili projenin csptojunda versiyon bilgisini güncelle ve herkesyazarolsun.model.packages branche
ya push veya devden -> herkesyazarolsun.model.packages pull-req atarak action tetiklenerek pakette güncellenmektedir.
bu işlem public-model.yaml da yapılmaktadır

CI/CD süreçlerinde ise;

dev->test https://api.herkesyazarolsun.com.tr/test klasöre ilgili publish olmaktadır
dev->main https://api.herkesyazarolsun.com.tr/prod klasöre ilgili publish olmaktadır
ci/cd süreçlede bizde kubernetes yok bu yüzden direkt file uploud olarak ilerlenmektedir. CD kısmında bizimki CD = Continuous Delivery olmaktadır. BU süreçlerde ilgili private github package 
indirilmektedir.

dev'e gelen pr veya pushlarda tetikleme yoktur

