using BLECode;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MonitorBLE
{
    class Program
    {
        public static BluetoothLECode bluetooth;
      public static string BluetoothLE = "";

        static void Main(string[] args)
        {
            BluetoothLE = ConfigurationManager.AppSettings["BluetoothLE"];
            string _serviceGuid = "0000ffe0-0000-1000-8000-00805f9b34fb";//蓝牙服务的uuid;
            string _writeCharacteristicGuid = "0000ffe1-0000-1000-8000-00805f9b34fb";//蓝牙写的uuid;
            string _notifyCharacteristicGuid = "0000ffe1-0000-1000-8000-00805f9b34fb";//蓝牙读的uuid;

            BluetoothLECode bluetooth = new BluetoothLECode(_serviceGuid, _writeCharacteristicGuid, _notifyCharacteristicGuid);
            //bluetooth.ValueChanged += Bluetooth_ValueChanged;
        }

        private void Bluetooth_ValueChanged(MsgType type, string str, byte[] data)
        {
            Console.WriteLine(str);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bluetooth.StartBleDeviceWatcher();
        }

        private async void OnBLEAdded()
        {
            await bluetooth.SelectDeviceFromIdAsync("a8:e2:c1:63:46:de");//蓝牙设备MAC地址
        }
    }
}
