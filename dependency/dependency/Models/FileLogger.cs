namespace dependency.Models
{
    public class FileLogger
    {
        public void printToFile(string msg)
        {
            System.IO.File.WriteAllText("",msg);
        }
    }
}
