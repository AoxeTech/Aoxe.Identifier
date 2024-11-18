namespace Aoxe.Ulid.TestProject
{
    public class UlidGeneratorTest
    {
        [Fact]
        public void NewUlid_ShouldHaveCorrectLength()
        {
            // Arrange
            const int expectedLength = 26;

            // Act
            var ulid = UlidGenerator.NewUlid();

            // Assert
            Assert.Equal(expectedLength, ulid.Length);
        }

        [Fact]
        public void NewUlid_ShouldGenerateUniqueUlids()
        {
            // Arrange
            const int quantity = 1000;
            var ulids = new string[quantity];

            // Act
            for (int i = 0; i < quantity; i++)
            {
                ulids[i] = UlidGenerator.NewUlid();
            }

            // Assert
            Assert.Equal(quantity, ulids.Distinct().Count());
        }

        [Fact]
        public void NewUlid_ShouldContainOnlyValidCharacters()
        {
            // Arrange
            const string validChars = "0123456789ABCDEFGHJKMNPQRSTVWXYZ";
            var ulid = UlidGenerator.NewUlid();

            // Act & Assert
            foreach (var ch in ulid)
            {
                Assert.Contains(ch, validChars);
            }
        }
    }
}