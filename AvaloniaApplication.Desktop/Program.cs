using Avalonia;
using Avalonia.Platform; 
using Avalonia.Skia;
using System;
using System.Reflection.PortableExecutable;

namespace AvaloniaApplication.Desktop
{
    internal class Program
    {
        [STAThread]
        public static void Main(string[] args)
        {
            BuildAvaloniaApp().StartWithClassicDesktopLifetime(args);
        }

        private static AppBuilder BuildAvaloniaApp()
        {
            return AppBuilder.Configure<App>()
                .UseSkia()
                .UsePlatformDetect()
                .WithInterFont()
                .LogToTrace();
        }
    }
}