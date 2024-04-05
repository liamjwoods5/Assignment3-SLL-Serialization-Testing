using Assignment3;
using System.Runtime.Serialization;

[DataContract]
public class Node
{
    [DataMember]
    public User Data { get; set; }

    [DataMember]
    public Node Next { get; set; }

    [DataMember]
    public User Value { get; internal set; }

    public Node(User data)
    {
        Data = data;
        this.Next = null;
    }
}

