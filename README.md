
<h1 align="center">
  
  <br />
  Template base for WPF App
</h1>

<h3 align="center">With repository pattern</h3>

<div align="center">
  
 

</div>


# Template base for WPF App
Template base for WPF project with repository pattern.

## Features

* Logger
    * Serilog logger setup and ready to use.

* SQLITE
    * A lightweith database setup and ready to use.

* Repository Pattern
    * All structure to use repository pattern setup.



## Add new domain to use (use the Client template to see the models)

1. Add new Domain to use in Domain/Entities. Don't forget to use the interface IIdentityEntity in the Class.

2. Add new Interface for the repository in DatabaseManager.Interface/Repositories/Domain/.

3. Add the repository to DatabaseManager/Repositories/Domain/SQLite/.

4. Add new Interface service in Core.Interface/Service/Domain.

5. Add Service in Core/Service/Domain


## Set dependency injection

1. In MainDesktop/Bootstrapper.cs, as the template add to container the service and the repository instances. 

## Create Table

1. To Create a new Table, pass service into the constructor for the Model View and call the service.CreateTable();

2. Now you can use all the functions in the service to acess the database data.


## Autor

* **Luiz Carlos Gili*



