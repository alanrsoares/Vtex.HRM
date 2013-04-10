namespace Pingdom.Client.Contracts.Checks
{
    using System.ComponentModel.DataAnnotations;

    public class ModifyMultipleChecksRequest
    {
        public bool Paused { get; set; }
        public int Resolution { get; set; }
        [Required]
        public int[] CheckIds { get; set; }
    }
}