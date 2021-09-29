using LocalNews.Service.Entity;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Text;

namespace LocalNews.Service.EntityBuilder
{
    public class LocalNews_Main_Builder
    {
        public static void Build(EntityTypeBuilder<LocalNews_Main> _localNews_Main_Builder)
        {
            _localNews_Main_Builder.HasKey(t => t.ID);
            _localNews_Main_Builder.Property(t => t.Title).HasMaxLength(500);
            _localNews_Main_Builder.Property(t => t.URL).HasMaxLength(500);
        }
    }
}
