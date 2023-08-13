# _Eau Claire's Salon Client App_

#### By _Austin Papritz_

#### _This web application serves to organize Eau Claire's client and employee data!_

## Technologies Used

* _C#_
* _.NET_
* _JavaScript_
* _HTML/CSS_
* _MySQL_
* _Visual Studio Code_
* _Entity Framework Core_
* _JQuery_

## Description

_Eau Claire's Salon Client App is a web app that allows the user to see the list of clients for every stylist working at Eau Claire's Salon. Navigate to the correct form to add either a new stylist or to match a new client with a stylist._

## Project Setup

* _`Download ZIP` by clicking on the big green `Code` button._
* _Extract the ZIP to a designated location._
* _Open the `HairSalon.Solution` folder in your favorite code editor (e.g., VS Code, Xcode, Atom)._
* _Open the terminal, navigate to the project folder by entering `$ cd .\HairSalon\`_

## Database Setup

* _Search online to install MySQL on your computer. Remember your username and password._
* _Add `appsettings.json` file to project folder. Paste the following code, inserting your own information where {indicated}._

```json
{
    "ConnectionStrings": {
        "DefaultConnection": "Server=localhost;Port=3306;database={DATABASENAME};uid={USERNAME};pwd={PASSWORD};"
    }
}
```

* _Build project by entering `$ dotnet build`._
* _Complete database setup by entering `$ dotnet EF database update`._

## Run Web App

* _Enter `$ dotnet watch run` to run the web app._
* _Your browser should automatically open._
* _You may need to give yourself security certs by entering `$ dotnet dev-certs https --trust`._
* _There will be a confirmation pop-up in your browser, you might also need to click `Advanced` and then click to proceed to site_
* _Enjoy!_

## Known Bugs

* _/clients/edit routes are incomplete_
* _New Stylist form reloads incorrectly if filled out wrong the first time_

## License

_favicon downloaded from https://www.flaticon.com_

_This app is not licensed and is free to use and distribute._

_If you run in to any problems or have any suggestions, feel free to contact me on [linkedIn](https://www.linkedin.com/in/austin-papritz)!_
