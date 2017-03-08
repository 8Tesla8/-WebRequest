namespace TransferEntites.ClientResponseEntities
{
    public class AllProgramsInDeviceToClient
    {
        public int CategoryId { set; get; }
        public string Path { set; get; }

        public string ProductName { get; set; }
        public string CompanyName { get; set; }
        public string ExeFileName { get; set; }
        public string ProcessName { get; set; }
        public string Description { get; set; }
    }
}
