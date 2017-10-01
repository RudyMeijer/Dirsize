using System;
using System.Runtime.InteropServices;
[ StructLayout( LayoutKind.Sequential, CharSet=CharSet.Auto )]
public class FileData 
{
	public int  Attributes = 0;
	public int  creationTime_lowDateTime = 0 ;
	public int  creationTime_highDateTime = 0;
	public int  lastAccessTime_lowDateTime = 0;
	public int  lastAccessTime_highDateTime = 0;
	public int  lastWriteTime_lowDateTime = 0;
	public int  lastWriteTime_highDateTime = 0;
	public int  nFileSizeHigh = 0; 
	public uint Size = 0; // V107
	public int  dwReserved0 = 0;
	public int  dwReserved1 = 0;
	[ MarshalAs( UnmanagedType.ByValTStr, SizeConst=256 )]
	public String  Name = null;
	[ MarshalAs( UnmanagedType.ByValTStr, SizeConst=14 )]
	public String  alternateFileName = null;
}
public class W32api
{
	// Declare managed prototype for the unmanaged function.
	[DllImport( "Kernel32.dll", CharSet=CharSet.Auto )]
	public static extern IntPtr FindFirstFile( String fileName, [ In, Out ] FileData findFileData );
	[DllImport( "Kernel32.dll", CharSet=CharSet.Auto )]
	public static extern bool FindNextFile( IntPtr handle, [ In, Out ] FileData findFileData );
	[DllImport( "Kernel32.dll", CharSet=CharSet.Auto )]
	public static extern bool FindClose( IntPtr handle);
}
public class Folder
{
	public long Size(string path)
	{
		FileData file = new FileData();
		bool success=true;
		long totalSize=0;
		const int DIR_ATTRIB = 0x10;
		IntPtr handle = W32api.FindFirstFile( path+"\\*.*",file );
		while (success)
		{
			if (!file.Name.StartsWith (".")) 
			{
				totalSize += ((file.Attributes & DIR_ATTRIB )==DIR_ATTRIB ?
					Size(path + "\\"+file.Name ):file.Size+file.nFileSizeHigh*uint.MaxValue); //V108
			}
			success = W32api.FindNextFile (handle ,file );
		}
		success = W32api.FindClose (handle );
		return totalSize;
	}
///	public static void Main(string[] args)
//	{
//		DirSize d = new DirSize ();
//		if (args.Length ==0) { Console.WriteLine ("DirSize <path>"); return;}
//		string path = args[0];
//		Console.WriteLine ("Computing size of {0}",path);
//		long start = Environment.TickCount ;
//		long size = d.getFolderSize(path);
//		long eind = Environment.TickCount;
//		Console.WriteLine ("Total used space on {0} is: {1:#,#} time: {2}",path,size,eind-start );
//		Console.ReadLine ();
///	}
}

