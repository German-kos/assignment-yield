using System.Collections;
//
Agency a1 = new Agency();
a1.Cars = new Car[]{
    new Car(){ ModelYear = 2001 , Maker = "Subaro"},
    new Car(){ ModelYear = 2021 , Maker = "Toyota"},
    new Car(){ ModelYear = 2013 , Maker = "Subaro"},
    new Car(){ ModelYear = 2004 , Maker = "Fiat"},
    new Car(){ ModelYear = 2021 , Maker = "Fiat"},
    new Car(){ ModelYear = 2015 , Maker = "Subaro"}
};
//
System.Console.WriteLine("All cars in the agency:");
foreach (var car in a1)
    System.Console.WriteLine(car);
System.Console.WriteLine("All cars in the agency from 2021:");
foreach (var car in a1.GetCars(2021))
    System.Console.WriteLine(car);
System.Console.WriteLine("All cars in the agency of Fiat:");
foreach (var car in a1.GetCars("Fiat"))
    System.Console.WriteLine(car);

class Agency
{
    public IEnumerable<Car> Cars { get; set; }

    public IEnumerator GetEnumerator()
    {
        foreach (var car in Cars)
        {
            yield return $"{car.ModelYear}, {car.Maker}";
        }
    }
    public IEnumerable GetCars(dynamic x)
    {
        foreach (var car in Cars)
        {
            if (x.GetType() == car.ModelYear.GetType() && car.ModelYear == x)
                yield return $"{car.ModelYear}, {car.Maker}";
            if (x.GetType() == car.Maker.GetType() && car.Maker == x)
                yield return $"{car.ModelYear}, {car.Maker}";
        }
    }
}
class Car
{
    public int ModelYear { get; set; }
    public string Maker { get; set; }
}