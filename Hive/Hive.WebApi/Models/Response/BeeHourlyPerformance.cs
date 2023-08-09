namespace Hive.Models.Response
{
    /// <summary>
    /// Model of a bee hurly performance response.
    /// </summary>
    public class BeeHourlyPerformance
    {
        /// <summary>
        /// Id of the bee.
        /// </summary>
        public int Id { get; set; }
        /// <summary>
        /// Name of the bee.
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// Hourly performance of the bee.
        /// </summary>
        public decimal HourlyPollen { get; set; }
    }
}