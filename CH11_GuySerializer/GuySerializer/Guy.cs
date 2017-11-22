using System.Runtime.Serialization;

namespace GuySerializer
{
    [DataContract(Namespace = "HeadFirst_CSharp/CH11")]
    public class Guy
    {
        [DataMember]
        public string Name { get; private set; }

        [DataMember]
        public int Age { get; private set; }

        [DataMember]
        public decimal Cash { get; private set; }
    }
}