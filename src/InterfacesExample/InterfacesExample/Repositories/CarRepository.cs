namespace InterfacesExample;

public class CarRepository : IRespository<CarModel>
{
    private readonly List<CarModel> _models = new List<CarModel>();

    public CarModel? Get(Guid Id)
    {
        foreach (var car in _models)
        {
            if (car.Id == Id) return car;
        }
        return null;
    }
    public List<CarModel> Get()
    {
        return _models;
    }

    public void Insert(CarModel model)
    {
        if (model == null) return;
        _models.Add(model);
    }

    public void Update(CarModel model)
    {
        throw new NotImplementedException();
    }

    public void Delete(Guid Id)
    {
        throw new NotImplementedException();
    }

    public int RecordCount()
    {
        return _models.Count;
    }
}