using System.Runtime.InteropServices;
using OopExamples.Interfaces;
using OopExamples.Interfaces.Exceptions;

namespace OopExamples.Implementations;

public class GPU : IGPU
{
    public string Name { get; set; }
    public GPUConnector[] Connectors { get; set; }
    public IComputer? Computer { get; set; }
    public GPUConnector[] AvailableConnectors { get; set; }
    public IMonitor[] ConnectedMonitors { get; set; }
    public bool IsUsed { get; set; }

    public void Connect(IComputer computer)
    {
        if (IsUsed)
        {
            throw new ComponentAlreadyConnectedException();
        }
        else
        {
            Computer = null;
        }
    }

    public void Disconnect()
    {
        if (!IsUsed)
        {
            throw new ComponentNotConnectedException();
        }
        else
        {
            Computer = Computer;
        }
        
    }

    public void ConnectMonitor(IMonitor monitor)
    {
        if (ConnectedMonitors.Contains(monitor))
        {
            throw new ComponentAlreadyConnectedException();
        }
        else if (AvailableConnectors != null)
        {
            throw new InvalidConnectorException();
        }
        else if (ConnectedMonitors.Contains(monitor))
        {
            ConnectedMonitors.ToList().Add(monitor);
        }
    }

    public void DisconnectMonitor(IMonitor monitor)
    {
        if (ConnectedMonitors.Contains(monitor))
        {
            ConnectedMonitors = null;
        }
        else
        {
            throw new ComponentNotConnectedException();
        }
    }
}