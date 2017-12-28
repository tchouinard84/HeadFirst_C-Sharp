using System.ComponentModel;
using System.IO;
using System.Runtime.Serialization;

namespace GuySerializer
{
    public class GuyManager : INotifyPropertyChanged
    {
        public Guy Joe { get; } = new Guy("Joe", 37, 176.22M);
        public Guy Bob { get; } = new Guy("Bob", 45, 4.68M);
        public Guy Ed { get; } = new Guy("Ed", 43, 37.51M);

        public Guy NewGuy { get; set; }

        public string GuyFile { get; set; }
        public void ReadGuy(string fileName)
        {
            using (Stream inputStream = File.OpenRead(fileName))
            {
                var serializer = new DataContractSerializer(typeof(Guy));
                NewGuy = serializer.ReadObject(inputStream) as Guy;
            }

            OnPropertyChanged("NewGuy");
        }

        public void WriteGuy(Guy guyToWrite, string filePath)
        {
            GuyFile = filePath;

            if (File.Exists(GuyFile)) { File.Delete(GuyFile); }

            using (Stream outputStream = File.OpenWrite(GuyFile))
            {
                var serializer = new DataContractSerializer(typeof(Guy));
                serializer.WriteObject(outputStream, guyToWrite);
            }

            OnPropertyChanged("GuyFile");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
