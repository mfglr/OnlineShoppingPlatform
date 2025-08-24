<h1>Online Shopping Platform</h1>

<h2>Kullanılan Teknoloji, Mimari ve Tasarımlar</h2>

<p>
  <h3>Bu projede kullanılan teknoloji ve paketler</h3>
  <b><ul>
    <li>.Net 9</li>
    <li>Entity Framework Core</li>
    <li>MediatR</li>
    <li>JWT</li>
    <li>Kullanıcılara mail göndermek için Google’ın Gmail servisi (SMTP) </li>
  </ul></b>

  <h3>Bu projede kullanılan mimari ve tasarımlar</h3>
  <b>
    <ul>
      <li>Domain Driven Design (DDD)</li>
      <li>Unit of Work Pattern</li>
      <li>Generic Repository Pattern</li>
      <li>Clean Architecture</li>
    </ul>
  </b>
</p>

<h2>Modular Monolithic Mimari</h2>

<p>
  Proje monolithictir. Ancak ilerleyen zamanlarda artan kullanıcı sayısı nedeniyle performans iyleştirmelerine ihtiyaç duyacaktır. Bu nedenle proje monolithic mimari ve micro service mimari arasinda olan
  modular monolithic mimari olarak geliştirilmiştir.
</p>

<h3>Monolithic (Monolitik) Mimari Nedir</h3>
<p>
  Monolithic, bir yazılımın tüm bileşenlerinin (UI, iş mantığı, veri erişimi vb.) tek bir bütün (single unit) olarak geliştirilip dağıtılması demektir.
  Yani; uygulama tek bir kod tabanında toplanır, tek bir build ve tek bir deployment paketi (ör. .exe, .jar, .war, .dll) vardır ve genellikle tek bir veritabanı kullanır.
</p>

<h4> Monolithic (Monolitik) Mimarinin Dezavantajları </h4>

<p>
  <ul>
    <li>Büyüdükçe karmaşıklaşır → Kod tabanı büyüdüğünde yönetmek zorlaşır.</li>
    <li>Tek hata tüm sistemi etkiler → Bir modüldeki problem tüm uygulamayı çökertir.</li>
    <li>Ölçekleme sınırlı → Sistemin bir kısmını değil, tüm uygulamayı yatay/dikey ölçeklemek gerekir.</li>
    <li>Teknoloji bağımlılığı → Tüm sistem genelde aynı teknoloji stack’iyle yazılmak zorunda kalır.</li>
  </ul>
</p>

<h3>Micro Services Mimari Nedir</h3>

<p>
  Microservices, bir yazılım sistemini küçük, bağımsız ve birbirinden gevşek bağlı servislerden (services) oluşturan mimari yaklaşımdır.
  Yani uygulama tek parça (monolith) olmak yerine; her işlevsel alan (kullanıcı yönetimi, ürün, sepet, ödeme vb.) ayrı bir servis olarak geliştirilir,
  bu servisler bağımsız deploy edilir, bağımsız ölçeklenir ve kendi veritabanlarına sahip olabilir,
  servisler genelde API (REST, gRPC, GraphQL) veya messaging (RabbitMQ, Kafka) ile haberleşir.
</p>

<h4>Micro Services Mimarinin Avantajları </h4>

<p>
  <ul>
    <li>Ölçeklenebilirlik → Sadece yoğun kullanılan servisler ölçeklenir (ör. “ProductService”).</li>
    <li>Esneklik → Her servis farklı teknoloji stack kullanabilir.</li>
    <li>Hızlı geliştirme → Farklı ekipler paralel çalışabilir.</li>
    <li>Dayanıklılık → Bir servis çökerse tüm sistem çökmez (örneğin ödeme servisi çalışmıyorsa, ürün arama yine çalışır).</li>
  </ul>
</p>

<h3>Modular Monolithic Mimari Nedir</h3>
<p>
  Modular Monolithic, tek bir uygulama olarak dağıtılan (monolith) ama içinde modüllere ayrılmış, bağımsız bir şekilde tasarlanmış bir mimari yaklaşımıdır.
  Yani; uygulama tek bir deploy birimi olarak çalışır, ancak kod tabanı bağımsız modüller halinde organize edilir (UserModule, ProductModule, OrderModule gibi),
  modüller sadece kendi sorumluluklarını bilir, diğer modüllerle arayüz (interface/API) üzerinden iletişim kurar.
</p>

<p>
  <b>Bir uygulama yeni geliştiriliyorsa ilk önce modular monolithic mimari ile geliştirilmeli.</b>
</p>

<h2>Domain Driven Design (DDD)' nin Taktiksel Tasarımı</h2>

<p>
  Domain-Driven Design, yazılım geliştirmede iş alanını (domain) merkezine alan, karmaşık iş kurallarını yönetmeyi kolaylaştıran bir tasarım yaklaşımıdır.
</p>

<h3>Entity</h3>
<p>
  Kimliği ve state' i olan neslerdir. Örnek Order, OrderItem
</p>

<img width="1047" height="572" alt="entity" src="https://github.com/user-attachments/assets/9bab123e-2c4c-46e5-b6fb-e42be8eec26a" />

<h3>Value Object</h3>
<p>
  Kimliği ve state' i olmayan neslerdir. Örnek Phone Number
</p>
<img width="951" height="450" alt="ValueObject" src="https://github.com/user-attachments/assets/b9ee7be6-577c-447d-b24b-1e8f66331036" />

<h3>Aggregate Root</h3>

<p>
  Bir veya daha fazla entity ve value object’in mantıksal olarak bir araya gelmiş grubudır.
  Diğer entity veya value object’lere dışarıdan doğrudan erişilemez, root üzerinden işlem yapılır. Örnek Order. OrderItem' lar ve OrderState Order Aggregate Root' u ile yönetilir.
</p>

<img width="600" height="658" alt="aggregateRoot" src="https://github.com/user-attachments/assets/680489ce-4139-4350-b79b-3a4bad8e94e1" />

<h3>Domain Service</h3>
<p>
  Bir işlemi gerçekleştirmek için birden fazla aggregate root' un state' ne ihtiyaç duduğumuzu düşünelim. Bu durumda Domain service yazılmalı. Örneğin sepete bir ürün eklemek isteyelim.
  Bu ürünün eklenebilmesi için yeterli stoğa sahip olması lazım. Yani ürünün stock bilgisine ihtiyacımız var.
</p>

<img width="1271" height="422" alt="Screenshot 2025-08-23 205011" src="https://github.com/user-attachments/assets/284ad108-b103-45e3-96b4-ee1c6a1bc029" />

<h3>Aggregate Root' lar arası haberleşme</h3>
<p>
  Bu projede Cart, Order, User, Product, ProductUserLike ve Category adında 6 adet aggregate root vardır. İleri her bir aggregate root un farklı bir micro service olacağı varsayılarak geliştirilme yapılmıştır.
  Bu nedenle aggregate root lar arasındaki haberleşme <b>event</b> ler ile yapılmıştır. Bu eventleri yayınlamak ve dinlemek için <bold>MediatR</bold> kütüphanesi kullanılmıştır.
  İlerleyen zamanlarda proje farklı mikro servislere bölündüğünde bu eventlerin yayınlamak ve dinlemek için bir Message Broker (RabbitMQ, Kafka) teknolojisi kullanılmalı.
</p>

<img width="1390" height="152" alt="Event" src="https://github.com/user-attachments/assets/d3307ffd-3245-42b5-8318-18000dd386e3" />

<img width="1462" height="497" alt="EventPublishing" src="https://github.com/user-attachments/assets/466c4267-d747-4d26-92a4-51bac70a0394" />


<h2>User Case' ler</h2>
<p>
  Bu projede basit bir e-ticaret sitesinin backend' de gerçekleşen bazı use caseler implemente edilmiştir. Bu projede implemente edilen use caseler aşağıdaki gibidir:
</p>

<h3>Cart (Sepet)</h3>
<ul>
  <li>Bir ürünün sepete eklenmesi.</li>
  <li>Bir ürünün sepetten silinmesi</li>
  <li>Sepetteki ürünün sayısının bir arttırılması.</li>
  <li>Sepetteki ürünün sayısının bir azaltılması.</li>
  <li>Sepetin onaylanması</li>
</ul>

<h3>Order (Sipariş)</h3>
<ul>
  <li>Siparişin iptal edilmesi</li>
  <li>Siparişlerin görüntülenmesi</li>
  <li>Başarılı olan siparişlerin görüntülenmesi</li>
  <li>İptal edilen siparişlerin görüntülenmesi</li>
</ul>

<h3>Product (Ürün)</h3>
<ul>
  <li>Bir ürünün admin tarafından oluşturulması</li>
  <li>Bir ürünün adının admin tarafından değiştirilmesi</li>
  <li>Bir ürünün stoğunun admin tarafından arttırılması</li>
  <li>Bir ürünün admin tarafından silinmesi</li>
  <li>Bir ürünün bir kullanıcı tarafından beğenilenler listesine eklenmesi</li>
  <li>Tüm ürünlerin görüntülenmesi</li>
  <li>Bir ürünün görüntülenmesi</li>
  <li>Ürünlerin kategorilere göre görüntülenmesi</li>
  <li>Ürünlerin arananması</li>
  <li>Kullanıcının beğendiği ürünleri görüntülemesi</li>
</ul>

<h3>Category (Kategori)</h3>
<ul>
  <li>Bir categorinin admin tarafından oluşturulması</li>
  <li>Bir categori adının admin tarafından güncellenmesi</li>
  <li>Bir categori admin tarafından silinmesi</li>
  <li>Tüm kategorilerin görüntülenmesi</li>
</ul>

<h3>User (Kullanıcı)</h3>
<ul>
  <li>Kullanıcının oluşturulması</li>
  <li>Kullanıcının adını güncellemesi</li>
  <li>Kullanıcının soyadını güncellemesi</li>
  <li>Kullanıcının telefon numarasını güncellemesi</li>
  <li>Kullanıcının sifresini güncellemesi</li>
  <li>Kullanıcının emailini güncellemesi</li>
  <li>Kullanıcının password ile giriş yapması</li>
  <li>Kullanıcının refresh token ile giriş yapması</li>
  <li>Kullanıcının email onaylama kodunu üretmesi</li>
  <li>Kullanıcının emailini onaylaması</li>
  <li>Kullanıcının sifre sıfırlama kodu üretmesi</li>
  <li>Kullanıcının sifresini sıfırlaması</li>
  <li>Kullanıcının hesabını silmesi</li>
</ul>

<h2>Distributed Transaction</h2>
<p>
  Distributed Transaction, birden fazla bağımsız veri kaynağı (ör. farklı veritabanları, microservice’ler) üzerinde tek bir işlem (transaction) yürütülmesidir.
  Normal bir transaction:
  <ul>
    <li>Tek bir veritabanında gerçekleşir (ör. SQL Server, PostgreSQL).</li>
    <li>ACID kurallarına (Atomicity, Consistency, Isolation, Durability) uyar.</li>
    <li>ACID kurallarına (Atomicity, Consistency, Isolation, Durability) uyar.</li>
    
  </ul>
  Distributed transaction:
  <ul>
    <li>Birden fazla sistem/veritabanı/servisi kapsar.</li>
    <li>Amaç: Hepsi ya başarılı olsun ya da hepsi geri alınsın (rollback).</li>
    <li>Bunu sağlamak saga pattern kullanılır.</li>
  </ul>
  Nasıl Çalışır? Bir saga, birden fazla local transaction’dan oluşur. Her local transaction; 
  bir iş adımı (action) yapar, eğer başarısız olursa daha önceki adımlar için bir telafi (compensation) işlemi çalıştırılır.
</p>

<h3>Sepetin Onaylanması</h3>

<p>
  Sepet onaylandığında kullanıcı sepetteki ürünleri satın alma niyetini gösterir. Dolayısıyla sepetın boşaltılması ve alınınan ürünlerin stoklarının satın alınan ürün kadar azaltılması gerekir.
  Tabiki ürünlerden yeterince varsa. Ürünlerden yeterince var olduğunda ise stok azaltılır ve sipariş oluşturulur. Eğer ürünlerden yeterince yoksa boşaltılan sepet güncel stok değerlerine göre tekrar doldurulup
  kullanıcıya bir bildirim gönderilir.
</p>

<p>
  Yukarıdaki süreç boyunca üç farklı aggregate root' da işlem yapılması gerekti. Bunlar Cart, Product ve Order. Bu Aggregate root' ların statelerinin koşullara göre güncellenebilmesi için event' ler yayınlanır.
</p>

<img width="875" height="680" alt="confırmCart" src="https://github.com/user-attachments/assets/afdb1084-8cd6-4d9f-8cc9-ab30e85a3c78" />

<h2>Data Protection</h2>

<p>
  Bu projede şifreleri ve tokenları güvenle veri tabanında saklamak için PBKDF2 algoritması kullanıldı.
</p>

<h3>PBKDF2 Algorithm</h3>
<p >
  PBKDF2, zayıf/parola tabanlı girdilerden güvenli anahtarlar üretmek için tasarlanmış bir anahtar türetme fonksiyonudur.
</p>

<h4>Amaç</h4>
<ul>
  <li>Zayıf/parola tabanlı girişleri (ör. kullanıcı şifreleri) alıp,</li>
  <li>Daha güvenli, brute‑force ve rainbow table saldırılarına karşı dayanıklı hale getirmek.</li>
</ul>

<h4>Nasıl Çalışır?</h4>
<p>
  PBKDF2 temelde üç parametre alır:
</p>
<ul>
  <li><strong>Parola (Password)</strong> — Kullanıcının girdiği şifre.</li>
  <li><strong>Tuz (Salt)</strong> — Rastgele ek veri (parolaya eklenir).<br/>
  <small>• Aynı şifrenin farklı sonuç üretmesini sağlar.<br/>• Rainbow table saldırılarını engeller.</small>
  </li>
  <li><strong>Iterasyon Sayısı (Iteration Count)</strong> — Hash’in kaç kez tekrar edileceği.<br/>
    <small>• Brute‑force saldırılarını yavaşlatır.</small>
  </li>
</ul>


<h2>Pagination ve ToPage() Extention</h2>

<p>
  “Pagination” (sayfalama), genellikle bir veri kümesinin tamamını tek seferde göstermek yerine, küçük parçalara veya sayfalara bölerek sunma yöntemidir. Bu, özellikle web uygulamalarında veya büyük veri tabanlarında kullanılır. Amaç hem performansı artırmak hem de kullanıcı deneyimini iyileştirmektir.
</p>

<h3>Pagination Türler</h3>

<p>
  <b>Offset-based Pagination:</b> Belirli bir başlangıç noktası ve limit kullanılır. Örn: SQL’de LIMIT 20 OFFSET 40. </br>
  <b>Cursor-based Pagination:</b> Her kaydın benzersiz bir işaretçisi (cursor) kullanılır. Büyük veri ve sürekli güncellenen listelerde daha etkilidir.
</p>

<h3>ToPage Extention</h3>

<p>
  ToPage() extention, IQueryable<T> türündeki veri sorgularına sayfalama (pagination) özelliği ekleyen bir extension method’tur. Cursor-based pagination mantığını kullanır ve verileri artan veya azalan sırada sayfalara bölebilir.
</p>

<ul>
  <li>
      <b>Parametreler:</b> Page sınıfı, sayfa boyutu (Take), sayfa yönü (IsDescending) ve başlangıç noktası (Offset) bilgilerini taşır.
    </li>
  <li>
      <b>Çalışma Mantığı:</b>
      Eğer IsDescending true ise; offset belirtilmişse, sadece Id değeri Offset’ten küçük olan kayıtlar seçilir.
      Kayıtlar Id alanına göre azalan sırada sıralanır ve Take kadar kayıt alınır.
      Eğer IsDescending false ise; offset belirtilmişse, sadece Id değeri Offset’ten büyük olan kayıtlar seçilir.
      Kayıtlar artan sırada sıralanır ve Take kadar kayıt alınır.
    </li>
    <li>
      <b>Avantajları:</b>
      Büyük veri kümelerinde performanslıdır, çünkü yalnızca gerekli kayıtları sorgular.
      Kullanıcı arayüzünde sayfalar halinde veri sunulmasını sağlar.
      Offset değeri sayesinde önceki sayfaların tekrar yüklenmesi engellenir (cursor-based pagination).
    </li>
    <li>
      <b>Kapsam:</b> Entity sınıfını temel alan tüm tipler için çalışır (where T : Entity). Bu sayede her entity’de bulunan Id alanı üzerinden sayfalama yapılabilir.
    </li>
</ul>

<img width="1312" height="487" alt="ToPage" src="https://github.com/user-attachments/assets/7f189a0d-7f59-45d5-b44d-d982dea16f14" />

<img width="843" height="55" alt="Page" src="https://github.com/user-attachments/assets/002d048a-1820-4d51-931b-ccfc552a1c15" />

<h2>Queryable Mappers And Query Repositories</h2>

<h3>Queryable Mappers</h3>
<p>
  Entity den DTO ya mapping yapand extention methodlardır. Bir IQueryable&lt;TEntity&gt; alıp, IQueryable&lt;Dto&gt; döndür.
  Böylece veritabanında LINQ query çalıştırılırken, gereksiz dataların çekilmesi engellenir.
</p>

<img width="1417" height="673" alt="QueryableMapper" src="https://github.com/user-attachments/assets/0f83b106-22a0-44f5-ad1c-ac6bd7632648" />

<h3>Query Repository</h3>

<p>
  Query Repository' ler ise 0Read-only, performans odaklı, DTO veya projection döndüren, veri okuma işlemlerini yöneten repository' lerdir.
</p>

<img width="1137" height="727" alt="QueryRepository" src="https://github.com/user-attachments/assets/8b0eae72-fc46-475a-a3e3-bb94ee02e8dd" />

<h2>Generic Repository Pattern</h2>

<p>
  <b>Repository Pattern</b>, veri tabanına erişim kodlarını (CRUD işlemleri gibi) soyutlayarak, domain veya business katmanını veri erişim detaylarından ayırır.
Business logic katmanı, veriye nasıl erişildiğini bilmeden sadece repository üzerinden işlem yapar.
</p>
<p>
  <b>Generic Repository Pattern</b> ise, Repository Pattern’in generic (tüm entity’ler için ortak) bir hale getirilmiş versiyonudur.
Yani her entity için ayrı repository yazmak yerine, tek bir generic repository sınıfı yazılır ve bu sınıf tüm entity’lerde kullanılabilir.
</p>

<img width="1126" height="473" alt="genericRepository" src="https://github.com/user-attachments/assets/36d76390-21a1-40b1-8853-fae79e6dc4d4" />


<h2>Kimlik Doğrulama(Authentication) ve Yetkilendirme(Authorization)</h2>

<p>
  Kimlik doğrulama ve yetkilendirme için, JSON Web Token (JWT) ve Refresh Token çifti kullanılmıştır. JWT, kullanıcının kimliğini veya yetkilerini temsil eden, imzalanmış bir JSON nesnesidir.
  Refresh Token ise JWT( access token)' u güncellemek için kullanılan hashlenmiş bir tokendir.
</p>

<img width="1247" height="647" alt="accessTokenGenerator" src="https://github.com/user-attachments/assets/d3dccb87-f618-44e3-9cb3-484fd4b72b96" />



  




