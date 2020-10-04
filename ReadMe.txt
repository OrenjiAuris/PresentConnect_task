Techninė užduotis Aurimas Šernas

Užduoties testavimo gidas:
1. Paleisti PVM.Api projekta naudojant IIS Express
2. Per pasirinktą naršyklę atsivers tuščias langas(nebuvo pateikti paieškos kriterijai, dėl to nerasta jokių rezultatų).
3. Per browserį arba kitą programą(pvz. Postman) nusiųsti GET užklausa šiuo pavyzdiniu adresu: 
   https://localhost:44307/vat/invoice?customerName=Tom%20Cruise&serviceProviderName=Amazon%20DE&services=Prime&services=Prime%20Video
4. Klientų ir paslaugų tiekėjų informacija galima rasti aplanke PVM.Api/DataStores
5. Pakeitus kintamųjų reikįmes galima gauti skirtingus rezultatus(pavyzdiniu atvėju, PVM yra 19%)

Papildomi atvėjai:
https://localhost:44307/vat/invoice?customerName=John%20Jonny&serviceProviderName=Amazon%20DE&services=Prime&services=Prime%20Video klientas nepriklauso EU
https://localhost:44307/vat/invoice?customerName=That%20Jonny&serviceProviderName=Amazon%20DE&services=Prime&services=Prime%20Video klientas nėra PVm mokėtojas ir gyvena kitoje šalyje negu paslaugų tiekėjas
https://localhost:44307/vat/invoice?customerName=Flip%20Conner&serviceProviderName=Amazon%20DE&services=Prime&services=Prime%20Video klientas PVM mokėtojas ir gyvena skirtingoje šalyje negu paslaugų tiekėjas
https://localhost:44307/vat/invoice?customerName=Flip%20Conner&serviceProviderName=Amazon%20LT&services=Prime&services=Prime%20Video klientas ir paslaugų tiekėjas iš tos pačios šalies
https://localhost:44307/vat/invoice?customerName=Beef%20Jerky&serviceProviderName=Air&services=Fast%20Internet paslaugų tiekėjas nėra PVM mokėtojas

P.S.
Jeigu testuotojas naudoja Postman, Items aplanke yra pridėtas Postman Collection failas.
Jeigu užklausos nėra randamos, gali būti, kad yra nurodyti neteisingi portai.