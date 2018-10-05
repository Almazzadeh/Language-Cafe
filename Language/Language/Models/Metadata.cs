using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel;

namespace Language.Models
{
    #region HEADER METADATA
    public class HeaderMetaData
    {
        //public int Id { get; set; }

        [DisplayName("Brand Before Text")]
        [StringLength(50, ErrorMessage = "Before text can not be more than 50.")]
        public string Before_Brand { get; set; }

        [DisplayName("Brand Name")]
        [Required(ErrorMessage = "Brand Name should be filled.")]
        [StringLength(50, ErrorMessage = "Brand name can not be more than 50.")]
        public string Brand_Name { get; set; }

        [DisplayName("Brand After Text")]
        [StringLength(50, ErrorMessage = "After text can not be more than 50.")]
        public string After_Brand { get; set; }

        [DisplayName("Background Image")]
        [StringLength(255, ErrorMessage = "Background image name is too big, please rename.")]
        public string Background_Image { get; set; }
    }
    #endregion

    #region ABOUT METADATA
    public class AboutMetaData
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Header should be filled.")]
        [StringLength(50, ErrorMessage = "Header can not be more than 50.")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Content should be filled.")]
        [StringLength(1000, ErrorMessage = "Header can not be more than 1000.")]
        public string Content { get; set; }

        [DisplayName("Top Left Photo")]
        [StringLength(255, ErrorMessage = "Picture name is too big, please rename.")]
        public string Top_Left_Photo { get; set; }

        [DisplayName("Bottom Left Photo")]
        [StringLength(255, ErrorMessage = "Picture name is too big, please rename.")]
        public string Bottom_Left_Photo { get; set; }

        [DisplayName("Right Photo")]
        [StringLength(255, ErrorMessage = "Picture name is too big, please rename.")]
        public string Right_Photo { get; set; }
    }
    #endregion

    #region CONVERSATION METADATA
    public class ConversationMetaData
    {
        //public int Id { get; set; }

        [Required(ErrorMessage = "Header should be filled.")]
        [StringLength(50, ErrorMessage = "Header can not be more than 50.")]
        public string Header { get; set; }

        [Required(ErrorMessage = "Header should be filled.")]
        [StringLength(100, ErrorMessage = "Content can not be more than 100.")]
        public string Content { get; set; }

        [StringLength(255, ErrorMessage = "Image name is too big, please rename.")]
        public string Image { get; set; }
    }
    #endregion

    #region FOOD METADATA
    public class FoodMetaData {
        //public int Id { get; set; }
        [Required(ErrorMessage = "Name should be filled.")]
        [StringLength(50, ErrorMessage = "Name can not be more than 50.")]
        public string Name { get; set; }

        [StringLength(255, ErrorMessage = "Image name is too big, please rename.")]
        public string Image { get; set; }

        [Required(ErrorMessage = "Price should be filled.")]
        //[RegularExpression(@"^\d+\.\d{0,2}$")]
        [Range(0, 9999999999999999.99)]
        public Nullable<decimal> Price { get; set; }

        [DisplayName("Category")]
        public Nullable<int> Category_Id { get; set; }

        public virtual Food_Category Food_Category { get; set; }
    }
    #endregion

    #region FOOD CATEGORY METADATA
    public class Food_CategoryMetaData
    {
        //public int Id { get; set; }
        public string Name { get; set; }
        public string Image { get; set; }
    }
    #endregion
}