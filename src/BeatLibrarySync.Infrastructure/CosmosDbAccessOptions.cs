﻿using System.ComponentModel.DataAnnotations;


public class CosmosDbAccessOptions
{
	[Required]
	public string EndpointUri { get; set; } = string.Empty;

	[Required]
	public string PrimaryKey { get; set; } = string.Empty;

	[Required]
	public string DatabaseId { get; set; } = string.Empty;

	[Required]
	public string ContainerId { get; set; } = string.Empty;
}
