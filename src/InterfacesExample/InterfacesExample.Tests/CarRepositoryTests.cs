namespace InterfacesExample.Tests;

public class CarRepositoryTests
{
    [Fact]
    public void InsertingNewModel_ShouldIncreaseRecordCount()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
        int recordBefore = carRepo.RecordCount();

        // Act
        carRepo.Insert(new CarModel("name", "brand"));
        int recordAfter = carRepo.RecordCount();

        // Asset
        Assert.True(recordAfter > recordBefore);
        Assert.NotEqual(recordAfter, recordBefore);

    }

    [Fact]
    public void InsertingNull_ShouldSustainRecordCount()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
        int recordBefore = carRepo.RecordCount();

        // Act
        carRepo.Insert(null);
        int recordAfter = carRepo.RecordCount();

        // Asset
        Assert.Equal(recordAfter, recordBefore);
    }

    [Fact]
    public void GettingAllRecords_WithTwoRecords_ShouldReturnListOfTwoRecords()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
        List<CarModel> carsList = new List<CarModel>();
        int numberOfRecords = 2;

        carRepo.Insert(new CarModel("name", "brand"));
        carRepo.Insert(new CarModel("name2", "brand2"));

        // Act
        List<CarModel> carModels = carRepo.Get();

        // Asset
        Assert.True(carModels.Count == numberOfRecords);
        Assert.Equal(carModels.Count, numberOfRecords);

    }

    [Fact]
    public void GettingInsertedRecordWithId_WithTwoRecords_ShouldReturnInsertedRecord()
    {
        // Arrange
        int numberOfRecords = 2;
        IRespository<CarModel> carRepo = new CarRepository();
        List<CarModel> numOfInsertedRecords = new List<CarModel>();

        for (int i = 0; i < numberOfRecords; i++)
        {
            CarModel car = new CarModel($"name {i}", $"brand {i}");
            carRepo.Insert(car);
            numOfInsertedRecords.Add(car);
        }
        List<CarModel> modelRecordsFromRepo = carRepo.Get();
                    
        // Act
        CarModel firstModelGotById = carRepo.Get(numOfInsertedRecords[0].Id);
        CarModel secondModelGotById = carRepo.Get(numOfInsertedRecords[1].Id);

        // Assert
        Assert.NotNull(firstModelGotById);
        Assert.NotNull(secondModelGotById);

        Assert.Equal(firstModelGotById, numOfInsertedRecords[0]);
        Assert.Equal(secondModelGotById, numOfInsertedRecords[1]);
        
    }

    [Fact]
    public void GettingNotInsertedRecordWithId_WithTwoRecords_ShouldReturnNull()
    {
        // Arrange
        IRespository<CarModel> carRepo = new CarRepository();
                    
        // Act
        CarModel firstModelGotById = carRepo.Get(new Guid());
        CarModel secondModelGotById = carRepo.Get(new Guid());

        // Assert
        Assert.Null(firstModelGotById);
        Assert.Null(secondModelGotById);

    }
}