Model View Controller (MVC) -> Ziel des Musters ist ein flexibler Programmentwurf, der eine spätere Änderung oder Erweiterung erleichtert und eine Wiederverwendbarkeit der einzelnen Komponenten ermöglicht. Es ist dann zum Beispiel möglich, eine Anwendung zu schreiben, die dasselbe Modell nutzt und es dann für Windows, Mac, Linux oder für das Internet zugänglich macht. Die Umsetzungen nutzen dasselbe Modell, nur Controller und View müssen dabei jeweils neu implementiert werden. 

.Contracts -> Specifications from the frontend.
Controller -> A Controller is a class that implements operations defined by an application's API
Services -> Service layer takes care of real business logic and make calls to the DAO layer to retrieve data needed for business logic calculation.
DAO -> stands for Data Access Object. DAO Design Pattern is used to separate the data persistence logic in a separate layer. This way, the service remains completely in dark about how the low-level operations to access the database is done. This is known as the principle of Separation of Logic.

Models -> 
Requests -> Requests scripts for testing. Use VS-Code Extension.