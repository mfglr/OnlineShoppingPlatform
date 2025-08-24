# Online Shopping Platform

# İçindekiler

<a href="#id1">1 Kullanılan Teknoloji, Mimari ve Tasarımlar</a> </br>
<a href="#id1_1">1.1 Bu projede kullanılan teknoloji ve paketler</a>></br>
<a href="#id1_2">1.2 Bu projede kullanılan mimari ve tasarımlar</a></br>
<a href="#id2">2 Modular Monolithic Mimari</a></br>
<a href="#id21">2.1 Monolithic (Monolitik) Mimari Nedir</a></br>
<a href="#id211">2.1.1 Monolitik Mimarinin Dezavantajları</a></br>
<a href="#id22">2.2 Micro Services Mimari Nedir</a></br>
<a href="#id221">2.2.1 Micro Services Mimarinin Avantajları</a></br>
<a href="#id23">2.3 Modular Monolithic Mimari Nedir</a></br>
<a href="#id3">3 Domain Driven Design (DDD) Taktiksel Tasarımı</a></br>
<a href="#id31">3.1 Entity</a></br>
<a href="#id32">3.2 Value Object</a></br>
<a href="#id33">3.3 Aggregate Root</a></br>
<a href="#id34">3.4 Domain Service</a></br>
<a href="#id35">3.5 Aggregate Root'lar Arası Haberleşme</a></br>
<a href="#id4">4 User Case'ler</a></br>
<a href="#id41">4.1 Cart (Sepet)</a></br>
<a href="#id42">4.2 Order (Sipariş)</a></br>
<a href="#id43">4.3 Product (Ürün)</a></br>
<a href="#id44">4.4 Category (Kategori)</a></br>
<a href="#id45">4.5 User (Kullanıcı)</a></br>
<a href="#id5">5 Distributed Transaction</a></br>
<a href="#id51">5.1 Örnek: Sepetin Onaylanması</a></br>
<a href="#id6">6. Data Protection</a></br>
<a href="#id61">6.1 [PBKDF2 Algorithm]</a></br>
<a href="#id7">7 Pagination ve ToPage() Extention</a></br>
<a href="#id71">7.1 Pagination Türler</a></br>
<a href="#id72">7.2 ToPage Extention</a></br>
<a href="#id8">8 Queryable Mappers ve Query Repositories</a></br>
<a href="#id81">8.1 Queryable Mappers</a></br>
<a href="#id82">8.2 Query Repository</a></br>
<a href="#id9">9 Generic Repository Pattern</a></br>
<a href="#id10">10 Kimlik Doğrulama (Authentication) ve Yetkilendirme (Authorization)</a></br>
<a href="#id11">11 AppException, GlobalErrorHandlerMiddleware, WriteAppExceptionAsync Extention Method</a></br>
<a href="#id12">12 UserNotFoundFilter ve IUserAccessor</a></br>
<a href="#id13">13 MaintenanceMiddleware</a></br>


<h2 id="id1">1) Kullanılan Teknoloji, Mimari ve Tasarımlar</h2>

<h3 id="id1_1"> 1-1) Bu projede kullanılan teknoloji ve paketler </h3>
<b><ul>
  <li>.Net 9</li>
  <li>Entity Framework Core</li>
  <li>MediatR</li>
  <li>JWT</li>
  <li>Kullanıcılara mail göndermek için Google’ın Gmail servisi (SMTP) </li>
</ul></b>

<h3 id="id1_2">1-2) Bu projede kullanılan mimari ve tasarımlar</h3>
<b>
  <ul>
    <li>Domain Driven Design (DDD)</li>
    <li>Unit of Work Pattern</li>
    <li>Generic Repository Pattern</li>
    <li>Clean Architecture</li>
  </ul>
</b>

<h2 id="id2">2) Modular Monolithic Mimari</h2>

<p>
  Proje monolithictir. Ancak ilerleyen zamanlarda artan kullanıcı sayısı nedeniyle performans iyleştirmelerine ihtiyaç duyacaktır. Bu nedenle proje monolithic mimari ve micro service mimari arasinda olan
  modular monolithic mimari olarak geliştirilmiştir.
</p>

<h3 id="id21">2-1) Monolithic (Monolitik) Mimari Nedir</h3>
<p>
  Monolithic, bir yazılımın tüm bileşenlerinin (UI, iş mantığı, veri erişimi vb.) tek bir bütün (single unit) olarak geliştirilip dağıtılması demektir.
  Yani; uygulama tek bir kod tabanında toplanır, tek bir build ve tek bir deployment paketi (ör. .exe, .jar, .war, .dll) vardır ve genellikle tek bir veritabanı kullanır.
</p>

<h4 id="id211">2-1-1) Monolithic (Monolitik) Mimarinin Dezavantajları</h4>

<p>
  <ul>
    <li>Büyüdükçe karmaşıklaşır → Kod tabanı büyüdüğünde yönetmek zorlaşır.</li>
    <li>Tek hata tüm sistemi etkiler → Bir modüldeki problem tüm uygulamayı çökertir.</li>
    <li>Ölçekleme sınırlı → Sistemin bir kısmını değil, tüm uygulamayı yatay/dikey ölçeklemek gerekir.</li>
    <li>Teknoloji bağımlılığı → Tüm sistem genelde aynı teknoloji stack’iyle yazılmak zorunda kalır.</li>
  </ul>
</p>

<h3 id="id22">2-2) Micro Services Mimari Nedir</h3>

<p>
  Microservices, bir yazılım sistemini küçük, bağımsız ve birbirinden gevşek bağlı servislerden (services) oluşturan mimari yaklaşımdır.
  Yani uygulama tek parça (monolith) olmak yerine; her işlevsel alan (kullanıcı yönetimi, ürün, sepet, ödeme vb.) ayrı bir servis olarak geliştirilir,
  bu servisler bağımsız deploy edilir, bağımsız ölçeklenir ve kendi veritabanlarına sahip olabilir,
  servisler genelde API (REST, gRPC, GraphQL) veya messaging (RabbitMQ, Kafka) ile haberleşir.
</p>

<h4 id="id221">2-2-1) Micro Services Mimarinin Avantajları</h4>

<p>
  <ul>
    <li>Ölçeklenebilirlik → Sadece yoğun kullanılan servisler ölçeklenir (ör. “ProductService”).</li>
    <li>Esneklik → Her servis farklı teknoloji stack kullanabilir.</li>
    <li>Hızlı geliştirme → Farklı ekipler paralel çalışabilir.</li>
    <li>Dayanıklılık → Bir servis çökerse tüm sistem çökmez (örneğin ödeme servisi çalışmıyorsa, ürün arama yine çalışır).</li>
  </ul>
</p>

<h3 id="id23">2-3) Modular Monolithic Mimari Nedir</h3>
<p>
  Modular Monolithic, tek bir uygulama olarak dağıtılan (monolith) ama içinde modüllere ayrılmış, bağımsız bir şekilde tasarlanmış bir mimari yaklaşımıdır.
  Yani; uygulama tek bir deploy birimi olarak çalışır, ancak kod tabanı bağımsız modüller halinde organize edilir (UserModule, ProductModule, OrderModule gibi),
  modüller sadece kendi sorumluluklarını bilir, diğer modüllerle arayüz (interface/API) üzerinden iletişim kurar.
</p>

<p>
  <b>Bir uygulama yeni geliştiriliyorsa ilk önce modular monolithic mimari ile geliştirilmeli.</b>
</p>

<h2 id="id3">3) Domain Driven Design (DDD)' nin Taktiksel Tasarımı</h2>

<p>
  Domain-Driven Design, yazılım geliştirmede iş alanını (domain) merkezine alan, karmaşık iş kurallarını yönetmeyi kolaylaştıran bir tasarım yaklaşımıdır.
</p>

<h3 id="id31"> 3-1) Entity </h3>
<p>
  Kimliği ve state' i olan neslerdir. Örnek Order, OrderItem
</p>

<img width="1047" height="572" alt="entity" src="https://github.com/user-attachments/assets/9bab123e-2c4c-46e5-b6fb-e42be8eec26a" />

<h3 id="id32">3-2) Value Object</h3>
<p>
  Kimliği ve state' i olmayan neslerdir. Örnek Phone Number
</p>
<img width="951" height="450" alt="ValueObject" src="https://github.com/user-attachments/assets/b9ee7be6-577c-447d-b24b-1e8f66331036" />

<h3 id="id33">3-3) Aggregate Root</h3>

<p>
  Bir veya daha fazla entity ve value object’in mantıksal olarak bir araya gelmiş grubudır.
  Diğer entity veya value object’lere dışarıdan doğrudan erişilemez, root üzerinden işlem yapılır. Örnek Order. OrderItem' lar ve OrderState Order Aggregate Root' u ile yönetilir.
</p>

<img width="600" height="658" alt="aggregateRoot" src="https://github.com/user-attachments/assets/680489ce-4139-4350-b79b-3a4bad8e94e1" />

<h3 id="id34">3-4) Domain Service</h3>
<p>
  Bir işlemi gerçekleştirmek için birden fazla aggregate root' un state' ne ihtiyaç duduğumuzu düşünelim. Bu durumda Domain service yazılmalı. Örneğin sepete bir ürün eklemek isteyelim.
  Bu ürünün eklenebilmesi için yeterli stoğa sahip olması lazım. Yani ürünün stock bilgisine ihtiyacımız var.
</p>

<img width="1271" height="422" alt="Screenshot 2025-08-23 205011" src="https://github.com/user-attachments/assets/284ad108-b103-45e3-96b4-ee1c6a1bc029" />

<h3 id="id35">3-5) Aggregate Root' lar arası haberleşme</h3>
<p>
  Bu projede Cart, Order, User, Product, ProductUserLike ve Category adında 6 adet aggregate root vardır. İleri her bir aggregate root un farklı bir micro service olacağı varsayılarak geliştirilme yapılmıştır.
  Bu nedenle aggregate root lar arasındaki haberleşme <b>event</b> ler ile yapılmıştır. Bu eventleri yayınlamak ve dinlemek için <bold>MediatR</bold> kütüphanesi kullanılmıştır.
  İlerleyen zamanlarda proje farklı mikro servislere bölündüğünde bu eventlerin yayınlamak ve dinlemek için bir Message Broker (RabbitMQ, Kafka) teknolojisi kullanılmalı.
</p>

<img width="1390" height="152" alt="Event" src="https://github.com/user-attachments/assets/d3307ffd-3245-42b5-8318-18000dd386e3" />

<img width="1462" height="497" alt="EventPublishing" src="https://github.com/user-attachments/assets/466c4267-d747-4d26-92a4-51bac70a0394" />

<h2 id="id4">4) User Case' ler</h2>

<p>
  Bu projede basit bir e-ticaret sitesinin backend' de gerçekleşen bazı use caseler implemente edilmiştir. Bu projede implemente edilen use caseler aşağıdaki gibidir:
</p>

<h3 id="id41">4-1) Cart (Sepet)</h3>
<ul>
  <li>Bir ürünün sepete eklenmesi.</li>
  <li>Bir ürünün sepetten silinmesi</li>
  <li>Sepetteki ürünün sayısının bir arttırılması.</li>
  <li>Sepetteki ürünün sayısının bir azaltılması.</li>
  <li>Sepetin onaylanması</li>
</ul>

<h3 id="id42">4-2) Order (Sipariş)</h3>
<ul>
  <li>Siparişin iptal edilmesi</li>
  <li>Siparişlerin görüntülenmesi</li>
  <li>Başarılı olan siparişlerin görüntülenmesi</li>
  <li>İptal edilen siparişlerin görüntülenmesi</li>
</ul>

<h3 id="id43">4-3) Product (Ürün)</h3>
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

<h3 id="id44">4-4)Category (Kategori)</h3>
<ul>
  <li>Bir categorinin admin tarafından oluşturulması</li>
  <li>Bir categori adının admin tarafından güncellenmesi</li>
  <li>Bir categori admin tarafından silinmesi</li>
  <li>Tüm kategorilerin görüntülenmesi</li>
</ul>

<h3 id="id45"> 4-5)User (Kullanıcı)</h3>
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

<h2 id="id5">5) Distributed Transaction</h2>
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

<h3 id="id51">5-1) Örnek: Sepetin Onaylanması</h3>

<p>
  Sepet onaylandığında kullanıcı sepetteki ürünleri satın alma niyetini gösterir. Dolayısıyla sepetın boşaltılması ve alınınan ürünlerin stoklarının satın alınan ürün kadar azaltılması gerekir.
  Tabiki ürünlerden yeterince varsa. Ürünlerden yeterince var olduğunda ise stok azaltılır ve sipariş oluşturulur. Eğer ürünlerden yeterince yoksa boşaltılan sepet güncel stok değerlerine göre tekrar doldurulup
  kullanıcıya bir bildirim gönderilir.
</p>

<p>
  Yukarıdaki süreç boyunca üç farklı aggregate root' da işlem yapılması gerekti. Bunlar Cart, Product ve Order. Bu Aggregate root' ların statelerinin koşullara göre güncellenebilmesi için event' ler yayınlanır.
</p>

<img width="875" height="680" alt="confırmCart" src="https://github.com/user-attachments/assets/afdb1084-8cd6-4d9f-8cc9-ab30e85a3c78" />

<h2 id="id6">6) Data Protection</h2>

<p>
  Bu projede şifreleri ve tokenları güvenle veri tabanında saklamak için PBKDF2 algoritması kullanıldı.
</p>

<h3 id="id61">6-1) PBKDF2 Algorithm</h3>
<p>
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


<h2 id="id7">7) Pagination ve ToPage() Extention</h2>

<p>
  “Pagination” (sayfalama), genellikle bir veri kümesinin tamamını tek seferde göstermek yerine, küçük parçalara veya sayfalara bölerek sunma yöntemidir. Bu, özellikle web uygulamalarında veya büyük veri tabanlarında kullanılır. Amaç hem performansı artırmak hem de kullanıcı deneyimini iyileştirmektir.
</p>

<h3 id="id71">7-1) Pagination Türler</h3>

<p>
  <b>Offset-based Pagination:</b> Belirli bir başlangıç noktası ve limit kullanılır. Örn: SQL’de LIMIT 20 OFFSET 40. </br>
  <b>Cursor-based Pagination:</b> Her kaydın benzersiz bir işaretçisi (cursor) kullanılır. Büyük veri ve sürekli güncellenen listelerde daha etkilidir.
</p>

<h3 id="id72">7-2) ToPage Extention</h3>

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

<h2 id="id8">8) Queryable Mappers And Query Repositories</h2>

<h3 id="id81">8-1) Queryable Mappers</h3>
<p>
  Entity den DTO ya mapping yapand extention methodlardır. Bir IQueryable&lt;TEntity&gt; alıp, IQueryable&lt;Dto&gt; döndür.
  Böylece veritabanında LINQ query çalıştırılırken, gereksiz dataların çekilmesi engellenir.
</p>

<img width="1417" height="673" alt="QueryableMapper" src="https://github.com/user-attachments/assets/0f83b106-22a0-44f5-ad1c-ac6bd7632648" />

<h3 id="id82">8-2) Query Repository</h3>

<p>
  Query Repository' ler ise 0Read-only, performans odaklı, DTO veya projection döndüren, veri okuma işlemlerini yöneten repository' lerdir.
</p>

<img width="1137" height="727" alt="QueryRepository" src="https://github.com/user-attachments/assets/8b0eae72-fc46-475a-a3e3-bb94ee02e8dd" />

<h2 id="id9">9) Generic Repository Pattern</h2>

<p>
  <b>Repository Pattern</b>, veri tabanına erişim kodlarını (CRUD işlemleri gibi) soyutlayarak, domain veya business katmanını veri erişim detaylarından ayırır.
Business logic katmanı, veriye nasıl erişildiğini bilmeden sadece repository üzerinden işlem yapar.
</p>
<p>
  <b>Generic Repository Pattern</b> ise, Repository Pattern’in generic (tüm entity’ler için ortak) bir hale getirilmiş versiyonudur.
Yani her entity için ayrı repository yazmak yerine, tek bir generic repository sınıfı yazılır ve bu sınıf tüm entity’lerde kullanılabilir.
</p>

<img width="1126" height="473" alt="genericRepository" src="https://github.com/user-attachments/assets/36d76390-21a1-40b1-8853-fae79e6dc4d4" />


<h2 id="id10">10) Kimlik Doğrulama(Authentication) ve Yetkilendirme(Authorization)</h2>

<p>
  Kimlik doğrulama ve yetkilendirme için, JSON Web Token (JWT) ve Refresh Token çifti kullanılmıştır. JWT, kullanıcının kimliğini veya yetkilerini temsil eden, imzalanmış bir JSON nesnesidir.
  Refresh Token ise JWT( access token)' u güncellemek için kullanılan hashlenmiş bir tokendir.
</p>

<img width="1247" height="647" alt="accessTokenGenerator" src="https://github.com/user-attachments/assets/d3dccb87-f618-44e3-9cb3-484fd4b72b96" />


<h2 id="id11">11) AppException, GlobalErrorHandlerMiddleware, WriteAppExceptionAsync Extention Method</h2>

<p>
  AppException, Exception sınıfından miras alan ve hata kodu (status code)' nu saklayan bir sınıftır. WriteAppExceptionAsync extention methodu ise HttpContext
  nesnesi için genişletilmiş ve AppException' ı HttpContext nesnesinin response' ına yazan methoddur. GlobalErrorHandlerMiddleware ise tüm request pipline' ni dinleyen
  ve hataları handle eden bir middleware' dir.
</p>

<img width="1017" height="108" alt="AppExceptıon" src="https://github.com/user-attachments/assets/dfcd7ca8-86d8-41e2-87b2-0574178ee9c3" />

<img width="1046" height="230" alt="extentions" src="https://github.com/user-attachments/assets/fccdc1a4-981a-43d5-9e25-17624ae64e8d" />

<img width="871" height="490" alt="GlobalErrorHandlıng" src="https://github.com/user-attachments/assets/628a0843-f15f-4985-a272-da5afd49128e" />


<h2 id="id12">12) UserNotFoundFilter ve IUserAccessor</h2>

<p>
  ASP.Net Core' da filterlar controllerın veya actionların çalışmasından önce ya da sonra çalışması gereken logicleri çalıştırmak için kullanılır. 
</p>

<p>
  Bu projede bir kullanıcının veritabanında var olup olmadığını test eden bir filter yazılmıştır. Bu filter eğer kullanıcı veritabanında yoksa hata fırlatacak aksi halde ise
  IUserAccessor' ın user özelliğini set edecektir.
</p>
<p>
  IUserAccessor, user deponlandığı nesnedir. UserNotFoundFilter ı kullanan her actiondan erişilebilir.
</p>



<img width="1505" height="450" alt="actionFilter" src="https://github.com/user-attachments/assets/86f66a39-6378-448b-bc55-3661bb966fb3" />

<img width="503" height="133" alt="IUserAccessor" src="https://github.com/user-attachments/assets/c59cf9f7-771a-479d-aca8-6d6fdb2785bb" />


<h2 id="id13">13) MaintenanceMiddleware</h2>

<p>
  MaintenanceMiddleware kullanıcıların hatalı istekleri saklar.
</p>

<img width="1422" height="598" alt="MaintanceMiddleware" src="https://github.com/user-attachments/assets/353c15e2-5ee2-4493-9550-6208638065df" />
