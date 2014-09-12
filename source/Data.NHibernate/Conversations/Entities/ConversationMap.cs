using Application.Example.Entity;
using FluentNHibernate.Mapping;

namespace Data.NHibernate.Conversations.Entities
{
    public class ConversationMap : ClassMap<Conversation>
    {
        public ConversationMap()
        {
            Id(x => x.Id)
                .Column("Id")
                .GeneratedBy.GuidComb();
            Map(x => x.Source)
                .Not.Nullable();
            Map(x => x.Message)
                .Length(200)
                .Not.Nullable();
            Map(x => x.CreatedOn)
                .Not.Nullable();
            Map(x => x.UpdatedOn)
                .Not.Nullable();
        }
    }
}