﻿using System.Xml.Serialization;
using TeisterMask.DataProcessor.ExportDto.TeisterMask.DataProcessor.ExportDto;

namespace TeisterMask.DataProcessor.ExportDto
{
    [XmlType("Project ")]
    public class ExportProjectDto
    {
        [XmlAttribute("TasksCount")]
        public int TasksCount { get; set; }

        [XmlElement("ProjectName")]
        public string ProjectName { get; set; }

        [XmlElement("HasEndDate")]
        public string HasEndDate { get; set; }

        [XmlArray("Tasks")]
        public ExportTaskDto[] Tasks { get; set; }
    }
}