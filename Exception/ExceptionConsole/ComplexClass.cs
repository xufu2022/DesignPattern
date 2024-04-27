using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExceptionConsole
{
    public class ComplexClass
    {
        public void TopLevelMethod()
        {
            try
            {
                Level1Method();
            }
            catch (Exception ex)
            {
                // Handle exception or log
                Console.WriteLine($"Exception caught at the top level: {ex.Message}");
                // Perform any class-specific recovery or cleanup
            }
        }

        private void Level1Method()
        {
            // No try-catch here, let exceptions bubble up
            Level2Method();
        }

        private void Level2Method()
        {
            // No try-catch here, let exceptions bubble up
            Level3Method();
        }

        private void Level3Method()
        {
            // Operation that might throw an exception
            throw new Exception("An error occurred at the deepest level.");
        }
    }

}
