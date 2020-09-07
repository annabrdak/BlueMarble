using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace BlueMarble.MarkupExtensions
{    
    [ContentProperty("ResourceId")]
    public class EmbeddedImage : IMarkupExtension
    {
        public string ResourceId { get; set; }


        public object ProvideValue(IServiceProvider serviceProvider)
        {
            if (String.IsNullOrWhiteSpace(ResourceId))
                return null;                      

            return ImageSource.FromResource(ResourceId);
            //return ImageSource.FromResource("BlueMarble.Images.background.jpg");
        }
    }
}
