## WeNotify .Net Service

##### Notification Service with multiple features



This project developed in ASP.NET is the product of which we can obtain a complete service of management and sending notifications through channels and labels, which allows a third party to send raw data or the standard structure of notifications so that they are attended by handlers or broadcast to several clients in real time that are subscribed to a channel



##### Scalable and reliable

This service is developed in .Net and involves the best practices and technologies that the ecosystem of this solid Stack offers, we are talking about SignalR for real time support, ASP.NET for mounting the server and http protocol, relational databases, Clean Code for project customization with another group of good practices for third-party collaboration.



##### Easy to install

You just have to clone the project and install its dependencies with Nuget, once this is done, you will only have to go to the typical appsetting.json of each project with ASP.NET, and set its parameters for the connection string and other topics explained later.

```bash
mkdir we-notify
cd we-notify
git clone https://github.com/oliver021/we-notify.git .
cd WeNotify.HttpService
dotnet run
```

With these commands we will have already started our service, the dependencies should be installed automatically.

