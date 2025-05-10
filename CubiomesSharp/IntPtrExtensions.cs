using System.Runtime.InteropServices.Marshalling;

namespace CubiomesSharp;

public static class IntPtrExtensions
{
    public static unsafe string? ToUtf8String(this IntPtr ptr)
    {
        return Utf8StringMarshaller.ConvertToManaged((byte*)ptr.ToPointer());
    }
}