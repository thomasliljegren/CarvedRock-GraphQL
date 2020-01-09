namespace CarvedRock.Api.GraphQL.Messaging
{
    public class ReviewAddedMessage
    {
        public string Title { get; set; }
        public int ProductId { get; set; }
        public string Review { get; set; }

    }
}