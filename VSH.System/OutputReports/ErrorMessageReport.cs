namespace VHS.System.OutputReports
{
    public class ErrorMessageReport : OutputReport
    {
        private string message;

        public ErrorMessageReport(string message)
        {
            this.message = message;
        }

        public override string Get()
        {
            return message;
        }
    }
}