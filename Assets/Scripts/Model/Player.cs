namespace Model
{
    //用户信息
    public class Player
    {
        public int id { get; set; }
        public string phone { get; set; }
        public string pwd { get; set; }
        public string salt { get; set; }
        public string nickName { get; set; }
        public string token { get; set; }
    }
};
 