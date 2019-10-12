namespace OneBuck.Models.ENT
{
    public class ENTMessageResult : AbstractResp
    {
        public string InvalidUser { get; set; }

        public string InvalidParty { get; set; }

        public string InvalidTag { get; set; }
    }
}