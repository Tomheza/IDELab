namespace IDELab
{
    public static class Extensions
    {
        public static bool ValidResult(this int result)
        {
            return result > 0 && result < 11;
        }
    }
}