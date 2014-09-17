# Testing Practices

A sample .net c# solution that highlights two different concepts. 

- First it shows examples of Mockist and Classical style testing. 
- Second it has two implementations of the data layer. One for EntityFramework and one for NHibernate.

### Setup

- Project Created in VS2013 & SQL 2008 R2.
- Create Databases: TestingFrameworkEFDBTestDB & TestingFrameworkNHDBTestDB.
- Update the app.config of the two test projects to point to your databases (EF: ForTestsEntityFrameworkConnection, NH: DefaultConnection).

### Test Coupling

Amount of change needed in tests to refactor/change the codebase.

- Classical tests: Low
- Mockist tests: High

Example of coupling highlighted from refactoring:

- [Classical](https://github.com/joeyshipley/TestingPractices/commit/afbc789015f13312b20c1ad7d58582da4963d066#diff-31)
- [Mockist](https://github.com/joeyshipley/TestingPractices/commit/afbc789015f13312b20c1ad7d58582da4963d066#diff-32)

### Test Performance

Duration of the tests per resharper feedback. These only pertain to the ExampleInteractor tests. 

- (~0.2 seconds) Mockist / NH
- (~0.3 seconds) Mockist / EF
- (~0.4 seconds) Classical / NH / TestDb
- (~1.1 seconds) Classical / NH / InMemoryDb
- (~7.5 seconds) Classical / EF / TestDb

### Stack - EntityFramework

- ORM: EntityFramework
- IoC: Unity
- Test Helper: Moq
- Test Helper: AutoMoq
- Test Helper: Fluent Assertions

### Stack - NHibernate

- ORM: NHibernate
- ORM: NH Fluent Mappings
- IoC: StructureMap
- Test Helper: NSubstitute
- Test Helper: NSubstituteAutoMocker
- Test Helper: SQLite (InMemory NH)
- Test Helper: Fluent Assertions

### NOTES

- EF/NH handles Enums differently in the DB.
- EF/NH handles the BaseEntity differently in the DB.

### TODO

- Look into NHibernate auto mapping
