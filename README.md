# asp-core-template
Simple ASP.NET Core template with repository pattern

## Add new entity
1. Create new model class (let's say "Nationality") with properties.
2. Add DbSet<Nationality> to AppDbContext
3. Run "Add-Migration AddedNationality" in NuGet Package Manager console
4. Migrations will apply on app start (MigrationService)

## Create repository
1. Create INatinalityRepository interface
2. Add NationalityRepository implementation
3. Register implementation in dependency injection container (Startup class)

## Scaffold controller
1. Right click on Controllers directory
2. Add -> Controller -> MVC controller with Views, using Entity FW
3. Swap dbContext references to INationalityRepository in NationalityController
4. Add link to Shared/layout view

## Mock repository in unit tests
1. Add new IUnitOfWork implementation, i.e FakeUnitOfWork, with dummy SaveChanges
1. Add new INationalityRepository implementation, i.e FakeNationalityRepository
2. Use IList<Nationality> instead of AppDbContext for persistence
3. Create controller object manually with FakeUnitOfWork and FakeNationalityRepository
