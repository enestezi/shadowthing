using System;
using System.Xml.Serialization;
using System.Collections.Generic;

	[XmlRoot(ElementName="lidoWrap")]
	public class LidoWrap {
		[XmlElement(ElementName="lido", Namespace="http://www.lido-schema.org")]
		public List<Lido> Lido { get; set; }
	}

	[XmlRoot(ElementName="lido", Namespace="http://www.lido-schema.org")]
	public class Lido {
		[XmlElement(ElementName="lidoRecID", Namespace="http://www.lido-schema.org")]
		public LidoRecID LidoRecID { get; set; }
		[XmlElement(ElementName="category", Namespace="http://www.lido-schema.org")]
		public Category Category { get; set; }
		[XmlElement(ElementName="descriptiveMetadata", Namespace="http://www.lido-schema.org")]
		public DescriptiveMetadata DescriptiveMetadata { get; set; }
		[XmlElement(ElementName="administrativeMetadata", Namespace="http://www.lido-schema.org")]
		public AdministrativeMetadata AdministrativeMetadata { get; set; }
		[XmlAttribute(AttributeName="lido", Namespace="http://www.w3.org/2000/xmlns/")]
		public string _lido { get; set; }
		[XmlAttribute(AttributeName="xsi", Namespace="http://www.w3.org/2000/xmlns/")]
		public string Xsi { get; set; }
		[XmlAttribute(AttributeName="schemaLocation", Namespace="http://www.w3.org/2001/XMLSchema-instance")]
		public string SchemaLocation { get; set; }
	}
	
	[XmlRoot(ElementName="lidoRecID", Namespace="http://www.lido-schema.org")]
	public class LidoRecID {
		[XmlAttribute(AttributeName="source", Namespace="http://www.lido-schema.org")]
		public string Source { get; set; }
		[XmlAttribute(AttributeName="type", Namespace="http://www.lido-schema.org")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="conceptID", Namespace="http://www.lido-schema.org")]
	public class ConceptID {
		[XmlAttribute(AttributeName="type", Namespace="http://www.lido-schema.org")]
		public string Type { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="term", Namespace="http://www.lido-schema.org")]
	public class Term {
		[XmlAttribute(AttributeName="lang", Namespace="http://www.w3.org/XML/1998/namespace")]
		public string Lang { get; set; }
		[XmlText]
		public string Text { get; set; }
		[XmlAttribute(AttributeName="addedSearchTerm", Namespace="http://www.lido-schema.org")]
		public string AddedSearchTerm { get; set; }
		[XmlAttribute(AttributeName="encodinganalog", Namespace="http://www.lido-schema.org")]
		public string Encodinganalog { get; set; }
	}

	[XmlRoot(ElementName="category", Namespace="http://www.lido-schema.org")]
	public class Category {
		[XmlElement(ElementName="conceptID", Namespace="http://www.lido-schema.org")]
		public ConceptID ConceptID { get; set; }
		[XmlElement(ElementName="term", Namespace="http://www.lido-schema.org")]
		public Term Term { get; set; }
	}

	[XmlRoot(ElementName="objectWorkType", Namespace="http://www.lido-schema.org")]
	public class ObjectWorkType {
		[XmlElement(ElementName="conceptID", Namespace="http://www.lido-schema.org")]
		public ConceptID ConceptID { get; set; }
		[XmlElement(ElementName="term", Namespace="http://www.lido-schema.org")]
		public Term Term { get; set; }
	}

	[XmlRoot(ElementName="objectWorkTypeWrap", Namespace="http://www.lido-schema.org")]
	public class ObjectWorkTypeWrap {
		[XmlElement(ElementName="objectWorkType", Namespace="http://www.lido-schema.org")]
		public ObjectWorkType ObjectWorkType { get; set; }
	}

	[XmlRoot(ElementName="classification", Namespace="http://www.lido-schema.org")]
	public class Classification {
		[XmlElement(ElementName="conceptID", Namespace="http://www.lido-schema.org")]
		public ConceptID ConceptID { get; set; }
		[XmlElement(ElementName="term", Namespace="http://www.lido-schema.org")]
		public Term Term { get; set; }
		[XmlAttribute(AttributeName="type", Namespace="http://www.lido-schema.org")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="classificationWrap", Namespace="http://www.lido-schema.org")]
	public class ClassificationWrap {
		[XmlElement(ElementName="classification", Namespace="http://www.lido-schema.org")]
		public Classification Classification { get; set; }
	}

	[XmlRoot(ElementName="objectClassificationWrap", Namespace="http://www.lido-schema.org")]
	public class ObjectClassificationWrap {
		[XmlElement(ElementName="objectWorkTypeWrap", Namespace="http://www.lido-schema.org")]
		public ObjectWorkTypeWrap ObjectWorkTypeWrap { get; set; }
		[XmlElement(ElementName="classificationWrap", Namespace="http://www.lido-schema.org")]
		public ClassificationWrap ClassificationWrap { get; set; }
	}

	[XmlRoot(ElementName="appellationValue", Namespace="http://www.lido-schema.org")]
	public class AppellationValue {
		[XmlAttribute(AttributeName="pref", Namespace="http://www.lido-schema.org")]
		public string Pref { get; set; }
		[XmlAttribute(AttributeName="lang", Namespace="http://www.w3.org/XML/1998/namespace")]
		public string Lang { get; set; }
		[XmlText]
		public string Text { get; set; }
	}

	[XmlRoot(ElementName="titleSet", Namespace="http://www.lido-schema.org")]
	public class TitleSet {
		[XmlElement(ElementName="appellationValue", Namespace="http://www.lido-schema.org")]
		public AppellationValue AppellationValue { get; set; }
	}

	[XmlRoot(ElementName="titleWrap", Namespace="http://www.lido-schema.org")]
	public class TitleWrap {
		[XmlElement(ElementName="titleSet", Namespace="http://www.lido-schema.org")]
		public TitleSet TitleSet { get; set; }
	}

	[XmlRoot(ElementName="legalBodyName", Namespace="http://www.lido-schema.org")]
	public class LegalBodyName {
		[XmlElement(ElementName="appellationValue", Namespace="http://www.lido-schema.org")]
		public string AppellationValue { get; set; }
	}

	[XmlRoot(ElementName="repositoryName", Namespace="http://www.lido-schema.org")]
	public class RepositoryName {
		[XmlElement(ElementName="legalBodyName", Namespace="http://www.lido-schema.org")]
		public LegalBodyName LegalBodyName { get; set; }
	}

	[XmlRoot(ElementName="workID", Namespace="http://www.lido-schema.org")]
	public class WorkID {
		[XmlAttribute(AttributeName="type", Namespace="http://www.lido-schema.org")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="namePlaceSet", Namespace="http://www.lido-schema.org")]
	public class NamePlaceSet {
		[XmlElement(ElementName="appellationValue", Namespace="http://www.lido-schema.org")]
		public string AppellationValue { get; set; }
	}

	[XmlRoot(ElementName="repositoryLocation", Namespace="http://www.lido-schema.org")]
	public class RepositoryLocation {
		[XmlElement(ElementName="namePlaceSet", Namespace="http://www.lido-schema.org")]
		public NamePlaceSet NamePlaceSet { get; set; }
	}

	[XmlRoot(ElementName="repositorySet", Namespace="http://www.lido-schema.org")]
	public class RepositorySet {
		[XmlElement(ElementName="repositoryName", Namespace="http://www.lido-schema.org")]
		public RepositoryName RepositoryName { get; set; }
		[XmlElement(ElementName="workID", Namespace="http://www.lido-schema.org")]
		public WorkID WorkID { get; set; }
		[XmlElement(ElementName="repositoryLocation", Namespace="http://www.lido-schema.org")]
		public RepositoryLocation RepositoryLocation { get; set; }
		[XmlAttribute(AttributeName="type", Namespace="http://www.lido-schema.org")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="repositoryWrap", Namespace="http://www.lido-schema.org")]
	public class RepositoryWrap {
		[XmlElement(ElementName="repositorySet", Namespace="http://www.lido-schema.org")]
		public RepositorySet RepositorySet { get; set; }
	}

	[XmlRoot(ElementName="objectDescriptionSet", Namespace="http://www.lido-schema.org")]
	public class ObjectDescriptionSet {
		[XmlElement(ElementName="descriptiveNoteValue", Namespace="http://www.lido-schema.org")]
		public string DescriptiveNoteValue { get; set; }
	}

	[XmlRoot(ElementName="objectDescriptionWrap", Namespace="http://www.lido-schema.org")]
	public class ObjectDescriptionWrap {
		[XmlElement(ElementName="objectDescriptionSet", Namespace="http://www.lido-schema.org")]
		public ObjectDescriptionSet ObjectDescriptionSet { get; set; }
	}

	[XmlRoot(ElementName="measurementsSet", Namespace="http://www.lido-schema.org")]
	public class MeasurementsSet {
		[XmlElement(ElementName="measurementType", Namespace="http://www.lido-schema.org")]
		public string MeasurementType { get; set; }
		[XmlElement(ElementName="measurementUnit", Namespace="http://www.lido-schema.org")]
		public string MeasurementUnit { get; set; }
		[XmlElement(ElementName="measurementValue", Namespace="http://www.lido-schema.org")]
		public string MeasurementValue { get; set; }
	}

	[XmlRoot(ElementName="objectMeasurements", Namespace="http://www.lido-schema.org")]
	public class ObjectMeasurements {
		[XmlElement(ElementName="measurementsSet", Namespace="http://www.lido-schema.org")]
		public MeasurementsSet MeasurementsSet { get; set; }
	}

	[XmlRoot(ElementName="objectMeasurementsSet", Namespace="http://www.lido-schema.org")]
	public class ObjectMeasurementsSet {
		[XmlElement(ElementName="objectMeasurements", Namespace="http://www.lido-schema.org")]
		public ObjectMeasurements ObjectMeasurements { get; set; }
	}

	[XmlRoot(ElementName="objectMeasurementsWrap", Namespace="http://www.lido-schema.org")]
	public class ObjectMeasurementsWrap {
		[XmlElement(ElementName="objectMeasurementsSet", Namespace="http://www.lido-schema.org")]
		public ObjectMeasurementsSet ObjectMeasurementsSet { get; set; }
	}

	[XmlRoot(ElementName="objectIdentificationWrap", Namespace="http://www.lido-schema.org")]
	public class ObjectIdentificationWrap {
		[XmlElement(ElementName="titleWrap", Namespace="http://www.lido-schema.org")]
		public TitleWrap TitleWrap { get; set; }
		[XmlElement(ElementName="repositoryWrap", Namespace="http://www.lido-schema.org")]
		public RepositoryWrap RepositoryWrap { get; set; }
		[XmlElement(ElementName="objectDescriptionWrap", Namespace="http://www.lido-schema.org")]
		public ObjectDescriptionWrap ObjectDescriptionWrap { get; set; }
		[XmlElement(ElementName="objectMeasurementsWrap", Namespace="http://www.lido-schema.org")]
		public ObjectMeasurementsWrap ObjectMeasurementsWrap { get; set; }
	}

	[XmlRoot(ElementName="eventType", Namespace="http://www.lido-schema.org")]
	public class EventType {
		[XmlElement(ElementName="term", Namespace="http://www.lido-schema.org")]
		public string Term { get; set; }
	}

	[XmlRoot(ElementName="culture", Namespace="http://www.lido-schema.org")]
	public class Culture {
		[XmlElement(ElementName="term", Namespace="http://www.lido-schema.org")]
		public string Term { get; set; }
	}

	[XmlRoot(ElementName="date", Namespace="http://www.lido-schema.org")]
	public class Date {
		[XmlElement(ElementName="earliestDate", Namespace="http://www.lido-schema.org")]
		public string EarliestDate { get; set; }
		[XmlElement(ElementName="latestDate", Namespace="http://www.lido-schema.org")]
		public string LatestDate { get; set; }
	}

	[XmlRoot(ElementName="eventDate", Namespace="http://www.lido-schema.org")]
	public class EventDate {
		[XmlElement(ElementName="date", Namespace="http://www.lido-schema.org")]
		public Date Date { get; set; }
	}

	[XmlRoot(ElementName="event", Namespace="http://www.lido-schema.org")]
	public class Event {
		[XmlElement(ElementName="eventType", Namespace="http://www.lido-schema.org")]
		public EventType EventType { get; set; }
		[XmlElement(ElementName="eventActor", Namespace="http://www.lido-schema.org")]
		public string EventActor { get; set; }
		[XmlElement(ElementName="culture", Namespace="http://www.lido-schema.org")]
		public Culture Culture { get; set; }
		[XmlElement(ElementName="eventDate", Namespace="http://www.lido-schema.org")]
		public EventDate EventDate { get; set; }
	}

	[XmlRoot(ElementName="eventSet", Namespace="http://www.lido-schema.org")]
	public class EventSet {
		[XmlElement(ElementName="displayEvent", Namespace="http://www.lido-schema.org")]
		public string DisplayEvent { get; set; }
		[XmlElement(ElementName="event", Namespace="http://www.lido-schema.org")]
		public Event Event { get; set; }
	}

	[XmlRoot(ElementName="eventWrap", Namespace="http://www.lido-schema.org")]
	public class EventWrap {
		[XmlElement(ElementName="eventSet", Namespace="http://www.lido-schema.org")]
		public List<EventSet> EventSet { get; set; }
	}

	[XmlRoot(ElementName="subjectDate", Namespace="http://www.lido-schema.org")]
	public class SubjectDate {
		[XmlElement(ElementName="displayDate", Namespace="http://www.lido-schema.org")]
		public string DisplayDate { get; set; }
	}

	[XmlRoot(ElementName="subject", Namespace="http://www.lido-schema.org")]
	public class Subject {
		[XmlElement(ElementName="subjectDate", Namespace="http://www.lido-schema.org")]
		public SubjectDate SubjectDate { get; set; }
	}

	[XmlRoot(ElementName="subjectSet", Namespace="http://www.lido-schema.org")]
	public class SubjectSet {
		[XmlElement(ElementName="displaySubject", Namespace="http://www.lido-schema.org")]
		public string DisplaySubject { get; set; }
		[XmlElement(ElementName="subject", Namespace="http://www.lido-schema.org")]
		public Subject Subject { get; set; }
	}

	[XmlRoot(ElementName="subjectWrap", Namespace="http://www.lido-schema.org")]
	public class SubjectWrap {
		[XmlElement(ElementName="subjectSet", Namespace="http://www.lido-schema.org")]
		public SubjectSet SubjectSet { get; set; }
	}

	[XmlRoot(ElementName="objectRelationWrap", Namespace="http://www.lido-schema.org")]
	public class ObjectRelationWrap {
		[XmlElement(ElementName="subjectWrap", Namespace="http://www.lido-schema.org")]
		public SubjectWrap SubjectWrap { get; set; }
	}

	[XmlRoot(ElementName="descriptiveMetadata", Namespace="http://www.lido-schema.org")]
	public class DescriptiveMetadata {
		[XmlElement(ElementName="objectClassificationWrap", Namespace="http://www.lido-schema.org")]
		public ObjectClassificationWrap ObjectClassificationWrap { get; set; }
		[XmlElement(ElementName="objectIdentificationWrap", Namespace="http://www.lido-schema.org")]
		public ObjectIdentificationWrap ObjectIdentificationWrap { get; set; }
		[XmlElement(ElementName="eventWrap", Namespace="http://www.lido-schema.org")]
		public EventWrap EventWrap { get; set; }
		[XmlElement(ElementName="objectRelationWrap", Namespace="http://www.lido-schema.org")]
		public ObjectRelationWrap ObjectRelationWrap { get; set; }
		[XmlAttribute(AttributeName="lang", Namespace="http://www.w3.org/XML/1998/namespace")]
		public string Lang { get; set; }
	}

	[XmlRoot(ElementName="recordID", Namespace="http://www.lido-schema.org")]
	public class RecordID {
		[XmlAttribute(AttributeName="type", Namespace="http://www.lido-schema.org")]
		public string Type { get; set; }
	}

	[XmlRoot(ElementName="recordType", Namespace="http://www.lido-schema.org")]
	public class RecordType {
		[XmlElement(ElementName="term", Namespace="http://www.lido-schema.org")]
		public string Term { get; set; }
	}

	[XmlRoot(ElementName="recordSource", Namespace="http://www.lido-schema.org")]
	public class RecordSource {
		[XmlElement(ElementName="legalBodyName", Namespace="http://www.lido-schema.org")]
		public LegalBodyName LegalBodyName { get; set; }
	}

	[XmlRoot(ElementName="recordWrap", Namespace="http://www.lido-schema.org")]
	public class RecordWrap {
		[XmlElement(ElementName="recordID", Namespace="http://www.lido-schema.org")]
		public RecordID RecordID { get; set; }
		[XmlElement(ElementName="recordType", Namespace="http://www.lido-schema.org")]
		public RecordType RecordType { get; set; }
		[XmlElement(ElementName="recordSource", Namespace="http://www.lido-schema.org")]
		public RecordSource RecordSource { get; set; }
	}
	
	[Serializable]
	[XmlRoot(ElementName="administrativeMetadata", Namespace="http://www.lido-schema.org")]
	public class AdministrativeMetadata {
		[XmlElement(ElementName="recordWrap", Namespace="http://www.lido-schema.org")]
		public RecordWrap RecordWrap { get; set; }
		[XmlAttribute(AttributeName="lang", Namespace="http://www.w3.org/XML/1998/namespace")]
		public string Lang { get; set; }
	}

	
