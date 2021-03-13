using System;
using System.Collections.Generic;
using System.Text;

namespace CCXModels.domain.UserModels
{

    // NOTE: Generated code may require at least .NET Framework 4.5 or .NET Core/Standard 2.0.
    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
    public partial class ReasonCodes
    {
        private ReasonCodesReasonCode[] reasonCodeField;
        private string categoryField;
        [System.Xml.Serialization.XmlElementAttribute("ReasonCode")]
        public ReasonCodesReasonCode[] ReasonCode
        {
            get
            {
                return this.reasonCodeField;
            }
            set
            {
                this.reasonCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }
    }

    /// <remarks/>
    [System.SerializableAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
    public partial class ReasonCodesReasonCode
    {
        public string uri { get; set; }
        public string category { get; set; }
        public int code { get; set; }
        public string label { get; set; }
        public bool forAll { get; set; }
        public bool systemCode { get; set; }
    }
}
