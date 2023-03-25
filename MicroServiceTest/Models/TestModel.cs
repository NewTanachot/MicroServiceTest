using MicroServiceTest.Interfaces;
using System.ComponentModel.DataAnnotations;

namespace MicroServiceTest.Models
{
    public class TestModel : ITestModel
    {
        private string? creditCard;

        public string? CreditCard { 
            get 
            {
                return $"xxxx-xxxx-{creditCard?[^4..]}";
            }
            set 
            { 
                creditCard = value;
            } 
        }
    }
}
