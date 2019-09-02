using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;

namespace PWDataEditorPaied.PW_Admin_classes.IWEB
{
    [XmlRoot(ElementName = "variable")]
    public class Variable
    {
        [XmlAttribute(AttributeName = "name")]
        public string Name { get; set; }
        [XmlAttribute(AttributeName = "type")]
        public string Type { get; set; }
        [XmlText]
        public string Text { get; set; }
    }

    [XmlRoot(ElementName = "base")]
    public class Base
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
    }

    [XmlRoot(ElementName = "equipment")]
    public class Equipment
    {
        [XmlElement(ElementName = "inv")]
        public List<Items> Inv { get; set; }
    }

    [XmlRoot(ElementName = "items")]
    public class Items
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
    }

    [XmlRoot(ElementName = "pocket")]
    public class Pocket
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
        [XmlElement(ElementName = "items")]
        public List<Items> Items { get; set; }
    }

    [XmlRoot(ElementName = "status")]
    public class Status
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
    }

    [XmlRoot(ElementName = "storehouse")]
    public class Storehouse
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
        [XmlElement(ElementName = "generalcard")]
        public List<Items> Generalcard { get; set; }
        [XmlElement(ElementName = "items")]
        public List<Items> Items { get; set; }
        [XmlElement(ElementName = "dress")]
        public List<Items> Dress { get; set; }
        [XmlElement(ElementName = "material")] // Dress etc
        public List<Items> Material { get; set; }
    }

    [XmlRoot(ElementName = "task")]
    public class Task
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
        [XmlElement(ElementName = "task_inventory")]
        public List<Items> Task_inventory { get; set; }
    }

    [XmlRoot(ElementName = "task_inventory")]
    public class Task_inventory
    {
        [XmlElement(ElementName = "variable")]
        public List<Variable> Variable { get; set; }
    }

    [XmlRoot(ElementName = "role")]
    public class XmlRole
    {
        [XmlElement(ElementName = "base")]
        public Base Base { get; set; }
        [XmlElement(ElementName = "equipment")]
        public Equipment Equipment { get; set; }
        [XmlElement(ElementName = "pocket")]
        public Pocket Pocket { get; set; }
        [XmlElement(ElementName = "status")]
        public Status Status { get; set; }
        [XmlElement(ElementName = "storehouse")]
        public Storehouse Storehouse { get; set; }
        [XmlElement(ElementName = "task")]
        public Task Task { get; set; }
    }
}

