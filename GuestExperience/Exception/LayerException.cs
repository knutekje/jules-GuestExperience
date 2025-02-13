using System;
using System.Diagnostics;
using System.Reflection;

namespace GuestExperience.Exception;

public class LayerException : System.Exception
{
    public string MethodName { get; }
    public string ClassName { get; }

    public LayerException(string message) : base(message)
    {
        
        var stackTrace = new StackTrace();
        var frame = stackTrace.GetFrame(1);
        var method = frame?.GetMethod();

        
        MethodName = method?.Name ?? "Unknown Method";
        ClassName = method?.DeclaringType?.Name ?? "Unknown Class";
    }

    public override string ToString()
    {
        return $"[Exception in {ClassName}.{MethodName}]: {Message}";
    }
}

public class RepositoryException : LayerException
{
    public RepositoryException(string message) : base(message) { }
}

public class ServiceException : LayerException
{
    public ServiceException(string message) : base(message) { }
}

public class ControllerException : LayerException
{
    public ControllerException(string message) : base(message) { }
}