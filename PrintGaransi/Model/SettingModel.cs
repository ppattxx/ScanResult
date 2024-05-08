using System;

namespace PrintGaransi.Model
{
    public class SettingModel
    {
        public event EventHandler<string> SaveSettingsIP;
        public event EventHandler<int> SaveSettingsPort;

        public string LoadIP()
        {
            string ipaddress = Properties.Settings.Default.ServerIP;
            OnSettingsLoaded(ipaddress);
            return ipaddress;
        }

        public int LoadPort()
        {
            int port = Properties.Settings.Default.Port;
            OnSettingsLoaded(port.ToString());
            return port;
        }

        public void SaveSettingIP(string serverIP)
        {
            Properties.Settings.Default.ServerIP = serverIP;
            Properties.Settings.Default.Save();
            OnSettingsSaved(serverIP);
        }

        public void SaveSettingPort(int port)
        {
            Properties.Settings.Default.Port = port;
            Properties.Settings.Default.Save();
            OnSaveSettingsPort(port);
        }

        protected virtual void OnSettingsLoaded(string ip)
        {
            SaveSettingsIP?.Invoke(this, ip);
        }

        protected virtual void OnSettingsSaved(string ip)
        {
            SaveSettingsIP?.Invoke(this, ip);
        }

        protected virtual void OnSaveSettingsPort(int port)
        {
            SaveSettingsPort?.Invoke(this, port);
        }
    }
}
