using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Windows;
using Windows.ApplicationModel.DataTransfer;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.System;
using Windows.UI.Core;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace RFIDTest
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private string EPC = "";
        public MainPage()
        {
            this.InitializeComponent();
            Window.Current.CoreWindow.KeyDown += this.OnKeyDownListener;

            // read data from clipboard
            Clipboard.ContentChanged += async (s, e) => {
                DataPackageView dataPackageView = Clipboard.GetContent();
                if (dataPackageView.Contains(StandardDataFormats.Text)) {
                    string text = await dataPackageView.GetTextAsync();
                    Debug.WriteLine("==================");
                    Debug.WriteLine(text);
                }
            };
        }

        private void OnKeyDownListener(CoreWindow sender, KeyEventArgs args) {
            if (args.VirtualKey != VirtualKey.Enter && args.VirtualKey != VirtualKey.Shift) {
                this.EPC += this.GetKeybordChar(args.VirtualKey);
            }

            //Debug.WriteLine(this.EPC.Length);

            //Debug.WriteLine(this.EPC);
            var dataPackage = new DataPackage();
            dataPackage.SetText(this.EPC);
            if (this.EPC.Length == 24) {
                Windows.ApplicationModel.DataTransfer.Clipboard.SetContent(dataPackage);
                this.EPC = "";
            }
        }

        private string GetKeybordChar(VirtualKey key) {
            switch (key) {
                case VirtualKey.Number0:
                    return "0";
                case VirtualKey.Number1:
                    return "1";
                case VirtualKey.Number2:
                    return "2";
                case VirtualKey.Number3:
                    return "3";
                case VirtualKey.Number4:
                    return "4";
                case VirtualKey.Number5:
                    return "5";
                case VirtualKey.Number6:
                    return "6";
                case VirtualKey.Number7:
                    return "7";
                case VirtualKey.Number8:
                    return "8";
                case VirtualKey.Number9:
                    return "9";
                case VirtualKey.A:
                    return "A";
                case VirtualKey.B:
                    return "B";
                case VirtualKey.C:
                    return "C";
                case VirtualKey.D:
                    return "D";
                case VirtualKey.E:
                    return "E";
                case VirtualKey.F:
                    return "F";
                default:
                    return "";
            }
        }
    }
}
