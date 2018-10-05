using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Language.Models
{
    [MetadataType(typeof(HeaderMetaData))]
    public partial class Header { }

    [MetadataType(typeof(AboutMetaData))]
    public partial class About { }

    [MetadataType(typeof(ConversationMetaData))]
    public partial class Conversation { }

    [MetadataType(typeof(FoodMetaData))]
    public partial class Food { }

    [MetadataType(typeof(Food_CategoryMetaData))]
    public partial class Food_Category { }
}