**TÜRKÇE**

**Gerekli Yazılımlar**
```
.NET
SSMS
```
> [!IMPORTANT]
> SQL Server Management Studio'da bağlandığınız sunucu adını proje dosyalarında belirtilen yerlere eklemeniz gerekmektedir. Eğer test etmek isterseniz SSMS'de local sunucuya bağlanın '(localdb)\MSSQLLocalDB', local sunucuya bağlanırsanız kodlarda bir değişiklik yapmanıza gerek kalmaz.

Local sunucuya bağlanmak **istemezseniz** (SSMS'de) bağlandığınız sunucu adını kopyalayın ve belirtilen yerlerdeki kod ile değiştirin:
1. `ReminderApp.Api` klasörünün içindeki `appsettings.json` dosyasında 22. satırdaki kodu değiştirmelisizin. Çift ters `\\` olmalı: Server=(localdb)\\MSSQLLocalDB; =>Server=YourServerName;
2. `ReminderApp.Persistence` klasörünün içindeki `DesignTimeContext.cs` dosyasındaki kodu da aynı şekilde değiştirmelisiniz.

Daha sonra terminalde sırasıyla şu kodları yazın:
- cd .\src\ 
- cd .\ReminderApp.Persistence\
- dotnet ef migrations add exampleName
- dotnet ef database update
- cd ..
- cd .\ReminderApp.Api\
- dotnet run

Daha sonra Swagger üzerinden test işlemlerini gerçekleştirebilirsin.
http://localhost:5206/swagger/index.html



**ENGLISH**

**Required Software**
``` 
.NET
SSMS
```
> [!IMPORTANT]
> In SQL Server Management Studio you need to add the name of the server you are connecting to in the specified places in the project files. If you want to test it, connect to the local server in SSMS '(localdb)\MSSQLLocalDB', if you connect to the local server you don't need to make any changes in the code.

If you **don't want to** connect to the local server (in SSMS) copy the server name and replace it with the code where indicated:
1. In the `appsettings.json` file in the `ReminderApp.Api` folder, change the code on line 22. It should be double inverted `\\`: Server=(localdb)\\MSSQLLocalDB; =>Server=YourServerName;
2. You should also change the code in `DesignTimeContext.cs` file in `ReminderApp.Persistence` folder in the same way.

Then type the following codes in the terminal:
- cd .\src\ 
- cd .\ReminderApp.Persistence\
- dotnet ef migrations add exampleName
- dotnet ef database update
- cd ...
- cd .\ReminderApp.Api\
- dotnet run

You can then run tests on Swagger.
http://localhost:5206/swagger/index.html




