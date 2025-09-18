using System.Data;
using OopExamples.Interfaces;

namespace OopExamples.Implementations;

public class Computer : IComputer
{
    public IEntity Owner { get; init; }
    public IMotherBoard MotherBoard { get; init; }
    public ICPU Cpu { get; init; }
    public IGPU Gpu { get; init; }
    public IRAM Ram { get; init; }
    public IPowerSupply PowerSupply { get; init; }
    public ICase Case { get; init; }
    public IMonitor[] Monitors { get; init; }
    public bool IsOn { get; set; }
    public bool IsPersonalPC { get; }
    public bool IsCompanyPC { get; }
    public void PowerUp()
    {
        IsOn = true;
    }

    public void ShutDown()
    {
        IsOn = false;
    }

    public void PressPowerButton()
    {
        if (IsOn)
        {
            IsOn = false;
        }
        else
        {
            IsOn = true;
        }
    }

    public void Print(string text)
    {
        Console.WriteLine(text);
    }

    public float Compute(string equation)
    {
        try
        {
            var table = new DataTable();
            var result = table.Compute(equation, string.Empty);
            return (float)Convert.ToDouble(result.ToString());
        }
        catch (Exception ex)
        {
            throw new ArgumentException("Invalid equation format.", ex);
        }
    }

    public IComputer BuildNewComputer(IComputerConfiguration configuration)
    {
        Computer computer = new Computer();
        return computer;
    }
}