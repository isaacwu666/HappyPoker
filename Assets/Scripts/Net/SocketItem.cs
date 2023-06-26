 
public class SocketItem
{
    
    /// <summary>
    /// 操作码
    /// </summary>
    public int OpCode { get; set; }

    /// <summary>
    /// 子操作
    /// </summary>
    public int SubCode { get; set; }

    /// <summary>
    /// 参数
    /// </summary>
    public object Value { get; set; }

    public SocketItem()
    {
    }

    public SocketItem(int OpCode)
    {
 
        this.OpCode = OpCode;
    }
    public SocketItem(int OpCode,int SubCode)
    {
        this.OpCode = OpCode;
        this.SubCode = SubCode;
    }

    public SocketItem(int opCode, int subCode, object value)
    {
        this.OpCode = opCode;
        this.SubCode = subCode;
        this.Value = value;
    }
}