namespace Khronos;

internal interface IGetProcAddressOS
{
	void AddLibraryDirectory(string libraryDirPath);

	nint GetProcAddress(string library, string function);
}
