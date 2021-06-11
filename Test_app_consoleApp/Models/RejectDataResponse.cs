using System;
using System.Xml.Serialization;
using System.Collections.Generic;

namespace Test_app_consoleApp
{
	[XmlRoot(ElementName = "head")]
	public class Head
	{
		[XmlElement(ElementName = "target")]
		public string Target { get; set; }
		[XmlElement(ElementName = "type")]
		public string Type { get; set; }
		[XmlElement(ElementName = "description")]
		public string Description { get; set; }
		[XmlElement(ElementName = "timestamp")]
		public string Timestamp { get; set; }
	}

	[XmlRoot(ElementName = "data")]
	public class Data
	{
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
		[XmlText]
		public int Text { get; set; }
		// powyżej była zmiana ze string na int
	}

	[XmlRoot(ElementName = "sample")]
	public class Sample
	{
		[XmlElement(ElementName = "data")]
		public List<Data> Data { get; set; }
		[XmlAttribute(AttributeName = "timestamp")]
		public string Timestamp { get; set; }
	}

	[XmlRoot(ElementName = "source")]
	public class Source
	{
		[XmlElement(ElementName = "sample")]
		public List<Sample> Sample { get; set; }
		[XmlAttribute(AttributeName = "name")]
		public string Name { get; set; }
	}

	[XmlRoot(ElementName = "body")]
	public class Body
	{
		[XmlElement(ElementName = "source")]
		public Source Source { get; set; }
	}

	[XmlRoot(ElementName = "RejectDataResponse")]
	public class RejectDataResponse
	{
		[XmlElement(ElementName = "head")]
		public Head Head { get; set; }
		[XmlElement(ElementName = "body")]
		public Body Body { get; set; }
		[XmlAttribute(AttributeName = "version")]
		public string Version { get; set; }
	}

}