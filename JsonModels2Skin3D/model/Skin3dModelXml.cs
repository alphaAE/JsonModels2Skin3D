using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JsonModels2Skin3D.model {
    public class Skin3dModelXml {


        // 注意: 生成的代码可能至少需要 .NET Framework 4.5 或 .NET Core/Standard 2.0。
        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        [System.Xml.Serialization.XmlRootAttribute(Namespace = "", IsNullable = false)]
        public partial class Techne {

            private string authorField;

            private object dateCreatedField;

            private string descriptionField;

            private TechneModels modelsField;

            private string nameField;

            private decimal versionField;

            /// <remarks/>
            public string Author {
                get {
                    return this.authorField;
                }
                set {
                    this.authorField = value;
                }
            }

            /// <remarks/>
            public object DateCreated {
                get {
                    return this.dateCreatedField;
                }
                set {
                    this.dateCreatedField = value;
                }
            }

            /// <remarks/>
            public string Description {
                get {
                    return this.descriptionField;
                }
                set {
                    this.descriptionField = value;
                }
            }

            /// <remarks/>
            public TechneModels Models {
                get {
                    return this.modelsField;
                }
                set {
                    this.modelsField = value;
                }
            }

            /// <remarks/>
            public string Name {
                get {
                    return this.nameField;
                }
                set {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public decimal Version {
                get {
                    return this.versionField;
                }
                set {
                    this.versionField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class TechneModels {

            private TechneModelsModel modelField;

            /// <remarks/>
            public TechneModelsModel Model {
                get {
                    return this.modelField;
                }
                set {
                    this.modelField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class TechneModelsModel {

            private string baseClassField;

            private string nameField;

            private string defaultTextureField;

            private TechneModelsModelGeometry geometryField;

            private string textureSizeField;

            private string textureField;

            /// <remarks/>
            public string BaseClass {
                get {
                    return this.baseClassField;
                }
                set {
                    this.baseClassField = value;
                }
            }

            /// <remarks/>
            public string Name {
                get {
                    return this.nameField;
                }
                set {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            public string DefaultTexture {
                get {
                    return this.defaultTextureField;
                }
                set {
                    this.defaultTextureField = value;
                }
            }

            /// <remarks/>
            public TechneModelsModelGeometry Geometry {
                get {
                    return this.geometryField;
                }
                set {
                    this.geometryField = value;
                }
            }

            /// <remarks/>
            public string TextureSize {
                get {
                    return this.textureSizeField;
                }
                set {
                    this.textureSizeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Texture {
                get {
                    return this.textureField;
                }
                set {
                    this.textureField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class TechneModelsModelGeometry {

            private TechneModelsModelGeometryFolder folderField;

            /// <remarks/>
            public TechneModelsModelGeometryFolder Folder {
                get {
                    return this.folderField;
                }
                set {
                    this.folderField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class TechneModelsModelGeometryFolder {

            private TechneModelsModelGeometryFolderShape[] shapeField;

            private string typeField;

            private string nameField;

            /// <remarks/>
            [System.Xml.Serialization.XmlElementAttribute("Shape")]
            public TechneModelsModelGeometryFolderShape[] Shape {
                get {
                    return this.shapeField;
                }
                set {
                    this.shapeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type {
                get {
                    return this.typeField;
                }
                set {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name {
                get {
                    return this.nameField;
                }
                set {
                    this.nameField = value;
                }
            }
        }

        /// <remarks/>
        [System.SerializableAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        [System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true)]
        public partial class TechneModelsModelGeometryFolderShape {

            private string isDecorativeField;

            private string isFixedField;

            private string isMirroredField;

            private string isSolidField;

            private string offsetField;

            private string positionField;

            private string rotationField;

            private string sizeField;

            private string textureOffsetField;

            private decimal scaleField;

            private string partField;

            private string hiddenField;

            private string isArmorField;

            private string typeField;

            private string nameField;

            /// <remarks/>
            public string IsDecorative {
                get {
                    return this.isDecorativeField;
                }
                set {
                    this.isDecorativeField = value;
                }
            }

            /// <remarks/>
            public string IsFixed {
                get {
                    return this.isFixedField;
                }
                set {
                    this.isFixedField = value;
                }
            }

            /// <remarks/>
            public string IsMirrored {
                get {
                    return this.isMirroredField;
                }
                set {
                    this.isMirroredField = value;
                }
            }

            /// <remarks/>
            public string IsSolid {
                get {
                    return this.isSolidField;
                }
                set {
                    this.isSolidField = value;
                }
            }

            /// <remarks/>
            public string Offset {
                get {
                    return this.offsetField;
                }
                set {
                    this.offsetField = value;
                }
            }

            /// <remarks/>
            public string Position {
                get {
                    return this.positionField;
                }
                set {
                    this.positionField = value;
                }
            }

            /// <remarks/>
            public string Rotation {
                get {
                    return this.rotationField;
                }
                set {
                    this.rotationField = value;
                }
            }

            /// <remarks/>
            public string Size {
                get {
                    return this.sizeField;
                }
                set {
                    this.sizeField = value;
                }
            }

            /// <remarks/>
            public string TextureOffset {
                get {
                    return this.textureOffsetField;
                }
                set {
                    this.textureOffsetField = value;
                }
            }

            /// <remarks/>
            public decimal Scale {
                get {
                    return this.scaleField;
                }
                set {
                    this.scaleField = value;
                }
            }

            /// <remarks/>
            public string Part {
                get {
                    return this.partField;
                }
                set {
                    this.partField = value;
                }
            }

            /// <remarks/>
            public string Hidden {
                get {
                    return this.hiddenField;
                }
                set {
                    this.hiddenField = value;
                }
            }

            /// <remarks/>
            public string IsArmor {
                get {
                    return this.isArmorField;
                }
                set {
                    this.isArmorField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type {
                get {
                    return this.typeField;
                }
                set {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name {
                get {
                    return this.nameField;
                }
                set {
                    this.nameField = value;
                }
            }
        }


    }
}
