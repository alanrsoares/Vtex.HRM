using System.ComponentModel.DataAnnotations;

namespace Vtex.HRM.WebApi.Contracts.Checks
{
    public class ModifyMultipleChecksRequest
    {
        public bool Paused { get; set; }
        public int Resolution { get; set; }
        [Required]
        public int[] CheckIds { get; set; }
    }
}