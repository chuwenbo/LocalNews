using LocalNews.Service.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalNews.Service.EntityBuilder
{
    public class LocalNews_Content_Builder
    {
        public static void Build(EntityTypeBuilder<LocalNews_Content> _localNews_Content_Builder)
        {
            _localNews_Content_Builder.HasKey(t => t.ID);
            _localNews_Content_Builder.Property(t => t.Title).HasMaxLength(500); 
        }
    }
}
